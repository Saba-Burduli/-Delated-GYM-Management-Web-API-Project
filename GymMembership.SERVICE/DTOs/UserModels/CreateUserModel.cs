using GymMembership.SERVICE.DTOs.PersonModels;

namespace GymMembership.SERVICE.DTOs.UserModels;

public class CreateUserModel
{
    public int UserId { get; set; }
    
    public string? UserName { get; set; }
    
    public string? Email { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    
    public PersonModel PersonModel  { get; set; }
    
    public int? RoleId { get; set; }
    
}