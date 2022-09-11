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

        
        private readonly InterfaceCustomerService CustomerServices;
        private readonly ILogger<CustomersController> _logger;
        private readonly IConfiguration config;


        public CustomersController(ILogger<CustomersController> logger, IConfiguration config, InterfaceCustomerService CustomerServices)
        {
            _logger = logger;
            _logger.LogInformation("Customer");
            this.CustomerServices = CustomerServices;
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
    }
}
