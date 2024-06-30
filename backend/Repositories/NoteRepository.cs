using backend.Entity;
using backend.Models.Request.Note;
using backend.Repositories.Contract;

namespace backend.Repositories
{
  public class NoteRepository : INoteRepository
  {
    // Note
    public async Task<Note> CreateNote(KazemarudbContext db, NoteCreateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Note crtNote = new()
        {
          Title = model.Title,
          Content = model.Content,
          Projectid = model.ProjectId,
          Taskid = model.TaskId,
        };

        await db.Notes.AddAsync(crtNote);
        await db.SaveChangesAsync();
        
        tx.Commit();
        return crtNote;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Note? GetNote(KazemarudbContext db, string noteTitle)
    {
      try
      {
        return db.Notes.Where(nt => nt.Title == noteTitle).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Note? GetNote(KazemarudbContext db, Guid noteId)
    {
      try
      {
        return db.Notes.Where(nt => nt.Noteid == noteId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Note> GetNotes(KazemarudbContext db)
    {
      try
      {
        return [.. db.Notes];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Note> GetNotes(KazemarudbContext db, string noteTitle)
    {
      try
      {
        return [.. db.Notes.Where(nt => nt.Title == noteTitle)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Note?> UpdateNote(KazemarudbContext db, NoteUpdateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Note? updNote = GetNote(db, model.NoteId);

        if (updNote is not null)
        {
          updNote.Title = model.Title ?? updNote.Title;
          updNote.Content = model.Content ?? updNote.Content;
          updNote.Projectid = model.ProjectId ?? model.ProjectId;
          updNote.Taskid = model.TaskId ?? model.TaskId;

          db.Notes.Update(updNote);
          await db.SaveChangesAsync();
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

    public async Task<bool> DeleteNote(KazemarudbContext db, Guid noteId)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Note? delNote = GetNote(db, noteId);

        if (delNote is not null)
        {
          db.Notes.Remove(delNote);
          await db.SaveChangesAsync();
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

    // Note tag
    public async Task<Notetag> CreateNoteTag(KazemarudbContext db, NoteTagCreateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Notetag crtNoteTag = new()
        {
          Noteid = model.NoteId,
          Name = model.Name,
        };

        await db.Notetags.AddAsync(crtNoteTag);
        await db.SaveChangesAsync();

        tx.Commit();
        return crtNoteTag;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public Notetag? GetNoteTag(KazemarudbContext db, Guid noteTagId)
    {
      try
      {
        return db.Notetags.Where(nt => nt.Notetagid == noteTagId).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Notetag? GetNoteTag(KazemarudbContext db, string noteTagName)
    {
      try
      {
        return db.Notetags.Where(nt => nt.Name == noteTagName).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Notetag> GetNoteTags(KazemarudbContext db)
    {
      try
      {
        return [.. db.Notetags];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Notetag> GetNoteTags(KazemarudbContext db, Guid noteId)
    {
      try
      {
        return [.. db.Notetags.Where(nt => nt.Noteid == noteId)];
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<Notetag?> UpdateNoteTag(KazemarudbContext db, NoteTagUpdateRequestModel model)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Notetag? updNoteTag = GetNoteTag(db, model.NoteTagId);

        if (updNoteTag is not null)
        {
          updNoteTag.Noteid = model.NoteId ?? updNoteTag.Noteid;
          updNoteTag.Name = model.Name ?? updNoteTag.Name;

          db.Notetags.Update(updNoteTag);
          await db.SaveChangesAsync();
        }

        tx.Commit();
        return updNoteTag;
      }
      catch (Exception)
      {
        await tx.RollbackAsync();
        throw;
      }
    }

    public async Task<bool> DeleteNoteTag(KazemarudbContext db, Guid noteTagId)
    {
      using var tx = await db.Database.BeginTransactionAsync();

      try
      {
        Notetag? delNote = GetNoteTag(db, noteTagId);

        if (delNote is not null)
        {
          db.Notetags.Remove(delNote);
          await db.SaveChangesAsync();
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
