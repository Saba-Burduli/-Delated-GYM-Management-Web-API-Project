using System.Security.Cryptography;
using GymMembership.DATA.Entities;

namespace GymMembership.DAL.Repositories;

public interface IPasswordHasher
{
    Task<string> HashPasswordAsync(string password);
    Task<bool> VerifyPasswordHashAsync(string password, string passwordHash);
}

public sealed class PasswordHasher : IPasswordHasher
{
    //So this Constrants are Main in passwordhashing to get different hashs .
    //1.SaltSize : Is added Value to  Hashing algorithm To get different Hashs always. If user1 set password (user123)
    //and user2 set the same password (user123) they never have to get the same hashed password.if yes this is not secure.
    
    private const int SaltSize = 16;//this is recommended by Microsoft.16 bytes is enough.
    
    //2.HashSize : Is the size of the hashed password.
    private const int HashSize = 32;//this is recommended by Microsoft.20 bytes is enough.
    
    private const int Iterations = 100000;//3.Iterations : Is the number of times the hashing algorithm is applied.
    
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA3_512;
    public async Task<string> HashPasswordAsync(string password)
    {
        //Salt generation
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);//this is for generate random SaltSize each Iteration
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password,salt,Iterations,Algorithm,HashSize);
        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public async Task<bool> VerifyPasswordHashAsync(string password, string passwordHash)
    {
        string[] parts = passwordHash.Split('-');
        byte[] hash=Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);
        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password,salt,Iterations,Algorithm,HashSize);
        // return inputHash.SequenceEqual(hash); //its not right practice we have to not implement this method in this way.
        return CryptographicOperations.FixedTimeEquals(hash,inputHash); //So this type of method is better because if hacker want to get some
                                                                        //loading time to guess password using hash he can't get time because
                                                                        //CryptographicOperations.FixedTimeEquals means that there is no unfixed time betwenn inputhash and hash.
    }
}