using backend.Entity;
using backend.Models.Request.Note;

namespace backend.Repositories.Contract
{
  public interface INoteRepository
  {
    // Note
    Task<Note> CreateNote(KazemarudbContext db, NoteCreateRequestModel model);
    Note? GetNote(KazemarudbContext db, string noteTitle);
    Note? GetNote(KazemarudbContext db, Guid noteId);
    List<Note> GetNotes(KazemarudbContext db);
    List<Note> GetNotes(KazemarudbContext db, string noteTitle);
    Task<Note?> UpdateNote(KazemarudbContext db, NoteUpdateRequestModel model);
    Task<bool> DeleteNote(KazemarudbContext db, Guid taskId);

    // Note tag
    Task<Notetag> CreateNoteTag(KazemarudbContext db, NoteTagCreateRequestModel model);
    Notetag? GetNoteTag(KazemarudbContext db, Guid noteId);
    Notetag? GetNoteTag(KazemarudbContext db, string noteTagName);
    List<Notetag> GetNoteTags(KazemarudbContext db);
    List<Notetag> GetNoteTags(KazemarudbContext db, Guid noteId);
    Task<Notetag?> UpdateNoteTag(KazemarudbContext db, NoteTagUpdateRequestModel model);
    Task<bool> DeleteNoteTag(KazemarudbContext db, Guid noteTagId);
  }
}
