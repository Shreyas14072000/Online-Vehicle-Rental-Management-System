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
    public class VehicleController : ControllerBase
    {
        private readonly InterfaceVehicleService VehicleServices;
        private readonly ILogger<VehicleController> _logger;
        private readonly IConfiguration config;


        public VehicleController(InterfaceVehicleService VehicleServices, ILogger<VehicleController> logger, IConfiguration config)
        {
            _logger = (ILogger<VehicleController>)logger;
            _logger.LogInformation("Vehicles");
            this.VehicleServices = VehicleServices;
            this.config = config;
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
    }
}
