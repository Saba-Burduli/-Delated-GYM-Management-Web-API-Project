using GymMembership.SERVICE.DTOs.PersonModels;

namespace GymMembership.SERVICE.DTOs.UserModels;

public class RegisterUserModel
{
   
    public string? UserName { get; set; }
        
    public string? Password { get; set; }
    
    public string? Email { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    
    public PersonModel? Person { get; set; }

    public int RoleId { get; set; }
}