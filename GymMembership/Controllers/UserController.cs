using GymMembership.DATA.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymMembership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceProviderIsService _serviceProvider;
        public UserController(IServiceProviderIsService serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet("GetUserProfile/{userId:int}")]
        public Task<User> GetUserProfileAsync(int userId)
        {
            if (use)
            {
                
            }
        }
        
        // public async Task<UserModel> GetUserProfileAsync(int userId)
        // public async Task<AuthResponseModel> UserRegistrationAsync(int? roleld, RegisterUserModel model)
        // public Task<AuthResponseModel> LoginAsync(LoginUserModel model)
        // public async Task<AuthResponseModel> UpdateUserProfileAsync(UpdateUserModel model, int userId)
        // public async Task<AuthResponseModel> DeleteUserProfileAsync(int userId)
        // public async Task<bool> AssignToGymClassesAsync(int userId,List<int> gymClassIds) //Added this methods name +To
        // public async Task<List<GymClassModel>> GetGymClassesByUserAsync(int userld)
        // public async Task<UserRolesModel> GetUserWithRolesByIdAsync(int userld) //new method
        //
    }
}
