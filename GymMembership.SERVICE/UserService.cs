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
    //private readonly IUserService _userService; you can't eject something that inheritenced 
    private readonly IGymClassRepository _gymClassRepository;
    private readonly IRoleRepository _rolesRepository;
    public readonly IPersonRepository _personRepository;

    public UserService(IUserRepository userRepository, /*IUserService userService,*/ IPasswordHasher passwordHasher, IGymClassRepository gymClassRepository,IRoleRepository rolesRepository,IPersonRepository personRepository)
    {
        // _userService = userService;
        _gymClassRepository = gymClassRepository;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _rolesRepository = rolesRepository;
        _personRepository = personRepository;
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
            return new AuthResponseModel { Success = true, Message = "User already exists"};
        }
        
        Person personEntity = UserMapper.UserRegistrationAsync(roleld, model); 
        
        var lastAddedUser = await _personRepository.GetLastAddedUserAsync(personEntity);
        
        var roles = await _rolesRepository.GetAllAsync(); // we need rolesRepository
        var newUser = new User
        {
            UserName = model.UserName,
            PasswordHash = await _passwordHasher.HashPasswordAsync(model.Password),
            Email = model.Email,
            Person = lastAddedUser,
            Roles = roles.Where(r => r.RoleId == model.RoleId).ToList(),

        };
        
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
            await _passwordHasher.HashPasswordAsync(model.Password); //added this by myself (and i have to check if its right)
        }
        
        await _userRepository.UpdateAsync(user); //i added this by myself

        return new AuthResponseModel { Success = true, Message = "User Profile successfuly Updated !" };
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