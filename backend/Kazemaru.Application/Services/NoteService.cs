using AutoMapper;
using backend.DTO;
using backend.Entity.Postgres;
using backend.Helpers;
using backend.Kazemaru.Application.Interfaces.Services;
using backend.Kazemaru.Application.Models.Requests.Note;
using backend.Kazemaru.Application.Models.Responses;
using backend.Repositories;

namespace backend.Kazemaru.Application.Services
{
    public class NoteService(
        NoteRepository repNote,
        ProjectRepository repProj,
        TaskRepository repTask,
        IMapper mapper) : INoteService
    {
        private readonly NoteRepository _repNote = repNote;
        private readonly ProjectRepository _repProj = repProj;
        private readonly TaskRepository _repTask = repTask;
        private readonly IMapper _mapper = mapper;

        public async Task<GenericResponse<NoteDTO>> Create(NoteCreateRequestModel model)
        {
            try
            {
                if (_repNote.FindIfExists(model.Title) is not null)
                    throw new Exception(ResponseConstants.NoteCreatedPreviously);

                if (model is { ProjectId: not null, TaskId: not null })
                    throw new Exception(ResponseConstants.NoteTaskAndProjectLinkedSameTime);

                if (model.ProjectId.HasValue && _repProj.FindIfExists(model.ProjectId.Value) is null)
                    throw new Exception(ResponseConstants.ProjectNotExists(model.ProjectId.Value));

                if (model.TaskId.HasValue && _repTask.Get(model.TaskId.Value) is null)
                    throw new Exception(ResponseConstants.TaskNotExists(model.TaskId.Value));

                var createNote = await _repNote.Create(new Note
                {
                    Title = model.Title,
                    Content = model.Content,
                    ProjectId = model.ProjectId,
                    TaskId = model.TaskId
                });
                var mapper = _mapper.Map<NoteDTO>(createNote);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericResponse<NoteDTO?> Get(Guid noteId)
        {
            try
            {
                var findNote = _repNote.Get(noteId) ?? throw new Exception(ResponseConstants.NoteNotExists(noteId));
                var mapper = _mapper.Map<NoteDTO?>(findNote);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericResponse<List<NoteDTO>> Get()
        {
            try
            {
                var findNotes = _repNote.Get();
                var mapper = _mapper.Map<List<NoteDTO>>(findNotes);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<NoteDTO>> Update(Guid noteId, NoteUpdateRequestModel model)
        {
            try
            {
                if (noteId == Guid.Empty) throw new Exception(ResponseConstants.NoteIdIsRequired);

                var findNote = _repNote.Get(noteId) ?? throw new Exception(ResponseConstants.NoteNotExists(noteId));

                if (model.ProjectId.HasValue && _repProj.Get(model.ProjectId.Value) is null)
                    throw new Exception(ResponseConstants.ProjectNotExists(model.ProjectId.Value));
                if (model.TaskId.HasValue && _repTask.Get(model.TaskId.Value) is null)
                    throw new Exception(ResponseConstants.TaskNotExists(model.TaskId.Value));
                if (model is { ProjectId: not null, TaskId: not null })
                    throw new Exception(ResponseConstants.NoteTaskAndProjectLinkedSameTime);
                if (model.ProjectId.HasValue && findNote.TaskId.HasValue)
                    throw new Exception(ResponseConstants.NoteTaskAndProjectLinkedSameTime);
                if (model.TaskId.HasValue && findNote.ProjectId.HasValue)
                    throw new Exception(ResponseConstants.NoteTaskAndProjectLinkedSameTime);

                findNote.Title = model.Title ?? findNote.Title;
                findNote.Content = model.Content ?? findNote.Content;
                findNote.ProjectId = model.ProjectId ?? findNote.ProjectId;
                findNote.TaskId = model.TaskId ?? findNote.TaskId;

                var updateNote = await _repNote.Update(findNote);
                var mapper = _mapper.Map<NoteDTO>(updateNote);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<NoteDTO>> Delete(Guid noteId)
        {
            try
            {
                if (noteId == Guid.Empty) throw new Exception(ResponseConstants.NoteIdIsRequired);

                var findNote = _repNote.Get(noteId) ?? throw new Exception(ResponseConstants.NoteNotExists(noteId));

                var mapper = _mapper.Map<NoteDTO>(await _repNote.Delete(findNote));
                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}