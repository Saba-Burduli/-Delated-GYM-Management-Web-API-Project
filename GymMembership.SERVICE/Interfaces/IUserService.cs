using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.SERVICE.Interfaces;

public interface IUserService
{
    Task<UserModel> GetUserProfileAsync(int userld);
    Task<AuthResponseModel> UserRegistrationAsync(int? roleld, RegisterUserModel model);
    Task<AuthResponseModel> LoginAsync(string username, string password);
    Task<AuthResponseModel> UpdateUserProfileAsync(UpdateUserModel model,int userId);
    Task<AuthResponseModel> DeleteUserProfileAsync( int userId);
    Task<bool> AssignToGymClassesAsync(int userId,List<int > gymClassIds);  //we implement this method in GymClassRepository(delate from here)
    List<GymClassModel> GetGymClassesByUserAsync(int userld); //we implement this method in GymClassRepository(delate from here)
    Task<UserRolesModel> GetUserWithRolesByIdAsync(int userld); //new method
    
}
