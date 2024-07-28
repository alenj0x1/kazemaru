using backend.DTO;
using backend.Models.Request.Note;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
  public interface INotesController
  {
    Task<IActionResult> CreateNote([FromBody] NoteCreateRequestModel model);
    IActionResult GetNote(Guid noteId);
    IActionResult GetNotes();
    Task<IActionResult> UpdateNote([FromBody] NoteUpdateRequestModel model);
    Task<IActionResult> DeleteNote(Guid noteId);
  }
}
