using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.RepositoryLayer;
using OVRMS.DomainLayer.Models;

namespace OVRMS.ServiceLayer
{
    public class BookingServices : InterfaceBookingService
    {
        public OVRMSDBContext OVRMSDBContext;

        public BookingServices(OVRMSDBContext ovrmsdbcontext)
        {
            this.OVRMSDBContext = ovrmsdbcontext;
        }
        public IList<BookingDetails> BookingDetailsList()
        {
            return OVRMSDBContext.Set<BookingDetails>().ToList();
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
        public void AddBookingRequest(BookingDetails BookingDetails)
        {
            OVRMSDBContext.Add<BookingDetails>(BookingDetails);
            OVRMSDBContext.SaveChanges();

        }
        public void ApproveBooking(BookingDetails ApproveBooking)
        {
            OVRMSDBContext.Update<BookingDetails>(ApproveBooking);
            OVRMSDBContext.SaveChanges();

        }
    }
}
