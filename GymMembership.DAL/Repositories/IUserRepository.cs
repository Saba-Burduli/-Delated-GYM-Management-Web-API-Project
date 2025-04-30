using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;
using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.DAL.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<UserModel> GetUserProfileAsync();
    Task<AuthResponseModel> GetAllUserByIdAsync(int userId);
    Task<AuthResponseModel> GetAllUserByEmailAsync(string email);
    Task<AuthResponseModel> GetUserWithRolesByIdAsync(int userId);
    Task<AuthResponseModel> GetAllUserByRolesIdAsync(int roleId); // i added by myself 
    Task<AuthResponseModel> GetAllMembersAsync();
    Task<AuthResponseModel> GetAllTrainersAsync();
    //maybe we gonna add more methods inside this repisitory file
}