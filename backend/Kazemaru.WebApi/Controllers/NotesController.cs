using Kazemaru.Application.Interfaces.Services;
using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Requests.Note;
using Kazemaru.Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kazemaru.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController(INoteService noteService) : ControllerBase
{
    private readonly INoteService _srvNote = noteService;

    [Authorize]
    [HttpPost]
    public async Task<GenericResponse<NoteDto>> CreateNote([FromBody] NoteCreateRequestModel model)
    {
        try
        {
            return await _srvNote.Create(model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpGet("{noteId:guid}")]
    public GenericResponse<NoteDto?> GetNote(Guid noteId)
    {
        try
        {
            return _srvNote.Get(noteId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpGet]
    public GenericResponse<List<NoteDto>> GetNotes()
    {
        try
        {
            return _srvNote.Get();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpPut("{noteId:guid}")]
    public async Task<GenericResponse<NoteDto>> UpdateNote(Guid noteId, [FromBody] NoteUpdateRequestModel model)
    {
        try
        {
            return await _srvNote.Update(noteId, model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpDelete("{noteId:guid}")]
    public async Task<GenericResponse<NoteDto>> DeleteNote(Guid noteId)
    {
        try
        {
            return await _srvNote.Delete(noteId);
        }
        catch (Exception)
        {
            throw;
        }
    }
}