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

        // [GET Method] User/GetUserProfile(int userId)
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

        // [POST Method] User/UserRegistration(int? roleld, RegisterUserModel model)

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

        // [POST Method] User/Login(LoginUserModel model)
        [HttpPost("Login{model:frombody}")] //im gonna check if {model:fromBody is needed}
        public async Task<IActionResult> LoginAsync(LoginUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(model);
                if (!result.Success)
                {
                    return BadRequest("Cannot Login right now");
                }
                return Ok(result.Message);
            }
            return BadRequest();
        }

        // [PUT Method] User/UpdateUserProfile(UpdateUserModel model, int userId)
        [HttpPut("UpdateUserProfile/{userId:int},{model:frombody}")] //im gonna check if {model:fromBody is needed}
        public async Task<IActionResult> UpdateUserProfileAsync(UpdateUserModel model, int userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserProfileAsync(model, userId);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }

            return BadRequest("Something went wrong in Update User Profile");
        }

        //[DELATE Method] DeleteUserProfile(int userId)
        [HttpDelete("DeleteUserProfile/{userId:int}")]
        public async Task<IActionResult> DeleteUserProfileAsync(int userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.DeleteUserProfileAsync(userId);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            return BadRequest();
        }


        public async Task<IActionResult> AssignToGymClassesAsync(int userId, List<int> gymClassIds)
        {
            if (ModelState.IsValid)
            {
                if (gymClassIds == null || !gymClassIds.Any())
                {
                    return BadRequest("Gym class IDs cannot be null or empty.");
                }

                bool resultforbool = await _userService.AssignToGymClassesAsync(userId, gymClassIds);

                if (resultforbool)
                {
                    return Ok("User assigned to gym classes successfully");
                }
            }
            return BadRequest();
        }


        //[HttpPost("assign-to-gym-classes")]
        // public async Task<IActionResult> AssignToGymClasses(int userId, [FromBody] List<int> gymClassIds)
        // {
        //     if (gymClassIds == null || !gymClassIds.Any())
        //     {
        //         return BadRequest("You must provide at least one gym class ID.");
        //     }
        // 
        //     bool result = await _yourService.AssignToGymClassesAsync(userId, gymClassIds);
        // 
        //     if (result)
        //     {
        //         return Ok(new { success = true, message = "User assigned to gym classes successfully." });
        //     }
        //     else
        //     {
        //         return StatusCode(500, new { success = false, message = "Failed to assign user to gym classes." });
        //     }
        // }
        // 

        
        


        
        
        // public async Task<bool> AssignToGymClassesAsync(int userId,List<int> gymClassIds) //Added this methods name +To
        // public async Task<List<GymClassModel>> GetGymClassesByUserAsync(int userld)
        // public async Task<UserRolesModel> GetUserWithRolesByIdAsync(int userld) //new method
        //
    }
}
