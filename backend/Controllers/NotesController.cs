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
  public class NotesController(INoteService noteServ) : ControllerBase, INotesController
  {
    private readonly INoteService _noteServ = noteServ;

    // Note
    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] NoteCreateRequestModel model)
    {
      GenericResponse<NoteDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _noteServ.CreateNote(model);
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
        rsp.Data = _noteServ.GetNote(noteId);
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

    [HttpGet("byName/{noteName}")]
    public IActionResult GetNote(string noteName)
    {
      GenericResponse<NoteDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _noteServ.GetNote(noteName);
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

    [HttpGet("all")]
    public IActionResult GetNotes()
    {
      GenericResponse<List<NoteDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _noteServ.GetNotes();
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
        rsp.Data = await _noteServ.UpdateNote(model);
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
        rsp.Data = await _noteServ.DeleteNote(noteId);
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

    // Note tag
    [HttpPost("tag")]
    public async Task<IActionResult> CreateNoteTag([FromBody] NoteTagCreateRequestModel model)
    {
      GenericResponse<NoteTagDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _noteServ.CreateNoteTag(model);
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

    [HttpGet("tag/{noteTagId}")]
    public IActionResult GetNoteTag(Guid noteTagId)
    {
      GenericResponse<NoteTagDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _noteServ.GetNoteTag(noteTagId);
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

    [HttpGet("tag/all")]
    public IActionResult GetNoteTags()
    {
      GenericResponse<List<NoteTagDTO>> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = _noteServ.GetNoteTags();
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

    [HttpPut("tag")]
    public async Task<IActionResult> UpdateNoteTag([FromBody] NoteTagUpdateRequestModel model)
    {
      GenericResponse<NoteTagDTO> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _noteServ.UpdateNoteTag(model);
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

    [HttpDelete("tag/{noteTagId}")]
    public async Task<IActionResult> DeleteNoteTag(Guid noteTagId)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        rsp.Message = "OK";
        rsp.Data = await _noteServ.DeleteNoteTag(noteTagId);
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
