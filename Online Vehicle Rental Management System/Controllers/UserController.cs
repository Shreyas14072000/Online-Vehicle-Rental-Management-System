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
    public class UserController : ControllerBase
    {
        private readonly InterfaceBookingService BookingServices;
        private readonly InterfaceCustomerService CustomerServices;
        private readonly InterfacePaymentService PaymentServices;
        private readonly InterfaceVehicleService VehicleServices;
        private readonly InterfaceAdminService AdminServices;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration config;


        public UserController(InterfaceBookingService BookingServices, ILogger<UserController> logger, IConfiguration config, InterfaceCustomerService CustomerServices, InterfacePaymentService PaymentServices, InterfaceVehicleService VehicleServices, InterfaceAdminService AdminServices)
        {
            _logger = (ILogger<UserController>)logger;
            _logger.LogInformation("User");
            this.BookingServices = BookingServices;
            this.AdminServices = AdminServices;
            this.CustomerServices = CustomerServices;
            this.PaymentServices = PaymentServices;
            this.VehicleServices = VehicleServices;
            this.config = config;
        }
        [HttpPost(nameof(RegisterNewCustomer))]
        public ActionResult RegisterNewCustomer(Customers customers)
        {
            try
            {
                
                CustomerServices.RegisterNewCustomer(customers);

                return Ok("New Customer Registered");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        [HttpGet(nameof(VehiclesList))]
        public ActionResult VehiclesList()
        {
            try
            {
                var vehicles = VehicleServices.VehiclesList();
                if (vehicles != null)
                {
                    return Ok(vehicles);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }

            return BadRequest("Not found");
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
        [HttpPost(nameof(MakePayment))]
        public ActionResult MakePayment(Payment MakePayment)
        {
            try
            {
                PaymentServices.MakePayment(MakePayment);

                return Ok("Payment Processed");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
    }
}
