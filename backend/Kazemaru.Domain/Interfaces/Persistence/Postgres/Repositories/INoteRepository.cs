using Kazemaru.Domain.Entities;

namespace Kazemaru.Domain.Interfaces.Persistence.Postgres.Repositories;

public interface INoteRepository
{
    Guid? FindIfExists(Guid noteId);
    Guid? FindIfExists(string title);
    Note? Get(string title);
    Note? Get(Guid noteId);
    List<Note> GetByProject(Guid projectId);
    List<Note> GetByTask(Guid taskId);
    List<Note> Get();
}