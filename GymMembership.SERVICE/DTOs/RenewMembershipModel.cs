namespace GymMembership.SERVICE.DTOs.UserModels;

public class RenewMembershipModel
{
    public int MembershipId { get; set; }
    public DateTime NewEndDate { get; set; }
}