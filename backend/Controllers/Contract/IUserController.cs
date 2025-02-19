using backend.DTO;
using backend.Models;

namespace backend.Controllers.Contract;

public interface IUserController
{
    GenericResponse<UserDTO?> Me();
}