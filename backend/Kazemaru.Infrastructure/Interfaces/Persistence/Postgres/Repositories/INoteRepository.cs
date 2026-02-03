using backend.Kazemaru.Domain.Entities;

namespace backend.Repositories.Contract
{
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
}
