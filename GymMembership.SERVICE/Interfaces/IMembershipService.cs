namespace GymMembership.SERVICE.Interfaces;

public interface IMembershipService
{
    Membership CreateMembership (Membership membership);
    Task<bool> RenewMembership(int membershipld);
    Task<MembershipStatus> GetMembershipStatusAsync(int customerId);
    Task<List<Membership>> GetMembershipsByUser(int userld);
    Task<List<Membership>> GetAllMembershipsByStatuses;
}