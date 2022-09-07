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
    public class CustomersController : ControllerBase
    {

        private readonly InterfaceVehicleService VehicleServices;
        private readonly ILogger<CustomersController> _logger;
        private readonly OVRMSDBContext _context;
        private readonly IConfiguration config;

        public CustomersController(OVRMSDBContext context,
            IConfiguration config)
        {
            _context = context;
            this.config = config;
        }

        public CustomersController(InterfaceVehicleService VehicleServices, ILogger<CustomersController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Customer Added");
            this.VehicleServices = VehicleServices;
        }
        [HttpPost(nameof(RegisterNewCustomer))]
        public ActionResult RegisterNewCustomer(Customers customers)
        {
            try
            {
                VehicleServices.RegisterNewCustomer(customers);

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
                VehicleServices.AddBookingRequest(BookingDetails);

                return Ok("Booking Requested");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
    }
}
