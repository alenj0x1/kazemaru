using backend.Entity;

namespace backend.Repositories.Contract;

public interface IUserRepository
{
    Task<User> Create(Note note);
    Guid? FindIfExists(Guid userId);
    Guid? FindIfExists(string username);
    User? Get(Guid userId);
    Task<User?> Update(User user);
    Task<bool> Delete(User user);
}