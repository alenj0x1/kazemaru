using backend.Entity;
using backend.Entity.Postgres;
using backend.Repositories.Contract;

namespace backend.Repositories
{
    public class NoteRepository(KazemaruDbContext db) : BaseRepository<Note>(db), INoteRepository
    {
        private readonly KazemaruDbContext _db = db;

        public Note? Get(string title)
        {
            try
            {
                return _db.Notes.FirstOrDefault(nt => nt.Title == title);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Note? Get(Guid noteId)
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

        public List<Note> GetByProject(Guid projectId)
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

        public List<Note> GetByTask(Guid taskId)
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

        public List<Note> Get()
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
    }
}