using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundError()
        {
            var response = _context.Products.Find(42);
            if(response == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(response);
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var response = _context.Products.Find(42);
            response.ToString();
            return Ok(response);
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(401));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }

    }
}