using backend.DTO;
using backend.Models.Request.Note;

namespace backend.Services.Contract
{
  public interface INoteService
  {
    // Note
    Task<NoteDTO> CreateNote(NoteCreateRequestModel model);
    NoteDTO GetNote(Guid noteId);
    List<NoteDTO> GetNotes();
    Task<NoteDTO> UpdateNote(NoteUpdateRequestModel model);
    Task<bool> DeleteNote(Guid noteId);
  }
}
