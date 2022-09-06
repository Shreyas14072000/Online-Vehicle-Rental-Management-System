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

        public IList<Customers> CustomersList()
        {
            return OVRMSDBContext.Set<Customers>().ToList();
        }

        public IList<BookingDetails> BookingDetailsList()
        {
            return OVRMSDBContext.Set<BookingDetails>().ToList();
        }

        public IList<Payment> PaymentList()
        {
            return OVRMSDBContext.Set<Payment>().ToList();
        }

        void InterfaceVehicleService.UpdateBookingDetails(BookingDetails UpdateBooking)
        {
            OVRMSDBContext.Update<BookingDetails>(UpdateBooking);
            OVRMSDBContext.SaveChanges();

        }
        public void DeleteBookingDetails(int BookingId)
        {
            BookingDetails BookingDetails = GetBookingDetails(BookingId);
            if (BookingDetails != null)
            {
                OVRMSDBContext.Remove<BookingDetails>(BookingDetails);
                OVRMSDBContext.SaveChanges();
            }

        }
        private BookingDetails GetBookingDetails(int BookingId)
        {
            return OVRMSDBContext.Find<BookingDetails>(BookingId);
        }
        public void RegisterNewCustomer(Customers customers)
        {
            OVRMSDBContext.Add<Customers>(customers);
            OVRMSDBContext.SaveChanges();

        }
        public void AddBookingRequest(BookingDetails BookingDetails)
        {
            OVRMSDBContext.Add<BookingDetails>(BookingDetails);
            OVRMSDBContext.SaveChanges();

        }
        public void ApproveBooking(BookingDetails ApproveBooking)
        {
            OVRMSDBContext.Add<BookingDetails>(ApproveBooking);
            OVRMSDBContext.SaveChanges();

        }
        public void MakePayment(Payment MakePayment)
        {
            OVRMSDBContext.Add<Payment>(MakePayment);
            OVRMSDBContext.SaveChanges();

        }

    }
}
