using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.DATA.Entities
{

    [Table("MembershipType")]
    public class MembershipType
    {
        [Key]
        public int MembershipTypeId { get; set; }
        [Required]
        public string? MembershipTypeName { get; set; } //Add seeding in there  (monthly, yearly, VIP)
        
    }
    
}
