using System.Collections;
using GymMembership.DAL.Repositories;
using GymMembership.DATA.Entities;
using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE.Interfaces;
using GymMembership.SERVICE.Mapper;


namespace GymMembership.SERVICE;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserService _userService;
    private readonly IGymClassRepository _gymClassRepository;
    private readonly IRoleRepository _rolesRepository;

    public UserService(IUserRepository userRepository, IUserService userService, IPasswordHasher passwordHasher, IGymClassRepository gymClassRepository,IRoleRepository rolesRepository)
    {
        _userService = userService;
        _gymClassRepository = gymClassRepository;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _rolesRepository = rolesRepository;
    }

    public async Task<UserModel> GetUserProfileAsync(int userId)
    {
        var user = await _userRepository.GetUserProfileAsync(userId);
        if (user == null)
        {
            throw new NullReferenceException("User is null");
        }

        return new UserModel()
        {
            UserId = userId,
            UserName = user.UserName,
            Email = user.Email,
            RegistrationDate = user.RegistrationDate,
        };
    } 
    public async Task<AuthResponseModel> UserRegistrationAsync(int? roleld, RegisterUserModel model)
    {
        var existingUser = await _userRepository.GetAllUserByEmailAsync(model.Email);
        
        if (existingUser!=null)
        {
            return new AuthResponseModel{Success = true, Message = "User already exists"};
        }
        
        var personMapping = UserMapper.UserRegistrationAsync(roleld, model); 
        
        var lastAddedUser = await _userService.UserRegistrationAsync(roleld, model);
        
        var roles = await _rolesRepository.GetAllAsync(); // we need rolesRepository
        
        return new AuthResponseModel{Success = true, Message = "User added"};
    }
    
    public async Task<AuthResponseModel> LoginAsync(LoginUserModel model)
    {
        var user = await _userRepository.GetAllUserByEmailAsync(model.Email);
        if (user == null || !await _passwordHasher.VerifyPasswordHashAsync(model.Password , user.PasswordHash))
            return await Task.FromResult(new AuthResponseModel { Success = false, Message = "User not found" });
        
        return await Task.FromResult(new AuthResponseModel { Success = true, Message = "User Logged in" });
    } //here i need Ipasswordhash.

    public async Task<AuthResponseModel> UpdateUserProfileAsync(UpdateUserModel model, int userId)
    {
        var user = await _userRepository.GetByIDAsync(userId);

        if (user == null)
            return new AuthResponseModel { Success = false, Message = "User not found" };

        if (!string.IsNullOrWhiteSpace(model.UserName))
            user.UserName = model.UserName;

        if (!string.IsNullOrEmpty(model.Password))
        {
            bool verified = await _passwordHasher.VerifyPasswordHashAsync(user.PasswordHash,
                    model.Password); //added this by myself (and i have to check if its right)
            return new AuthResponseModel { Success = true, Message = "All good" };
        }

        return await _userService.UpdateUserProfileAsync(model, userId); //i added this by myself
    } 

    public async Task<AuthResponseModel> DeleteUserProfileAsync(int userId)
    {
        var user = await _userRepository.GetByIDAsync(userId);
        if (user == null)
            return new AuthResponseModel { Success = false, Message = "User not found" };
        
        await _userRepository.DeleteAsync(user.UserId);
        return new AuthResponseModel { Success = true, Message = "User deleted" };
    }

    public async Task<bool> AssignToGymClassesAsync(int userId,List<int> gymClassIds) //Added this methods name +To
    {
        return await _gymClassRepository.AssignToGymClassesAsync(userId,gymClassIds);
    }
    
    public async Task<List<GymClassModel>> GetGymClassesByUserAsync(int userld)
    {
        var gymClasses = await _gymClassRepository.GetGymClassesByUserAsync(userld);
        if (gymClasses==null)
        {
            throw new NullReferenceException("gymClasses is null");
        }
      
        return gymClasses.Select(g => new GymClassModel
        {
            GymClassName = g.GymClassName,
            GymClassId = g.GymClassId,
            // Add more mapping as needed
        }).ToList();
        // return  UserMapper.GymClassModelMapping(gymClasses).Result.FirstOrDefault(); this is manual mapping example and this is not working
    }
    public async Task<UserRolesModel> GetUserWithRolesByIdAsync(int userld) //new method
    {
        var user = await _userRepository.GetUserWithRolesByIdAsync(userld);
        return UserMapper.UserRolesMapping(user).Result.FirstOrDefault();
    }
}