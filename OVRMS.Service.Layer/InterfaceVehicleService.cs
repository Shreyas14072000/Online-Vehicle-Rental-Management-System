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

        IList<Customers> CustomersList();

        void RegisterNewCustomer(Customers customers);

        void AddBookingRequest(BookingDetails bookingDetails);

        void UpdateBookingDetails(BookingDetails UpdateBooking);
        IList<BookingDetails> BookingDetailsList();

        void ApproveBooking(BookingDetails Approvebooking);

        void DeleteBookingDetails(int BookingId);

        void Payment(Payment payment);

        IList<Payment> PaymentList();
    }
}
