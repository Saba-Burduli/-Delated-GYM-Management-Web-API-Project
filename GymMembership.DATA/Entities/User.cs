using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.DATA.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(30,ErrorMessage = "UserName is more than 30 letter")]
        public string? UserName { get; set; }

        [Required]
        public string? PasswordHash { get; set; }
        
        [Required]
        public string? Email { get; set; }
        
        public DateTime RegistrationDate { get; set; } = DateTime.Now;


        //Relations:
        //User =>Person ; one to one ; (user) => (person)
        [ForeignKey("Person")]
        public int PersonId { get; set; }


    }
}
