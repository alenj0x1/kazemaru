using backend.DTO;
using backend.Models.Request.Note;

namespace backend.Services.Contract
{
  public interface INoteService
  {
    // Note
    Task<NoteDTO> CreateNote(NoteCreateRequestModel model);
    NoteDTO GetNote(Guid noteId);
    NoteDTO GetNote(string noteName);
    List<NoteDTO> GetNotes();
    Task<NoteDTO> UpdateNote(NoteUpdateRequestModel model);
    Task<bool> DeleteNote(Guid noteId);

    // Note tag
    Task<NoteTagDTO> CreateNoteTag(NoteTagCreateRequestModel model);
    NoteTagDTO GetNoteTag(Guid noteTagId);
    List<NoteTagDTO> GetNoteTags();
    Task<NoteTagDTO> UpdateNoteTag(NoteTagUpdateRequestModel model);
    Task<bool> DeleteNoteTag(Guid noteTagId);
  }
}
