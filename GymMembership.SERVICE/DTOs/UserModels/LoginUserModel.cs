using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GymMembership.SERVICE.DTOs.UserModels;

public class LoginUserModel
{
    public string? UserName { get; set; }
    
    public string? Email { get; set; }

    public string? Password { get; set; }
    
}