using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.RepositoryLayer;
using OVRMS.DomainLayer.Models;

namespace OVRMS.ServiceLayer
{
    public interface InterfaceBookingService
    {
        void AddBookingRequest(BookingDetails BookingDetails);

        IList<BookingDetails> BookingDetailsList();

        void ApproveBooking(BookingDetails ApproveBooking);

        void DeleteBookingDetails(int BookingId);
    }
}
