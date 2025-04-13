using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;







namespace GymMembership.DATA.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string? RoleName { get; set; } //add seeding in there (Admin, Trainer, Member)
        
        //Relations:

        //We Have To Add some ICollection to Users
        
    }
}
