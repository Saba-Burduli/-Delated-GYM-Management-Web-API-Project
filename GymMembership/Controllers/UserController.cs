using GymMembership.DATA.Entities;
using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GymMembership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceProviderIsService _serviceProvider;
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        private readonly IMembershipService _membershipService;
        
        public UserController(IServiceProviderIsService serviceProvider , IUserService userService, IAdminService adminService, IMembershipService membershipService)
        {
            _serviceProvider = serviceProvider;
            _userService = userService;
            _adminService = adminService;
            _membershipService = membershipService;
        }

        // [GET Method] User/GetUserProfile()
        [HttpGet("GetUserProfile/{userId:int}")]
        public async Task<IActionResult> GetUserProfileAsync(int userId)
        {
            if (ModelState.IsValid)
            {
               var user = await _userService.GetUserProfileAsync(userId);
               if (user == null)
               {
                   return NotFound("User not found");
               }
               return Ok(user);
            }
            return BadRequest();
        }

        [HttpPost("UserRegistration,{roleld:int},{model:frombody}")]
        public async Task<IActionResult> UserRegistrationAsync(int? roleld, RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UserRegistrationAsync(roleld, model);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
               
                return Ok(result.Message);
            }

            return BadRequest();
        }
        
        

        
        
        // public Task<AuthResponseModel> LoginAsync(LoginUserModel model)
        // public async Task<AuthResponseModel> UpdateUserProfileAsync(UpdateUserModel model, int userId)
        // public async Task<AuthResponseModel> DeleteUserProfileAsync(int userId)
        // public async Task<bool> AssignToGymClassesAsync(int userId,List<int> gymClassIds) //Added this methods name +To
        // public async Task<List<GymClassModel>> GetGymClassesByUserAsync(int userld)
        // public async Task<UserRolesModel> GetUserWithRolesByIdAsync(int userld) //new method
        //
    }
}
