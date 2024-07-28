using backend.Entity;
using backend.Models.Request.Note;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class NoteRepository(KazemarudbContext db) : INoteRepository
  {
    private readonly KazemarudbContext _db = db;

    public async Task<Note> CreateNote(NoteCreateRequestModel model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Note crtNote = new()
        {
          Title = model.Title,
          Content = model.Content,
          Projectid = model.ProjectId,
          Taskid = model.TaskId,
        };

        await _db.Notes.AddAsync(crtNote);
        await _db.SaveChangesAsync();
        
        tx.Commit();
        return crtNote;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Note? GetNote(string noteTitle)
    {
      try
      {
        return _db.Notes.Where(nt => nt.Title == noteTitle).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Note? GetNote(Guid noteId)
    {
      try
      {
        return _db.Notes.Where(nt => nt.Noteid == noteId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Note> GetNotesByProject(Guid projectId)
    {
      try
      {
        return [.. _db.Notes.Where(nt => nt.Projectid == projectId)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Note> GetNotesByTask(Guid taskId)
    {
      try
      {
        return [.. _db.Notes.Where(nt => nt.Taskid == taskId)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Note> GetNotes()
    {
      try
      {
        return [.. _db.Notes];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Note?> UpdateNote(NoteUpdateRequestModel model)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Note? updNote = GetNote(model.NoteId);

        if (updNote is not null)
        {
          updNote.Title = model.Title ?? updNote.Title;
          updNote.Content = model.Content ?? updNote.Content;
          updNote.Projectid = model.ProjectId ?? updNote.Projectid;
          updNote.Taskid = model.TaskId ?? updNote.Taskid;

          _db.Notes.Update(updNote);
          await _db.SaveChangesAsync();
        }

        tx.Commit();
        return updNote;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public async Task<bool> DeleteNote(Guid noteId)
    {
      using var tx = await _db.Database.BeginTransactionAsync();

      try
      {
        Note? delNote = GetNote(noteId);

        if (delNote is not null)
        {
          _db.Notes.Remove(delNote);
          await _db.SaveChangesAsync();
          tx.Commit();

          return true;
        }

        return false;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }
  }
}
