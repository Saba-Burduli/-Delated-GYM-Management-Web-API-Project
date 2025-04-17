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
        [MaxLength(30, ErrorMessage = "UserName is more than 30 letter")]
        public string? UserName { get; set; }

        
        [Required]
        public string? PasswordHash { get; set; }

        [Required]
        public string? Email { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        //We have To Create RoleUser Class Using Configuration

        //Relations:

        //User =>Person ; one to one ; (user) => (person)
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public virtual Person? Person { get; set; }

        //User => Membership ; One to Many ; (User) => (Membership)
        public virtual ICollection<Membership>? Memberships { get; set; }

        //User => GymClassUsers ; One to Many ;(User) => (GymClassUsers)
        public virtual ICollection<GymClassUsers>? GymClassUsers { get; set; }

        //We have To add more ICollection Relation()..
    }
}
