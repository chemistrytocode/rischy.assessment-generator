using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace rischy.assessment_generator.Controllers
{
    [ApiController]
    [Route("/liveness")]
    public class HealthCheckController : Controller
    {
        // GET
        [HttpGet(Name = "Liveness")]
        public string Get()
        {
            return "The rishy.assessment-generator is ready to go!";
        }
    }
}