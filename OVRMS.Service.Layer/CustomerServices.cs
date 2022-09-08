using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.RepositoryLayer;
using OVRMS.DomainLayer.Models;

namespace OVRMS.ServiceLayer
{
    public class CustomerServices : InterfaceCustomerService
    {
        public OVRMSDBContext OVRMSDBContext;

        public CustomerServices(OVRMSDBContext ovrmsdbcontext)
        {
            this.OVRMSDBContext = ovrmsdbcontext;
        }

        public IList<Customers> CustomersList()
        {
            return OVRMSDBContext.Set<Customers>().ToList();
        }

        public void RegisterNewCustomer(Customers customers)
        {
            OVRMSDBContext.Add<Customers>(customers);
            OVRMSDBContext.SaveChanges();

        }

    }
}
