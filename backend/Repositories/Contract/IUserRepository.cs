using backend.Entity;
using backend.Entity.Postgres;

namespace backend.Repositories.Contract;

public interface IUserRepository
{
    Guid? FindIfExists(Guid userId);
    Guid? FindIfExists(string username);
    User? Get(string username);
    User? Get(Guid userId);
}