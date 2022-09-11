using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.RepositoryLayer;
using OVRMS.DomainLayer.Models;

namespace OVRMS.ServiceLayer
{
    public class AdminServices : InterfaceAdminService
    {
        public OVRMSDBContext OVRMSDBContext;

        public AdminServices(OVRMSDBContext ovrmsdbcontext)
        {
            this.OVRMSDBContext = ovrmsdbcontext;
        }
        public void AdminRegistration(Admin AdminRegistration)
        {
            OVRMSDBContext.Add<Admin>(AdminRegistration);
            OVRMSDBContext.SaveChanges();

        }
    }
}
