using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.RepositoryLayer;
using OVRMS.DomainLayer.Models;

namespace OVRMS.ServiceLayer
{
    public interface InterfaceVehicleService
    {
        IList<Vehicles> VehiclesList();
        void UpdateVehicleAvailability(Vehicles UpdateVehicleAvailability);

        void AddVehicles(Vehicles AddVehicles);
        void DeleteVehicles(int VehicleId);
    }
}
