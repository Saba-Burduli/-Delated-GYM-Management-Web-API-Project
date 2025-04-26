namespace GymMembership.SERVICE.DTOs.UserModels;

public class MembershipModel
{
    public int MembershipId { get; set; }
    
    public DateTime StartDate { get; set; } = DateTime.UtcNow; //we gonna test it now .. if it works i shouldnt add DateTime.Now
        
    public DateTime EndDate { get; set; } = DateTime.UtcNow; //we gonna test it now .. if it works i shouldnt add DateTime.Now
        
    public bool IsActive { get; set; }

    public decimal Price { get; set; }  //I add this field By Myself

}