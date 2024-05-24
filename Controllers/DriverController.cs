using AnasProject.DTOS;
using AnasProject.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepo driverRepo;

        public DriverController(IDriverRepo driverRepo)
        {
            this.driverRepo = driverRepo;
        }

        [HttpPost]
        public IActionResult Create(DriverDto driverDto)
        {
            if (ModelState.IsValid)
            {
                Driver driver = new Driver()
                {
                    DriverName = driverDto.DriverName,
                    PhoneNumber = driverDto.PhoneNumber,
                };
                driverRepo.Insert(driver);
                driverRepo.Save();

                // Prepare GVAR response
                var gvarResponse = new GVAR();
                gvarResponse.DicOfDic["DriverInfo"] = new Dictionary<string, string>();
                gvarResponse.DicOfDic["DriverInfo"]["DriverId"] = driver.DriverId.ToString();
                gvarResponse.DicOfDic["DriverInfo"]["DriverName"] = driver.DriverName;
                gvarResponse.DicOfDic["DriverInfo"]["PhoneNumber"] = driver.PhoneNumber;

                return Ok(gvarResponse);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Driver> drivers = driverRepo.GetAll();

            // Prepare GVAR response
            var gvarResponse = new GVAR();
            gvarResponse.DicOfDic["Drivers"] = new Dictionary<string, string>();

            int index = 1;
            foreach (var driver in drivers)
            {
                gvarResponse.DicOfDic["Drivers"][$"Driver{index}_Id"] = driver.DriverId.ToString();
                gvarResponse.DicOfDic["Drivers"][$"Driver{index}_Name"] = driver.DriverName;
                gvarResponse.DicOfDic["Drivers"][$"Driver{index}_PhoneNumber"] = driver.PhoneNumber;
                index++;
            }

            return Ok(gvarResponse);
        }
    }
}
