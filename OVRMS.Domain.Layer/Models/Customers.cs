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
        public int CustomerId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public long MobileNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
