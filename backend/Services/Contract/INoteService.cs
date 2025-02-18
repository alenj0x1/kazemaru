using backend.DTO;
using backend.Models;
using backend.Models.Request.Note;

namespace backend.Services.Contract
{
    public interface INoteService
    {
        // Note
        Task<GenericResponse<NoteDTO>> CreateNote(NoteCreateRequestModel model);
        GenericResponse<NoteDTO?> GetNote(Guid noteId);
        GenericResponse<List<NoteDTO>> GetNotes();
        Task<GenericResponse<NoteDTO>> UpdateNote(Guid noteId, NoteUpdateRequestModel model);
        Task<GenericResponse<bool>> DeleteNote(Guid noteId);
    }
}