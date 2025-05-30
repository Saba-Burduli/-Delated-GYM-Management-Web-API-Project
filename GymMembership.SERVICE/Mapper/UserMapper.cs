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
   public static Task<AuthResponseModel> UserRegistrationAsync(int? roleld, RegisterUserModel model)
   {
       var person = new Person()
       {
           FirstName = model.Person.FirstName,
           LastName = model.Person.LastName,
           Phone = model.Person.Phone,
           Address = model.Person.Address
       };
       
       return Task.FromResult(new AuthResponseModel { Success = true, Message = "Person Mapping Created" });
   }
   /*
    *
    *public class Person
    {
        [Key]
        public int PersonId { get; set; }
        
        [Required]
        [MaxLength(20, ErrorMessage = "FistName is more than 20 letter")]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "LastName is more than 30 letter")]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Phone number is more than 20 letter")]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "address is more than 50 letter")]
        public string? Address { get; set; }

        //Relations :

        //Person => User ; One to One ; (Person) => (User) but We can do One to Many(like Person can Have Many Users)   
        public virtual User? User { get; set; }
    }
}
    * 
    */ 

}