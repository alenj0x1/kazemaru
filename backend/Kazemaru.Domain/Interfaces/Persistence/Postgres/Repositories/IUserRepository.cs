using Kazemaru.Domain.Entities;

namespace Kazemaru.Domain.Interfaces.Persistence.Postgres.Repositories;

public interface IUserRepository
{
    Guid? FindIfExists(Guid userId);
    Guid? FindIfExists(string username);
    User? Get(string username);
    User? Get(Guid userId);
}