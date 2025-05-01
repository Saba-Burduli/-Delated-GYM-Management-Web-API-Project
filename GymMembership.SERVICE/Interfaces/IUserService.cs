using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.SERVICE.Interfaces;

public interface IUserService
{
    Task<UserModel> GetUserProfileAsync();
    Task<AuthResponseModel> UserRegistrationAsync(int? roleld, RegisterUserModel model);
    Task<AuthResponseModel> LoginAsync(string username, string password);
    Task<AuthResponseModel> UpdateUserProfileAsync(UpdateUserModel model);
    Task<AuthResponseModel> DeleteUserProfileAsync();
    Task<bool> AssignGymClassesAsync(List<int > gymClassIds); //maybe I'm gonna change Task<AuthResponseModel,bool>
                                                                                //In this <> i Have AuthResponseModel,bool together and
                                                                                //think i dont need this
    List<GymClassModel> GetGymClassesByUserAsync(int userld);


    

    
}
