using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE.Interfaces;

namespace GymMembership.SERVICE;

public class MembershipService : IMembershipService
{
    public Task<MembershipModel> CreateMembership(RegisterMembershipModel membership)
    {
        throw new NotImplementedException();
    }
    public Task RenewMembership(int membershipld)
    {
        throw new NotImplementedException();
    }
    public Task<bool> GetMembershipStatusAsync(int customerId)
    {
        throw new NotImplementedException();
    }
    public Task<List<MembershipModel>> GetMembershipsByUser(int userld)
    {
        throw new NotImplementedException();
    }
    public Task<List<MembershipModel>> GetAllMembershipsByStatusesAsync()
    {
        throw new NotImplementedException();
    }
}