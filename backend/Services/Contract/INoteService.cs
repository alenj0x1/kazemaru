using backend.DTO;
using backend.Models;
using backend.Models.Request.Note;

namespace backend.Services.Contract
{
    public interface INoteService
    {
        // Note
        Task<GenericResponse<NoteDTO>> Create(NoteCreateRequestModel model);
        GenericResponse<NoteDTO?> Get(Guid noteId);
        GenericResponse<List<NoteDTO>> Get();
        Task<GenericResponse<NoteDTO>> Update(Guid noteId, NoteUpdateRequestModel model);
        Task<GenericResponse<NoteDTO>> Delete(Guid noteId);
    }
}