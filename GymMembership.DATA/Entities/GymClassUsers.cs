using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.DATA.Entities
{
    [Table("GymClassUsers")]
    public class GymClassUsers
    {
        [Key]
        public int GymClassUsersId { get; set; } //Id in Dachis Project

        //Relations:
        //GymClassUsers => GymClass ; many to one ; (GymClassUsers) => (GymClass)
        [ForeignKey("GymClass")]
        public int GymClassId { get; set; }
        public virtual GymClass? GymClass { get; set; }

        //GymClassUsers => User ; One to Many ; (GymClassUsers) => (User)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; } // we gonna change this (Saba Check PDF)
        
    }
}
