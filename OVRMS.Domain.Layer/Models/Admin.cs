using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVRMS.DomainLayer.Models
{
    public class Admin
    {
       [Key]
        [Required]
        public string AdminName { get; set; }
        [Required]
        public string Password { get; set; }
        public long PhoneNo { get; set; }

        public string Email { get; set; }
    }
}
