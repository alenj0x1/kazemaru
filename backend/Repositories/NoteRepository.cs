using backend.Entity;
using backend.Repositories.Contract;

namespace backend.Repositories
{
    public class NoteRepository(KazemaruDbContext db) : INoteRepository
    {
        private readonly KazemaruDbContext _db = db;

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
                return _db.Notes.FirstOrDefault(nt => nt.NoteId == noteId);
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
                    .Where(nt => nt.NoteId == noteId)
                    .Select(nt => nt.NoteId)
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
                    .Select(nt => nt.NoteId)
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
                return [.. _db.Notes.Where(nt => nt.ProjectId == projectId)];
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
                return [.. _db.Notes.Where(nt => nt.TaskId == taskId)];
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