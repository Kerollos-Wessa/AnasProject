﻿using AnasProject.DTOS;
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

        [HttpPut("Update")]
        public IActionResult UpdateVechile(int vehicleId, VehicleDTO vehicleDTO)
        {
            if (ModelState.IsValid)
            {

                Vehicle  vehicle = vehicleRepo.GetById(vehicleId);

                vehicle.VehicleNumber = vehicleDTO.VehicleNumber;
                vehicle.VehicleType = vehicleDTO.VehicleType;

                //DriverName = driverDTO.DriverName
                //PhoneNumber = driverDTO.PhoneNumber

                vehicleRepo.Update(vehicle);
                vehicleRepo.Save();
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["VehicleId"] = vehicle.VehicleId.ToString(),
                    ["VehicleNumber"] = vehicle.VehicleNumber.ToString(),
                    ["VehicleType"] = vehicle.VehicleType.ToString()
                };
                var response = new
                {
                    gvar = gvar
                };

                // Return the wrapped response
                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteVehicle(long vehicleId)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle  = vehicleRepo.GetById(vehicleId);
                //driver.DriverName = driverDTO.DriverName;
                //driver.PhoneNumber = driverDTO.PhoneNumber;

                vehicle.IsDeleted = true;
                vehicleRepo.Update(vehicle);
                vehicleRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["VehicleId"] = vehicle.VehicleId.ToString(),
                    ["VehicleNumber"] = vehicle.VehicleNumber.ToString(),
                    ["VehicleType"] = vehicle.VehicleType.ToString()
                };
                var response = new
                {
                    gvar = gvar
                };

                // Return the wrapped response
                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");

        }



        // GET: api/drivers/all
        [HttpGet("all")]
        public IActionResult GetAllDrivers()
        {
            var vehicles = vehicleRepo.GetAll();
            var dataTable = new DataTable("Vehicles");
            dataTable.Columns.Add("VehicleId", typeof(long));
            dataTable.Columns.Add("VehicleNumber", typeof(long));
            dataTable.Columns.Add("VehicleType", typeof(string));

            foreach (var vehicle in vehicles)
            {
                dataTable.Rows.Add(vehicle.VehicleId, vehicle.VehicleNumber, vehicle.VehicleType);
            }

            var gvar = new GVAR();
            gvar.AddDataTable("Vehicles", dataTable);

            // Wrap the GVAR object into a response structure
            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }

    }
}
