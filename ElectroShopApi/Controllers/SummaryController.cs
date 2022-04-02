﻿using System;
using System.Net;
using ElectroShopApi.Requests.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ElectroShopApi.Controllers
{
    [Route("summary")]
    public class SummaryController : ControllerBase
    {

        private readonly SummaryService _summaryService;

        public SummaryController(SummaryService summaryService)
        {
            _summaryService = summaryService;
        }

        // GET /summary
        [HttpGet]
        public IActionResult Get([FromQuery] Guid cartId)
        {
            try
            {
                return new JsonResult(_summaryService.GetCartSummary(cartId));
            }
            catch (NullReferenceException)
            {
                return new NotFoundObjectResult("There is no cart with this ID");
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST /summary/completion
        [Route("completion")]
        [HttpPost]
        public IActionResult PostCompletion([FromBody] CompleteCartRequest request)
        {
            try
            {
                var paymentRequirment = _summaryService.GetPaymentRequirment(request.CartId);
                return new JsonResult(paymentRequirment);
            }
            catch (NullReferenceException)
            {
                return new NotFoundObjectResult("There is no cart with this ID");
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST /summary/payment
        [Route("payment")]
        [HttpPost]
        public IActionResult PostPayment([FromBody] CartPaymentRequest request)
        {
            try
            {
                _summaryService.FinalizeCart(request.CartId);
                return new OkResult();
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
