using backend.Kazemaru.Domain.Entities;

namespace backend.Repositories.Contract;

public interface IUserRepository
{
    Guid? FindIfExists(Guid userId);
    Guid? FindIfExists(string username);
    User? Get(string username);
    User? Get(Guid userId);
}