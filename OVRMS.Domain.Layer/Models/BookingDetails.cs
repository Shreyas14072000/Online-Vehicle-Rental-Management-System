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
        public int BookingId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }

        public int Amount { get; set; }

        public Boolean IsApproved { get; set; }
    }
}
