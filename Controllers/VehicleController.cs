using AnasProject.DTOS;
using AnasProject.Repos.DriverRepository;
using AnasProject.Repos.VehicleRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepo vehicleRepo;

        public VehicleController(IVehicleRepo vehicleRepo)
        {
            this.vehicleRepo = vehicleRepo;
        }

        [HttpPost("add")]
        public IActionResult AddVechile([FromBody] VehicleDTO vehicleDTO)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle = new Vehicle()
                {
                    VehicleNumber = vehicleDTO.VehicleNumber,
                    VehicleType = vehicleDTO.VehicleType,
                };
                // Add the driver to the database
                vehicleRepo.Insert(vehicle);
                vehicleRepo.Save();

                // Create a GVAR object and populate the DicOfDic with driver data
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["VehicleId"] = vehicle.VehicleId.ToString(),
                    ["VehicleNumber"] = vehicle.VehicleNumber.ToString(),
                    ["VehicleType"] = vehicle.VehicleType.ToString()
                };

                // Wrap the GVAR object into a response structure
                var response = new
                {
                    gvar = gvar
                };

                // Return the wrapped response
                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");

        }

        [HttpGet("all-vehicles")]
        public IActionResult GetAllVehicles()
        {
            var vehiclesData = vehicleRepo.GetAllVehiclesData();

            // Convert list to a dictionary of dictionaries
            var result = new Dictionary<string, List<Dictionary<string, object>>>
            {
                ["Vehicles"] = vehiclesData.Select(v => new Dictionary<string, object>
            {
                { "VehicleId", v.VehicleId },
                { "VehicleNumber", v.VehicleNumber },
                { "VehicleType", v.VehicleType },
                { "LastDirection", v.LastDirection },
                { "LastStatus", v.LastStatus },
                { "LastAddress", v.LastAddress },
                { "LastLatitude", v.LastLatitude },
                { "LastLongitude", v.LastLongitude }
            }).ToList()
            };

            return Ok(result);
        }


    }
}
