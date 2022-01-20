using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EccomerceSS.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError($"The path{exceptionDetails.Path} threw an exception {exceptionDetails.Error}");
            return View("Error");
        }
        [Route("/Error/{statuscode}")]
        public IActionResult HttpHandler(int statuscode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statuscode)
            {
                case 404:
                    ViewBag.Message = "The request made can't be executed because doesn't exists";
                    _logger.LogWarning($"404 error ocurred path {statusCodeResult.OriginalPath}");
                    break;

            }
            return View("Notfound");
        }
    }
}
