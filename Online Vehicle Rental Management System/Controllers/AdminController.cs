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
    public class AdminController : ControllerBase
    {
        private readonly InterfaceBookingService BookingServices;
        private readonly InterfaceCustomerService CustomerServices;
        private readonly InterfacePaymentService PaymentServices;
        private readonly InterfaceVehicleService VehicleServices;
        private readonly InterfaceAdminService AdminServices;
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration config;


        public AdminController(InterfaceBookingService BookingServices, ILogger<AdminController> logger, IConfiguration config, InterfaceCustomerService CustomerServices, InterfacePaymentService PaymentServices, InterfaceVehicleService VehicleServices, InterfaceAdminService AdminServices)
        {
            _logger = (ILogger<AdminController>)logger;
            _logger.LogInformation("Admin");
            this.BookingServices = BookingServices;
            this.AdminServices = AdminServices;
            this.CustomerServices = CustomerServices;
            this.PaymentServices = PaymentServices;
            this.VehicleServices = VehicleServices;
            this.config = config;
        }
        [HttpPost(nameof(AdminRegistration))]
        public ActionResult AdminRegistration(Admin AdminRegistration)
        {
            try
            {
                
                AdminServices.AdminRegistration(AdminRegistration);

                return Ok("Admin Registered");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpPost(nameof(AddVehicles))]
        public ActionResult AddVehicles(Vehicles AddVehicles)
        {
            try
            {
               
                VehicleServices.AddVehicles(AddVehicles);

                return Ok("New Vehicle Added");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpPut(nameof(UpdateVehicleAvailability))]
        public ActionResult UpdateVehicleAvailability(Vehicles UpdateVehicleAvailability)
        {
            try
            {
                VehicleServices.UpdateVehicleAvailability(UpdateVehicleAvailability);

                return Ok("Vehicle Updated");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpDelete(nameof(DeleteVehicles))]
        public ActionResult DeleteVehicles(int VehicleId)
        {
            try
            {
                VehicleServices.DeleteVehicles(VehicleId);

                return Ok("Vehicle Deleted");

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");
        }
        [HttpGet(nameof(CustomersList))]
        public ActionResult CustomersList()
        {
            try
            {
                var customers = CustomerServices.CustomersList();
                if (customers != null)
                {
                    return Ok(customers);
                }
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
        [HttpGet(nameof(PaymentList))]
        public ActionResult PaymentList()
        {
            try
            {
                var Payment = PaymentServices.PaymentList();
                if (Payment != null)
                {
                    return Ok(Payment);
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
