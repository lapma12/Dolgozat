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
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, result = "" });
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

        [HttpPut]
        public IActionResult UpdateComputer(int id,UpdateComputerDto comp)
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var existingComp = context.Computers.FirstOrDefault(c => c.Id == id);
                    if (existingComp != null)
                    {
                        existingComp.Brand = comp.Brand;
                        existingComp.Type = comp.Type;
                        existingComp.Display = comp.Display;
                        existingComp.Memory = comp.Memory;
                        existingComp.UpdateTime = DateTime.Now;

                        context.SaveChanges();
                        return Ok(new { message = "Computer frissítve sikeresen", result = existingComp });
                    }
                    return NotFound(new { message = "Nincs computer", result = "" });
                }
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Hiba az adatbázis művelet során", result = "" });
            }
        }
        [HttpDelete]

        public IActionResult DeleteComputer(int id) 
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var comp = context.Computers.FirstOrDefault(c => c.Id == id);
                    if (comp != null)
                    {
                        context.Computers.Remove(comp);
                        context.SaveChanges();
                        return Ok(new { message = "Computer törölve sikeresen", result = comp });
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
