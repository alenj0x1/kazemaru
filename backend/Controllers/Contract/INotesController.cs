using backend.DTO;
using backend.Models;
using backend.Models.Request.Note;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Contract
{
  public interface INotesController
  {
    Task<GenericResponse<NoteDTO>> CreateNote([FromBody] NoteCreateRequestModel model);
    GenericResponse<NoteDTO?> GetNote(Guid noteId);
    GenericResponse<List<NoteDTO>> GetNotes();
    Task<GenericResponse<NoteDTO>> UpdateNote(Guid noteId, [FromBody] NoteUpdateRequestModel model);
    Task<GenericResponse<bool>> DeleteNote(Guid noteId);
  }
}
