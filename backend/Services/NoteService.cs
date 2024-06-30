using AutoMapper;
using backend.DTO;
using backend.Entity;
using backend.Models.Request.Note;
using backend.Repositories.Contract;
using backend.Services.Contract;

namespace backend.Services
{
  public class NoteService(KazemarudbContext db, INoteRepository repNote, IProjectRepository repProj, ITaskRepository repTask, IMapper mapper) : INoteService
  {
    private readonly KazemarudbContext _db = db;
    private readonly INoteRepository _repNote = repNote;
    private readonly IProjectRepository _repProj = repProj;
    private readonly ITaskRepository _repTask = repTask;
    private readonly IMapper _mapper = mapper;

    public async Task<NoteDTO> CreateNote(NoteCreateRequestModel model)
    {
      try
      {
        if (_repNote.GetNote(_db, model.Title) is not null) throw new Exception("The note was previously created");
        if (model.Title.Length > 100) throw new Exception("The note title length is longer than allowed.");
        if (model.ProjectId.HasValue && model.TaskId.HasValue) throw new Exception("You cannot link a note to a task and a project at the same time.");
        if (model.ProjectId.HasValue && _repProj.GetProject(_db, model.ProjectId.Value) is null) throw new Exception($"The project with id: '{model.ProjectId}' does not exist.");
        if (model.TaskId.HasValue && _repTask.GetTask(_db, model.TaskId.Value) is null) throw new Exception($"The task with id: '{model.TaskId}' does not exist.");
      
        return _mapper.Map<NoteDTO>(await _repNote.CreateNote(_db, model));
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
        Note findNote = _repNote.GetNote(_db, noteId) ?? throw new Exception($"The note with id: '{noteId}' does not exist.");
        NoteDTO mappedNote = _mapper.Map<NoteDTO>(findNote);

        List<Notetag> noteTags = _repNote.GetNoteTags(_db, noteId);
        if (noteTags.Count != 0) mappedNote.Tags = _mapper.Map<List<NoteTagDTO>>(noteTags);

        return mappedNote;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public NoteDTO GetNote(string noteName)
    {
      try
      {
        Note findNote = _repNote.GetNote(_db, noteName) ?? throw new Exception($"The note with name: '{noteName}' does not exist.");
        NoteDTO mappedNote = _mapper.Map<NoteDTO>(findNote);

        List<Notetag> ntTags = _repNote.GetNoteTags(_db, findNote.Noteid);
        if (ntTags.Count != 0) mappedNote.Tags = _mapper.Map<List<NoteTagDTO>>(ntTags);

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
        List<Note> notes = _repNote.GetNotes(_db);
        List<NoteDTO> mappedNotes = _mapper.Map<List<NoteDTO>>(notes);

        foreach (NoteDTO note in mappedNotes)
        {
          note.Tags = _mapper.Map<List<NoteTagDTO>>(_repNote.GetNoteTags(_db, note.NoteId));
        }

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
        Note? updNote = _repNote.GetNote(_db, model.NoteId) ?? throw new Exception($"The note with id: '{model.NoteId}' does not exist.");
        
        if (model.Title is not null && model.Title.Length > 100) throw new Exception("The note title length is longer than allowed.");
        if (model.ProjectId.HasValue && model.TaskId.HasValue) throw new Exception("You cannot link a note to a task and a project at the same time.");
        if (model.ProjectId.HasValue && _repProj.GetProject(_db, model.ProjectId.Value) is null) throw new Exception($"The project with id: '{model.ProjectId}' does not exist.");
        if (model.TaskId.HasValue && _repTask.GetTask(_db, model.TaskId.Value) is null) throw new Exception($"The task with id: '{model.TaskId}' does not exist.");
        if (model.ProjectId.HasValue && updNote.Taskid.HasValue) throw new Exception("You cannot link a note to a project and a task at the same time.");
        if (model.TaskId.HasValue && updNote.Projectid.HasValue) throw new Exception("You cannot link a note to a task and a project at the same time.");

        return _mapper.Map<NoteDTO>(await _repNote.UpdateNote(_db, model));
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
        if (_repNote.GetNote(_db, noteId) is null) throw new Exception($"The note with id: '{noteId}' does not exist.");

        List<Notetag> ntTags = _repNote.GetNoteTags(_db, noteId);

        if (ntTags.Count > 0)
        {
          foreach (Notetag tag in ntTags)
          {
            await _repNote.DeleteNoteTag(_db, tag.Notetagid);
          }
        }

        return await _repNote.DeleteNote(_db, noteId);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<NoteTagDTO> CreateNoteTag(NoteTagCreateRequestModel model)
    {
      try
      {
        if (_repNote.GetNote(_db, model.NoteId) is null) throw new Exception($"The note with id: '{model.NoteId}' does not exist.");
        if (_repNote.GetNoteTag(_db, model.Name) is not null) throw new Exception("The note tag was previously created");
        if (model.Name.Length > 30) throw new Exception("The note tag name length is longer than allowed.");

        return _mapper.Map<NoteTagDTO>(await _repNote.CreateNoteTag(_db, model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public NoteTagDTO GetNoteTag(Guid noteTagId)
    {
      try
      {
        Notetag findNoteTg = _repNote.GetNoteTag(_db, noteTagId) ?? throw new Exception($"The note with id: '{noteTagId}' does not exist.");

        return _mapper.Map<NoteTagDTO>(findNoteTg);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<NoteTagDTO> GetNoteTags()
    {
      try
      {
        return _mapper.Map<List<NoteTagDTO>>(_repNote.GetNoteTags(_db));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<NoteTagDTO> UpdateNoteTag(NoteTagUpdateRequestModel model)
    {
      try
      {
        if (_repNote.GetNoteTag(_db, model.NoteTagId) is null) throw new Exception($"The note tag with id: '{model.NoteTagId}' does not exist.");
        if (model.NoteId.HasValue && _repNote.GetNote(_db, model.NoteId.Value) is null) throw new Exception($"The note with id: '{model.NoteId}' does not exist.");
        if (model.Name is not null && model.Name.Length > 30) throw new Exception("The note tag name length is longer than allowed.");

        return _mapper.Map<NoteTagDTO>(await _repNote.UpdateNoteTag(_db, model));
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteNoteTag(Guid noteTagId)
    {
      try
      {
        if (_repNote.GetNoteTag(_db, noteTagId) is null) throw new Exception($"The note tag with id: '{noteTagId}' does not exist.");

        return await _repNote.DeleteNoteTag(_db, noteTagId);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
