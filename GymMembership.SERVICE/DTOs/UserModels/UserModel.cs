namespace GymMembership.SERVICE.DTOs.UserModels;

public class UserModel
{
    public int UserId { get; set; }
    
    public string? UserName { get; set; }
    
    public string? PasswordHash { get; set; }
    
    public string? Email { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.Now;

}