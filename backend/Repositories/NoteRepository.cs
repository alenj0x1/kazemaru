using backend.Entity;
using backend.Models.Request.Note;
using backend.Repositories.Contract;

namespace backend.Repositories
{
    public class NoteRepository(KazemarudbContext db) : INoteRepository
    {
        private readonly KazemarudbContext _db = db;

        public async Task<Note> CreateNote(Note note)
        {
            try
            {
                await _db.Notes.AddAsync(note);
                await _db.SaveChangesAsync();

                return note;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Note? GetNote(string noteTitle)
        {
            try
            {
                return _db.Notes.FirstOrDefault(nt => nt.Title == noteTitle);
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
                return _db.Notes.FirstOrDefault(nt => nt.Noteid == noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Guid? FindIfExists(Guid noteId)
        {
            try
            {
                return _db.Notes
                    .Where(nt => nt.Noteid == noteId)
                    .Select(nt => nt.Noteid)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public Guid? FindIfExists(string title)
        {
            try
            {
                return _db.Notes
                    .Where(nt => nt.Title == title)
                    .Select(nt => nt.Noteid)
                    .FirstOrDefault();
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

        public async Task<Note?> UpdateNote(Note note)
        {
            try
            {
                _db.Notes.Update(note);
                await _db.SaveChangesAsync();

                return note;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteNote(Note note)
        {
            try
            {
                _db.Notes.Remove(note);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}