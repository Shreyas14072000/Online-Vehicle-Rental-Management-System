using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVRMS.DomainLayer.Models
{
    public class Customers
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }
        [Required]

        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        
        public long MobileNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
