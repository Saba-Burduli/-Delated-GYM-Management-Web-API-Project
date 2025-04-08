using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.DATA.Entities
{

    [Table("Person")]
    public class Person
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
        [MaxLength(20,ErrorMessage ="Phone number is more than 20 letter")]
        public string? Phone { get; set; }
        
        [Required]
        [MaxLength(50,ErrorMessage ="address is more than 50 letter")]
        public string? Address { get; set; }
        
    }
}
