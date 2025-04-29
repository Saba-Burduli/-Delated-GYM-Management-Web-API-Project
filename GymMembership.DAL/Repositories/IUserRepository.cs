using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;
using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.DAL.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<UserModel>GetUserByEmail(string email);
        
        //We have to Add more methods in there
        //Check Project 
}
