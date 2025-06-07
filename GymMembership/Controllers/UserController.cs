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

        //[POST METHOD] AssingToGymClasses(int userId, List<int> gymClassIds)
        [HttpPost("AssignToGymClasses/{userId:int},{gymClassIds:frombody}")] //should i need this things ?
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
        //maybe there is some ussue with implement If(ModelState.IsValid) (U should see Dachis Project)

        [HttpGet("GetGymClassesByUser/{userld:int}")]
        public async Task<IActionResult> GetGymClassesByUserAsync(int userld)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _userService.GetGymClassesByUserAsync(userld);
            if (result == null || !result.Any())
            {
                return NotFound("There is no GymClass or User with this Id");
            }

            return Ok("User and GymClass founded !");
        }

        //[GET METHOD ] GetUserWithRolesByIdAsync(int userld)
        [HttpGet("Get User With Roles By Id{userld:int}")]
        public async Task<IActionResult> GetUserWithRolesByIdAsync(int userld)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.GetUserWithRolesByIdAsync(userld);
                if (result ==null)
                {
                    return BadRequest("There is no User with this role");
                }

                return Ok("We found User with this role");
            }

            return BadRequest("Somethings wrong !");
        }
        
    }
}
