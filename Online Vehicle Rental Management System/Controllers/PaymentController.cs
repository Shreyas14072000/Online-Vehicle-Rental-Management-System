using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OVRMS.ServiceLayer;
using OVRMS.DomainLayer.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Online_Vehicle_Rental_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        
        private readonly InterfacePaymentService PaymentServices;
        private readonly ILogger<PaymentController> _logger;
        private readonly IConfiguration config;

        public PaymentController(ILogger<PaymentController> logger, IConfiguration config, InterfacePaymentService PaymentServices)
        {
            _logger = logger;
            _logger.LogInformation("Payment");
            this.PaymentServices = PaymentServices;
            this.config = config;
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
