using Dolgozat.Models;
using Dolgozat.Models.DtoS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dolgozat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddNewOS(AddOsDto os)
        {
            try
            {
                var newOs = new Os
                {
                    Name = os.Name,
                    ComputerId = os.ComputerId
                };
                using (var context = new ComputerDbContext())
                {
                    if (newOs != null)
                    {
                        context.Os.Add(newOs);
                        context.SaveChanges();
                        return StatusCode(201, new { message = "Computer added successfully", result = newOs });
                    }
                    return NotFound(new { message = "Nincs computer", result = "" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, result = "" });
            }
        }

        [HttpGet]

        public IActionResult GetAllOs()
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var osList = context.Os.ToList();
                    if (context != null)
                    {
                        return Ok(new { message = "Operációs rendszerek lekérve sikeresen", result = osList });
                    }
                }
                return NotFound(new { message = "Nincs operációs rendszer", result = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, result = "" });
            }
        }
    }
}
