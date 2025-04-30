using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.SERVICE.Interfaces;

public interface IMembershipService
{
    Task<MembershipModel> CreateMembership (RegisterMembershipModel membership);
    Task RenewMembership(int membershipld);
    Task<bool> GetMembershipStatusAsync(int customerId);
    Task<List<MembershipModel>> GetMembershipsByUser(int userld);
    Task<List<MembershipModel>> GetAllMembershipsByStatusesAsync();
}