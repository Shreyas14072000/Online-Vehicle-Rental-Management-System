using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVRMS.DomainLayer.Models
{
    public class BookingDetails
    {
        [Key]
        [Required]
        public int BookingId { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }
        [Range(1, int.MaxValue)]


        public int Amount { get; set; }

        public Boolean IsApproved { get; set; }
    }
}
