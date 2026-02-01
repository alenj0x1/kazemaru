using backend.DTO;
using backend.Kazemaru.Application.Models.Requests.Note;
using backend.Kazemaru.Application.Models.Responses;

namespace backend.Kazemaru.Application.Interfaces.Services;

public interface INoteService
{
    // Note
    Task<GenericResponse<NoteDTO>> Create(NoteCreateRequestModel model);
    GenericResponse<NoteDTO?> Get(Guid noteId);
    GenericResponse<List<NoteDTO>> Get();
    Task<GenericResponse<NoteDTO>> Update(Guid noteId, NoteUpdateRequestModel model);
    Task<GenericResponse<NoteDTO>> Delete(Guid noteId);
}