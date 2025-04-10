using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GymMembership.DATA.Entities
{
    public class GymClass
    {
        [Key]
        public int GymClassId { get; set; }
        [Required]
        public string? GymClassName { get; set; } //Add seeding for GymClassName (wrestling, judo, karate, boxing)
    }
}
