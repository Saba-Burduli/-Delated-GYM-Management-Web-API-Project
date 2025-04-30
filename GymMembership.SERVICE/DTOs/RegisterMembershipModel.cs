namespace GymMembership.SERVICE.DTOs.UserModels;

public class RegisterMembershipModel
{
    public int UserId { get; set; }

    public int MembershipTypeId { get; set; }
    
    public DateTime StartDate { get; set; } = DateTime.UtcNow; //we gonna test it now .. if it works i shouldnt add DateTime.Now
        
    public DateTime EndDate { get; set; } = DateTime.UtcNow; //we gonna test it now .. if it works i shouldnt add DateTime.Now
    
}