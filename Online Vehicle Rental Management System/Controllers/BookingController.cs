using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OVRMS.ServiceLayer;
using OVRMS.DomainLayer.Models;
using Microsoft.Extensions.Logging;
using OVRMS.RepositoryLayer;
using Microsoft.Extensions.Configuration;

namespace Online_Vehicle_Rental_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {


        private readonly InterfaceBookingService BookingServices;
        private readonly ILogger<BookingController> _logger;
        private readonly IConfiguration config;


        public BookingController(InterfaceBookingService BookingServices, ILogger<BookingController> logger, IConfiguration config)
        {
            _logger = (ILogger<BookingController>)logger;
            _logger.LogInformation("Booking");
            this.BookingServices = BookingServices;
            this.config = config;
        }

        [HttpPost(nameof(AddBookingRequest))]
        public ActionResult AddBookingRequest(BookingDetails BookingDetails)
        {
            try
            {
                BookingServices.AddBookingRequest(BookingDetails);

                return Ok("Booking Requested");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpPut(nameof(ApproveBooking))]
        public ActionResult ApproveBooking(BookingDetails ApproveBooking)
        {
            try
            {
                BookingServices.ApproveBooking(ApproveBooking);

                return Ok("Booking Approved");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpDelete(nameof(DeleteBookingDetails))]
        public ActionResult DeleteBookingDetails(int BookingId)
        {
            try
            {
                BookingServices.DeleteBookingDetails(BookingId);

                return Ok("Booking Deleted");

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");
        }
        [HttpGet(nameof(BookingDetailsList))]
        public ActionResult BookingDetailsList()
        {
            try
            {
                var BookingDetails = BookingServices.BookingDetailsList();
                if (BookingDetails != null)
                {
                    return Ok(BookingDetails);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }

            return BadRequest("Not found");
        }


    }
}
