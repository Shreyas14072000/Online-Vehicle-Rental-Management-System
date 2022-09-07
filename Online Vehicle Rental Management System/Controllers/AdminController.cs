using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OVRMS.ServiceLayer;
using OVRMS.DomainLayer.Models;
using Microsoft.Extensions.Logging;

namespace Online_Vehicle_Rental_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly InterfaceVehicleService VehicleServices;
        private readonly ILogger<AdminController> _logger;

        public AdminController(InterfaceVehicleService VehicleServices, ILogger<AdminController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Vehicle Added");
            this.VehicleServices = VehicleServices;
        }

        [HttpGet(nameof(CustomersList))]
        public ActionResult CustomersList()
        {
            try
            {
                var customers = VehicleServices.CustomersList();
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
        [HttpGet(nameof(BookingDetailsList))]
        public ActionResult BookingDetailsList()
        {
            try
            {
                var BookingDetails = VehicleServices.BookingDetailsList();
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
    }
}
