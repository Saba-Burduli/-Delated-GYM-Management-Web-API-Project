using System.Security.Cryptography;

namespace GymMembership.DAL.Repositories;

public interface IPasswordHasher
{
    Task<string> HashPasswordAsync(string password);
    Task<bool> VerifyPasswordHashAsync(string password, string passwordHash);
}

public class PasswordHasher : IPasswordHasher
{
    //So this Constrants are Main in passwordhashing to get different hashs .
    //1.SaltSize : Is added Value to  Hashing algorithm To get different Hashs always. If user1 set password (user123)
    //and user2 set the same password (user123) they never have to get the same hashed password.if yes this is not secure.
    
    private const int SaltSize = 16;//this is recommended by Microsoft.16 bytes is enough.
    
    //2.HashSize : Is the size of the hashed password.
    private const int HashSize = 32;//this is recommended by Microsoft.20 bytes is enough.
    
    private const int Iterations = 10000;//3.Iterations : Is the number of times the hashing algorithm is applied.
    
    private readonly HashAlgorithmName algorithm = HashAlgorithmName.SHA3_512;
    public Task<string> HashPasswordAsync(string password)
    {
        //Salt generation
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);//this is for generate random SaltSize each Iteration
    }

    public Task<bool> VerifyPasswordHashAsync(string password, string passwordHash)
    {
        throw new NotImplementedException();
    }
}