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

        public string VehicleName { get; set; }
        public string VehicleCompany { get; set; }
        public string VehicleType { get; set; }

        public int AvgRatePerDay { get; set; }

        public int Rating { get; set; }

        public Boolean Availability { get; set; }
    }
}
