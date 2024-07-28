using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models.Request.Note;
using backend.Repositories.Contract;
using backend.Services.Contract;

namespace backend.Services
{
  public class NoteService(INoteRepository repNote, IProjectRepository repProj, ITaskRepository repTask, IMapper mapper) : INoteService
  {
    private readonly INoteRepository _repNote = repNote;
    private readonly IProjectRepository _repProj = repProj;
    private readonly ITaskRepository _repTask = repTask;
    private readonly IMapper _mapper = mapper;

    public async Task<NoteDTO> CreateNote(NoteCreateRequestModel model)
    {
      try
      {
        if (_repNote.GetNote(model.Title) is not null) throw new Exception("The note was previously created");
        if (model.Title.Length > 100) throw new Exception("The note title length is longer than allowed.");
        if (model.ProjectId.HasValue && model.TaskId.HasValue) throw new Exception("You cannot link a note to a task and a project at the same time.");
        if (model.ProjectId.HasValue && _repProj.GetProject(model.ProjectId.Value) is null) throw new Exception($"The project with id: '{model.ProjectId}' does not exist.");
        if (model.TaskId.HasValue && _repTask.GetTask(model.TaskId.Value) is null) throw new Exception($"The task with id: '{model.TaskId}' does not exist.");
      
        return _mapper.Map<NoteDTO>(await _repNote.CreateNote(model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public NoteDTO GetNote(Guid noteId)
    {
      try
      {
        Note findNote = _repNote.GetNote(noteId) ?? throw new Exception($"The note with id: '{noteId}' does not exist.");
        NoteDTO mappedNote = _mapper.Map<NoteDTO>(findNote);

        return mappedNote;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<NoteDTO> GetNotes()
    {
      try
      {
        List<Note> notes = _repNote.GetNotes();
        List<NoteDTO> mappedNotes = _mapper.Map<List<NoteDTO>>(notes);

        return mappedNotes;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<NoteDTO> UpdateNote(NoteUpdateRequestModel model)
    {
      try
      {
        if (model.NoteId == Guid.Empty) throw new Exception("The note id is a required field");

        Note? updNote = _repNote.GetNote(model.NoteId) ?? throw new Exception($"The note with id: '{model.NoteId}' does not exist.");
        
        if (model.Title is not null && model.Title.Length > 100) throw new Exception("The note title length is longer than allowed.");
        if (model.ProjectId.HasValue && model.TaskId.HasValue) throw new Exception("You cannot link a note to a task and a project at the same time.");
        if (model.ProjectId.HasValue && _repProj.GetProject(model.ProjectId.Value) is null) throw new Exception($"The project with id: '{model.ProjectId}' does not exist.");
        if (model.TaskId.HasValue && _repTask.GetTask(model.TaskId.Value) is null) throw new Exception($"The task with id: '{model.TaskId}' does not exist.");
        if (model.ProjectId.HasValue && updNote.Taskid.HasValue) throw new Exception("You cannot link a note to a project and a task at the same time.");
        if (model.TaskId.HasValue && updNote.Projectid.HasValue) throw new Exception("You cannot link a note to a task and a project at the same time.");

        NoteDTO mappedNote = _mapper.Map<NoteDTO>(await _repNote.UpdateNote(model));

        return mappedNote;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteNote(Guid noteId)
    {
      try
      {
        if (noteId == Guid.Empty) throw new Exception("The note tag id is a required field");
        if (_repNote.GetNote(noteId) is null) throw new Exception($"The note with id: '{noteId}' does not exist.");

        return await _repNote.DeleteNote(noteId);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
