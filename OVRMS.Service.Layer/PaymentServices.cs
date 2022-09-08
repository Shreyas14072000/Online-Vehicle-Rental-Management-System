using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.RepositoryLayer;
using OVRMS.DomainLayer.Models;

namespace OVRMS.ServiceLayer
{
    public class PaymentServices : InterfacePaymentService
    {
        public OVRMSDBContext OVRMSDBContext;

        public PaymentServices(OVRMSDBContext ovrmsdbcontext)
        {
            this.OVRMSDBContext = ovrmsdbcontext;
        }
        public IList<Payment> PaymentList()
        {
            return OVRMSDBContext.Set<Payment>().ToList();
        }
        public void MakePayment(Payment MakePayment)
        {
            OVRMSDBContext.Add<Payment>(MakePayment);
            OVRMSDBContext.SaveChanges();

        }
    }
}
