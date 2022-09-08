using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.RepositoryLayer;
using OVRMS.DomainLayer.Models;

namespace OVRMS.ServiceLayer
{
    public class VehicleServices : InterfaceVehicleService
    {
        public OVRMSDBContext OVRMSDBContext;

        public VehicleServices(OVRMSDBContext ovrmsdbcontext)
        {
            this.OVRMSDBContext = ovrmsdbcontext;
        }
        public IList<Vehicles> VehiclesList()
        {
            return OVRMSDBContext.Set<Vehicles>().ToList();
        }

        public void AddVehicles(Vehicles AddVehicles)
        {
            OVRMSDBContext.Add<Vehicles>(AddVehicles);
            OVRMSDBContext.SaveChanges();

        }
        void InterfaceVehicleService.UpdateVehicleAvailability(Vehicles UpdateVehicleAvailability)
        {
            OVRMSDBContext.Update<Vehicles>(UpdateVehicleAvailability);
            OVRMSDBContext.SaveChanges();

        }
        public void DeleteVehicles(int VehicleId)
        {
            Vehicles DeleteVehicles = Vehicles(VehicleId);
            if (DeleteVehicles != null)
            {
                OVRMSDBContext.Remove<Vehicles>(DeleteVehicles);
                OVRMSDBContext.SaveChanges();
            }

        }
        private Vehicles Vehicles(int VehicleId)
        {
            return OVRMSDBContext.Find<Vehicles>(VehicleId);
        }
    }
}
