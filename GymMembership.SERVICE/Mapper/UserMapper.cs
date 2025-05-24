using GymMembership.DATA.Entities;
using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.SERVICE.Mapper;

public static class UserMapper
{ 
    //we need UserRolesMapping method
    public static Task<List<GymClassModel>> GymClassModelMapping(this GymClass entity)
    {
        var list = new List<GymClassModel>()
        {
            new GymClassModel()
            {
                GymClassId = entity.GymClassId,
                GymClassName = entity.GymClassName,
            }
        };
        return Task.FromResult(list);
    }

    public static Task<List<UserRolesModel>> UserRolesMapping(this User entity)
    {
        var list = new List<UserRolesModel>()
        {
            new UserRolesModel()
            {
                UserId = entity.UserId,
                UserName = entity.UserName,
                Email = entity.Email
            }
        };
        return Task.FromResult(list);

    }
}