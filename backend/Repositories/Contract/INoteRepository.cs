using backend.Entity;
using backend.Models.Request.Note;

namespace backend.Repositories.Contract
{
  public interface INoteRepository
  {
    Task<Note> CreateNote(NoteCreateRequestModel model);
    Note? GetNote(string noteTitle);
    Note? GetNote(Guid noteId);
    List<Note> GetNotesByProject(Guid projectId);
    List<Note> GetNotesByTask(Guid taskId);
    List<Note> GetNotes();
    Task<Note?> UpdateNote(NoteUpdateRequestModel model);
    Task<bool> DeleteNote(Guid noteId);
  }
}
