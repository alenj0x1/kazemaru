using backend.Entity;

namespace backend.Repositories.Contract
{
  public interface INoteRepository
  {
    Task<Note> CreateNote(Note note);
    Guid? FindIfExists(Guid noteId);
    Guid? FindIfExists(string title);
    Note? GetNote(string noteTitle);
    Note? GetNote(Guid noteId);
    List<Note> GetNotesByProject(Guid projectId);
    List<Note> GetNotesByTask(Guid taskId);
    List<Note> GetNotes();
    Task<Note?> UpdateNote(Note note);
    Task<bool> DeleteNote(Note note);
  }
}
