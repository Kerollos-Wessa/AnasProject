using AnasProject.DTOS;
using AnasProject.Repos.VehicleInformationRepository;
using AnasProject.Repos.VehicleRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesInformationController : ControllerBase
    {

        private readonly IVehicleInformationRepo vehicleInformationRepo;

        public VehiclesInformationController(IVehicleInformationRepo vehicleInformationRepo)
        {
            this.vehicleInformationRepo = vehicleInformationRepo;
        }

        [HttpPost("add")]
        public IActionResult AddVechileInformation([FromBody] VehiclesInformationDTO vehiclesInformationDTO)
        {
            if (ModelState.IsValid)
            {
                VehiclesInformation vehiclesInformation = new VehiclesInformation()
                {
                    DriverId = vehiclesInformationDTO.DriverId,
                    VehicleId=vehiclesInformationDTO.VehicleId,
                    VehicleMake=vehiclesInformationDTO.VehicleMake,
                    PurchaseDate=vehiclesInformationDTO.PurchaseDate,
                    VehicleModel=vehiclesInformationDTO.VehicleModel
                    
                };
                // Add the driver to the database
                vehicleInformationRepo.Insert(vehiclesInformation);
                vehicleInformationRepo.Save();

                // Create a GVAR object and populate the DicOfDic with driver data
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverId"] = vehiclesInformation.DriverId.ToString(),
                    ["VehicleId"] = vehiclesInformation.VehicleId.ToString(),
                    ["VehicleMake"] = vehiclesInformation.VehicleMake,
                    ["PurchaseDate"] = vehiclesInformation.PurchaseDate.ToString(),
                    ["VehicleModel"] = vehiclesInformation.VehicleModel
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
        public IActionResult UpdateVechileInformation(int vehicleInformationId, VehiclesInformationDTO vehiclesInformationDTO)
        {
            if (ModelState.IsValid)
            {

                VehiclesInformation vehiclesInformation = vehicleInformationRepo.GetById(vehicleInformationId);

                vehiclesInformation.VehicleId = vehiclesInformationDTO.VehicleId;
                vehiclesInformation.DriverId = vehiclesInformationDTO.DriverId;
                vehiclesInformation.VehicleMake = vehiclesInformationDTO.VehicleMake;
                vehiclesInformation.VehicleModel = vehiclesInformationDTO.VehicleModel;
                vehiclesInformation.PurchaseDate = vehiclesInformationDTO.PurchaseDate;

                vehicleInformationRepo.Update(vehiclesInformation);
                vehicleInformationRepo.Save();
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverId"] = vehiclesInformation.DriverId.ToString(),
                    ["VehicleId"] = vehiclesInformation.VehicleId.ToString(),
                    ["VehicleMake"] = vehiclesInformation.VehicleMake,
                    ["PurchaseDate"] = vehiclesInformation.PurchaseDate.ToString(),
                    ["VehicleModel"] = vehiclesInformation.VehicleModel
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
        public IActionResult DeleteInformation(long vehicleInformationId)
        {
            if (ModelState.IsValid)
            {
                VehiclesInformation vehiclesInformation = vehicleInformationRepo.GetById(vehicleInformationId);
                //driver.DriverName = driverDTO.DriverName;
                //driver.PhoneNumber = driverDTO.PhoneNumber;

                vehiclesInformation.IsDeleted = true;
                vehicleInformationRepo.Update(vehiclesInformation);
                vehicleInformationRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverId"] = vehiclesInformation.DriverId.ToString(),
                    ["VehicleId"] = vehiclesInformation.VehicleId.ToString(),
                    ["VehicleMake"] = vehiclesInformation.VehicleMake,
                    ["PurchaseDate"] = vehiclesInformation.PurchaseDate.ToString(),
                    ["VehicleModel"] = vehiclesInformation.VehicleModel
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


        [HttpGet("vehicleInformation/{vehicleId}")]
        public IActionResult GetVehicleInformation(long vehicleId)
        {
            var vehicleDataInformation = vehicleInformationRepo.GetVehicleInformationData(vehicleId);

            var dataTable = new DataTable("VehicleInformation");
            dataTable.Columns.Add("VehicleNumber", typeof(long));
            dataTable.Columns.Add("VehicleType", typeof(string));
            dataTable.Columns.Add("DriverName", typeof(string));
            dataTable.Columns.Add("LastLatitude", typeof(double));
            dataTable.Columns.Add("LastLongitude", typeof(double));
            dataTable.Columns.Add("VehicleMake", typeof(string));
            dataTable.Columns.Add("VehicleModel", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));

            if (vehicleDataInformation != null)
            {
                dataTable.Rows.Add(vehicleDataInformation.VehicleNumber, vehicleDataInformation.VehicleType, vehicleDataInformation.DriverName, vehicleDataInformation.LastLatitude, vehicleDataInformation.LastLongitude, vehicleDataInformation.VehicleMake, vehicleDataInformation.VehicleModel, vehicleDataInformation.PhoneNumber);
            }

            var gvar = new GVAR();
            gvar.AddDataTable("VehicleInformation", dataTable);

            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }



    }
}
