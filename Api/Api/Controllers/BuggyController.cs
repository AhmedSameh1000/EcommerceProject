using Api.Errors;
using InfraStructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly AppDbContext appDbContext;

        public BuggyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("NotFound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = appDbContext.Products.Find(50);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("ServerError")]
        public IActionResult GetServerError()
        {
            var thing = appDbContext.Products.Find(50);
            var thingtoReturn = thing.ToString();
            return Ok();
        }
        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));

        }
        [HttpGet("BadRequest/{id}")]
        public IActionResult GetNotFound(int id)
        {
            return Ok();
        }
    }
}
