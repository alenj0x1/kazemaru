using backend.DTO;
using backend.Controllers.Contract;
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
        public async Task<GenericResponse<NoteDTO>> CreateNote([FromBody] NoteCreateRequestModel model)
        {
            try
            {
                return await _srvNote.CreateNote(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{noteId:guid}")]
        public GenericResponse<NoteDTO?> GetNote(Guid noteId)
        {
            try
            {
                return _srvNote.GetNote(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public GenericResponse<List<NoteDTO>> GetNotes()
        {
            try
            {
                return _srvNote. GetNotes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{noteId:guid}")]
        public async Task<GenericResponse<NoteDTO>> UpdateNote(Guid noteId, [FromBody] NoteUpdateRequestModel model)
        {
            try
            {
                return await _srvNote.UpdateNote(noteId, model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{noteId:guid}")]
        public async Task<GenericResponse<bool>> DeleteNote(Guid noteId)
        {
            try
            {
                return await _srvNote.DeleteNote(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}