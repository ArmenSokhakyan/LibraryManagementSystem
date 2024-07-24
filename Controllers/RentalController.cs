using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = _rentalService.GetRentalByIdAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult<Rental>> AddRental(Rental rental)
        {
            await _rentalService.AddRentalAsync(rental);
            return CreatedAtAction(nameof(GetRental), new { id = rental.Id }, rental);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(int id, Rental rental) 
        {
            if (id != rental.Id)
            {
                return BadRequest();    
            }

            await _rentalService.UpdateRentalAsync(rental);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id) 
        {
            await _rentalService.DeleteRentalAsync(id);
            return NoContent();
        }

    }
}
