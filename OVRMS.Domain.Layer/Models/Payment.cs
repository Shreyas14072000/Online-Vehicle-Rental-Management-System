using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVRMS.DomainLayer.Models
{
    public class Payment
    {
        [Key]
        
        public int PaymentId { get; set; }
        [Required]
        public int BookingId { get; set; }
        public string PaymentMethod { get; set; }
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        
    }
}
