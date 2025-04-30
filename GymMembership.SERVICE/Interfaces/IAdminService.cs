using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.SERVICE.Interfaces;

public interface IAdminService
{
    Task<List<UserModel>> GetAllUsersAsync();
    Task<UserModel> GetUserByIdAsync(int userld);
    Task<UserModel> AddUserAsync(UserModel model);
    Task<AuthResponseModel> UpdateUserDetailsAsync (int userld, UpdateUserModel model);
    Task<AuthResponseModel> RemoveUserAsync(int userld); //RemoveUserAsync() = RemoveUserByIdAsync() // This name of method is in PDF
}