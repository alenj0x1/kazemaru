using Kazemaru.Application.Models.Dtos;
using Kazemaru.Application.Models.Requests.Note;
using Kazemaru.Application.Models.Responses;

namespace Kazemaru.Application.Interfaces.Services;

public interface INoteService
{
    // Note
    Task<GenericResponse<NoteDto>> Create(NoteCreateRequestModel model);
    GenericResponse<NoteDto?> Get(Guid noteId);
    GenericResponse<List<NoteDto>> Get();
    Task<GenericResponse<NoteDto>> Update(Guid noteId, NoteUpdateRequestModel model);
    Task<GenericResponse<NoteDto>> Delete(Guid noteId);
}