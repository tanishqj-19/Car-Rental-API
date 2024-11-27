
using CarRentalSystemAPI.Models;
using CarRentalSystemAPI.Repositories;
using CarRentalSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;

namespace CarRentalSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly ICarRepository carRepository;
        private readonly ICarRentalService carRentalService;

        public CarController(ICarRepository carRepository, ICarRentalService carRentalService)
        {
            this.carRentalService = carRentalService;
            this.carRepository = carRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            var availableCars = await carRepository.GetAvailableCars();

            return Ok(availableCars.AsEnumerable());
        }

        [HttpGet("{id}")]


        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var currCar = await carRepository.GetCarById(id);
            if (currCar == null)
            {
                return BadRequest("Car doesn't exist");
            }
            return Ok(currCar);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddCar(Car newCar)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await carRepository.AddCar(newCar);

            return CreatedAtAction(nameof(GetCarById), new { id = newCar.Id }, newCar);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateCar(int id, Car newCar)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await carRepository.UpdateCarAvailability(id, newCar);
                return CreatedAtAction(nameof(GetCarById), new { id = newCar.Id }, newCar);

            } catch (Exception ex) {
                return BadRequest(new { Message = "Car can't be updated", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteCar(int id)
        {

            try
            {
                await carRepository.DeleteCarById(id);
                return Content("Car deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("rent/{carId}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> RentCar(int carId,int userId, int rentalDays)
        {
            try
            {
                
                var totalCost = await carRentalService.RentCar(carId, userId, rentalDays);
                return Ok($"Successfully rented the car for ${rentalDays} with total cost of ${totalCost}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        




    }
}
