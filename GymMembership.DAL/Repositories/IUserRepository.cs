using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;
using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.DAL.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<UserModel>GetUserByEmail(string email);
    //adding more methods in there 
}