using backend.DTO;
using backend.Controllers.Contract;
using backend.Models;
using backend.Models.Request.Note;
using backend.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController(INoteService noteService) : ControllerBase, INotesController
    {
        private readonly INoteService _srvNote = noteService;
        
        [Authorize]
        [HttpPost]
        public async Task<GenericResponse<NoteDTO>> CreateNote([FromBody] NoteCreateRequestModel model)
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
        public GenericResponse<NoteDTO?> GetNote(Guid noteId)
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
        public GenericResponse<List<NoteDTO>> GetNotes()
        {
            try
            {
                return _srvNote. Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut("{noteId:guid}")]
        public async Task<GenericResponse<NoteDTO>> UpdateNote(Guid noteId, [FromBody] NoteUpdateRequestModel model)
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
        public async Task<GenericResponse<NoteDTO>> DeleteNote(Guid noteId)
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
}