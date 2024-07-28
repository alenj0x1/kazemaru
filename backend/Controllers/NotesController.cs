using backend.DTO;
using backend.Interfaces;
using backend.Models;
using backend.Models.Request.Note;
using backend.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NotesController(INoteService noteService) : ControllerBase, INotesController
  {
    private readonly INoteService _srvNote = noteService;

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] NoteCreateRequestModel model)
    {
      GenericResponse<NoteDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvNote.CreateNote(model);
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = true;
        return BadRequest(rsp);
      }
    }

    [HttpGet("{noteId}")]
    public IActionResult GetNote(Guid noteId)
    {
      GenericResponse<NoteDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _srvNote.GetNote(noteId);
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = true;
        return BadRequest(rsp);
      }
    }

    [HttpGet]
    public IActionResult GetNotes()
    {
      GenericResponse<List<NoteDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _srvNote.GetNotes();
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = true;
        return BadRequest(rsp);
      }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNote([FromBody] NoteUpdateRequestModel model)
    {
      GenericResponse<NoteDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvNote.UpdateNote(model);
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = true;
        return BadRequest(rsp);
      }
    }

    [HttpDelete("{noteId}")]
    public async Task<IActionResult> DeleteNote(Guid noteId)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _srvNote.DeleteNote(noteId);
        rsp.IsSuccess = true;
        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Message = ex.Message;
        rsp.IsSuccess = true;
        return BadRequest(rsp);
      }
    }
  }
}
