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

        [HttpGet]
        public IActionResult GetComputers()
        {
            try
            {
                using var context = new ComputerDbContext();
                {
                    var computers = context.Computers.ToList();
                    if (computers != null)
                    {
                        return Ok(new { message = "Computerek lekérve sikeresen", result = computers });
                    }
                    return NotFound(new { message = "Nincs computer", result = "" });
                }
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Hiba az adatbázis művelet során", result = "" });
            }
        }

        [HttpGet("byId")]
        public IActionResult GetCompuetById(int id)
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var comp = context.Computers.FirstOrDefault(c => c.Id == id);
                    if (comp != null)
                    {
                        return Ok(new { message = "Computer lekérve sikeresen", result = comp });
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
