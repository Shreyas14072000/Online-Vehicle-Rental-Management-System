using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.RepositoryLayer;
using OVRMS.DomainLayer.Models;

namespace OVRMS.ServiceLayer
{
    public interface InterfaceCustomerService
    {
        IList<Customers> CustomersList();

        void RegisterNewCustomer(Customers customers);

    }
}
