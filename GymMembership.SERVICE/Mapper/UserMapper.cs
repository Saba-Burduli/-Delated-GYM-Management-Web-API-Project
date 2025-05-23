using GymMembership.DATA.Entities;
using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.SERVICE.Mapper;

public static class UserMapper
{ 
    //we need UserRolesMapping method
    public static GymClassModel GymClassModelMapping(this GymClass entity)
    {
        return new GymClassModel()
        {
            GymClassId = entity.GymClassId,
            GymClassName = entity.GymClassName,
        };
    }

    public static UserRolesModel UserRolesMapping(this User entity)
    {
        return new UserRolesModel()
        {
            UserId = entity.UserId,
            UserName = entity.UserName,
            Email = entity.Email
        };
    }
    
}