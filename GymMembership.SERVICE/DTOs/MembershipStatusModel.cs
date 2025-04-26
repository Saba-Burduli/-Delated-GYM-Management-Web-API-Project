namespace GymMembership.SERVICE.DTOs.UserModels;

public class MembershipStatusModel
{  
    public bool isActive { get; set; } 
    
    public string? MembershipType { get; set; } //Add seeding in there  (monthly, yearly, VIP)

    public int MembershipId { get; set; } //I added this by myself .I can use this in Method for Check if Membership Exists in DB
                                          //with Id.
}