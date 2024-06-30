using backend.DTO;
using backend.Models.Request.Note;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
  public interface INotesController
  {
    // Note
    Task<IActionResult> CreateNote([FromBody] NoteCreateRequestModel model);
    IActionResult GetNote(Guid noteId);
    IActionResult GetNote(string noteName);
    IActionResult GetNotes();
    Task<IActionResult> UpdateNote([FromBody] NoteUpdateRequestModel model);
    Task<IActionResult> DeleteNote(Guid noteId);

    // Note tag
    Task<IActionResult> CreateNoteTag([FromBody] NoteTagCreateRequestModel model);
    IActionResult GetNoteTag(Guid noteTagId);
    IActionResult GetNoteTags();
    Task<IActionResult> UpdateNoteTag([FromBody] NoteTagUpdateRequestModel model);
    Task<IActionResult> DeleteNoteTag(Guid noteTagId);
  }
}
