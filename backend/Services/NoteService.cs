using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models;
using backend.Models.Request.Note;
using backend.Repositories.Contract;
using backend.Services.Contract;
using backend.Tools;

namespace backend.Services
{
    public class NoteService(
        INoteRepository repNote,
        IProjectRepository repProj,
        ITaskRepository repTask,
        IMapper mapper) : INoteService
    {
        private readonly INoteRepository _repNote = repNote;
        private readonly IProjectRepository _repProj = repProj;
        private readonly ITaskRepository _repTask = repTask;
        private readonly IMapper _mapper = mapper;

        public async Task<GenericResponse<NoteDTO>> CreateNote(NoteCreateRequestModel model)
        {
            try
            {
                if (_repNote.FindIfExists(model.Title) is not null)
                    throw new Exception(ResponseConstants.NoteCreatedPreviously);
                
                if (model is { ProjectId: not null, TaskId: not null })
                    throw new Exception(ResponseConstants.NoteTaskAndProjectLinkedSameTime);
                
                if (model.ProjectId.HasValue && _repProj.FindIfExistsProject(model.ProjectId.Value) is null)
                    throw new Exception(ResponseConstants.ProjectNotExists(model.ProjectId.Value));
                
                if (model.TaskId.HasValue && _repTask.GetTask(model.TaskId.Value) is null)
                    throw new Exception(ResponseConstants.TaskNotExists(model.TaskId.Value));

                var createNote = await _repNote.CreateNote(new Note
                {
                    Title = model.Title,
                    Content = model.Content,
                    Projectid = model.ProjectId,
                    Taskid = model.TaskId
                });
                var mapper = _mapper.Map<NoteDTO>(createNote);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericResponse<NoteDTO?> GetNote(Guid noteId)
        {
            try
            {
                var findNote = _repNote.GetNote(noteId) ?? throw new Exception(ResponseConstants.NoteNotExists(noteId));
                var mapper = _mapper.Map<NoteDTO?>(findNote);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericResponse<List<NoteDTO>> GetNotes()
        {
            try
            {
                var findNotes = _repNote.GetNotes();
                var mapper = _mapper.Map<List<NoteDTO>>(findNotes);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<NoteDTO>> UpdateNote(Guid noteId, NoteUpdateRequestModel model)
        {
            try
            {
                if (noteId == Guid.Empty) throw new Exception(ResponseConstants.NoteIdIsRequired);

                var findNote = _repNote.GetNote(noteId) ?? throw new Exception(ResponseConstants.NoteNotExists(noteId));

                if (model.ProjectId.HasValue && _repProj.GetProject(model.ProjectId.Value) is null)
                    throw new Exception(ResponseConstants.ProjectNotExists(model.ProjectId.Value));
                if (model.TaskId.HasValue && _repTask.GetTask(model.TaskId.Value) is null)
                    throw new Exception(ResponseConstants.TaskNotExists(model.TaskId.Value));
                if (model is { ProjectId: not null, TaskId: not null })
                    throw new Exception(ResponseConstants.NoteTaskAndProjectLinkedSameTime);
                if (model.ProjectId.HasValue && findNote.Taskid.HasValue)
                    throw new Exception(ResponseConstants.NoteTaskAndProjectLinkedSameTime);
                if (model.TaskId.HasValue && findNote.Projectid.HasValue)
                    throw new Exception(ResponseConstants.NoteTaskAndProjectLinkedSameTime);

                findNote.Title = model.Title ?? findNote.Title;
                findNote.Content = model.Content ?? findNote.Content;
                findNote.Projectid = model.ProjectId ?? findNote.Projectid;
                findNote.Taskid = model.TaskId ?? findNote.Taskid;

                var updateNote = await _repNote.UpdateNote(findNote);
                var mapper = _mapper.Map<NoteDTO>(updateNote);

                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResponse<bool>> DeleteNote(Guid noteId)
        {
            try
            {
                if (noteId == Guid.Empty) throw new Exception(ResponseConstants.NoteIdIsRequired);

                var findNote = _repNote.GetNote(noteId) ?? throw new Exception(ResponseConstants.NoteNotExists(noteId));

                var mapper = await _repNote.DeleteNote(findNote);
                return ManageResponse.Create(mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}