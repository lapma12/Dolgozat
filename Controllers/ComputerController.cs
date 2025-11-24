using Dolgozat.Models;
using Dolgozat.Models.DtoS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dolgozat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        [HttpPost]

        public IActionResult AddComputer(AddCompuerDto comp)
        {
            try
            {
                var newComp = new Computer
                {
                    Brand = comp.Brand,
                    Type = comp.Type,
                    Display = comp.Display,
                    Memory = comp.Memory
                };
                using var context = new ComputerDbContext();
                {
                    if (newComp != null)
                    {
                        context.Computers.Add(newComp);
                        context.SaveChanges();
                        return StatusCode(201, new { message = "Computer added successfully", result = newComp });
                    }
                    return NotFound(new { message = "Nincs computer", result = "" });
                }
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Hiba az adatbázis művelet során", result = "" });
            }

        }
    }
}
