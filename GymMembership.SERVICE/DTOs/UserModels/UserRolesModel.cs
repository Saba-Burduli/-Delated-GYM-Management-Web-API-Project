using System.ComponentModel.DataAnnotations;

namespace GymMembership.SERVICE.DTOs.UserModels;

public class UserRolesModel
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? Email { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.Now;

     public int RoleId { get; set; }
    
    public string? RoleName { get; set; } //add seeding in there (Admin, Trainer, Member)


    //we have to check Dachis project if this is correct or not 
}