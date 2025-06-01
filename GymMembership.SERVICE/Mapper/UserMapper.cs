using System.Net.Http.Headers;
using GymMembership.DATA.Entities;
using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE;
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
    
    // this is UserRegistationAsync Mapping in Mapping Directorie
   public static async Task<Person> UserRegistrationAsync(int? roleld, RegisterUserModel model)
   {
       var person = new Person()
       {
           FirstName = model.Person.FirstName,
           LastName = model.Person.LastName,
           Phone = model.Person.Phone,
           Address = model.Person.Address
       };
       
       return await Task.FromResult(person);
   }
}