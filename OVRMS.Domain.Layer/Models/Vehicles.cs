using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVRMS.DomainLayer.Models
{
    public class Vehicles
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        public string VehicleName { get; set; }
        [Required]
        public string VehicleCompany { get; set; }
        [Required]
        public string VehicleType { get; set; }
        [Range(1,int.MaxValue)]

        public int AvgRatePerDay { get; set; }
        [Range(1, int.MaxValue)]

        public int Rating { get; set; }

        public Boolean Availability { get; set; }
    }
}
