using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;
using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.DAL.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<UserModel> GetUserProfileAsync();
    Task<AuthResponseModel> GetAllUserByIdAsync(int userId);
    Task<AuthResponseModel> GetAllUserByEmailAsync(string email);
    Task<AuthResponseModel> GetUserWithRolesByIdAsync(UpdateUserModel model);
    Task<AuthResponseModel> GetAllUsersAsync();
    Task<AuthResponseModel> GetAllTrainersAsync();
    Task<bool> AssignGymClassesAsync(List<int > gymClassIds); //maybe I'm gonna change Task<AuthResponseModel,bool>
    //In this <> i Have AuthResponseModel,bool together and
    //think i dont need this
    List<GymClassModel> GetGymClassesByUserAsync(int userld);
}