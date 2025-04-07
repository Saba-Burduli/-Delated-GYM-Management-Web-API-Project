using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.DATA.Entities
{
    public class Membership
    {
        [Key]
        public int MembershipId { get; set; }


        
        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow; //we gonna test it now .. if it works i shouldnt add DateTime.Now
        
        [Required]
        public DateTime EndDate { get; set; } = DateTime.UtcNow; //we gonna test it now .. if it works i shouldnt add DateTime.Now
        
        [Required]
        public bool IsActive { get; set; }

        //Relations:
        //Membership => MembershipType ; one to one ; (Membership) => (MembershipType)
        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }
        public virtual MembershipType? MembershipType { get; set; }

        //Membership => User ; one to one ; (Membership) => (User)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
