namespace GymMembership.DAL.Repositories;

public interface IPasswordHasher
{
    Task<string> HashPasswordAsync(string password);
    Task<bool> VerifyPasswordHashAsync(string password, string passwordHash);
}

public class PasswordHasher : IPasswordHasher
{
    public Task<string> HashPasswordAsync(string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyPasswordHashAsync(string password, string passwordHash)
    {
        throw new NotImplementedException();
    }
}