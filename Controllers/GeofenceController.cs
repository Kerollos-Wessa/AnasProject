using AnasProject.DTOS;
using AnasProject.Models;
using AnasProject.Repos.CircularGeofenceRepository;
using AnasProject.Repos.DriverRepository;
using AnasProject.Repos.GeofenceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeofenceController : ControllerBase
    {
        private readonly IGeofenceRepo geofenceRepo;
      
        public GeofenceController(IGeofenceRepo geofenceRepo )
        {
            this.geofenceRepo = geofenceRepo;
        }

        [HttpGet("all")]
        public IActionResult GetAllGeofences()
        { 
            
            var geofences = geofenceRepo.GetAll();
            var dataTable = new DataTable("Geofences");
            dataTable.Columns.Add("GeofenceId", typeof(long));
            dataTable.Columns.Add("GeofenceType", typeof(string));
            dataTable.Columns.Add("AddedDate", typeof(long));
            dataTable.Columns.Add("StrockColor", typeof(string));
            dataTable.Columns.Add("StrockOpacity", typeof(double));
            dataTable.Columns.Add("StrockWeight", typeof(double));
            dataTable.Columns.Add("FillColor", typeof(string));
            dataTable.Columns.Add("FillOpacity", typeof(double));

            foreach (var geofence in geofences)
            {
                dataTable.Rows.Add(
                    // Highlighted Change: Ensure GeofenceId is correctly added as long
                    geofence.GeofenceId,
                    geofence.GeofenceType,
                    geofence.AddedDate,
                    geofence.StrockColor,
                    geofence.StrockOpacity,
                    geofence.StrockWeight,
                    geofence.FillColor,
                    geofence.FillOpacity
                );
            }

            var gvar = new GVAR();
            gvar.AddDataTable("Geofences", dataTable);

            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }

       


       

      
        [HttpPost("add")]
        public IActionResult AddGeofence([FromBody] GeofenceDTO geofenceDTO)
        {
            if (ModelState.IsValid)
            {
                var geofence = new Geofence
                {
                    GeofenceType = geofenceDTO.GeofenceType,
                    AddedDate = geofenceDTO.AddedDate,
                    StrockWeight = geofenceDTO.StrockWeight,
                    StrockColor = geofenceDTO.StrockColor,
                    StrockOpacity = geofenceDTO.StrockOpacity,
                    FillColor = geofenceDTO.FillColor,
                    FillOpacity = geofenceDTO.FillOpacity
                };

                geofenceRepo.Insert(geofence);
                geofenceRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["GeofenceId"] = geofence.GeofenceId.ToString(),
                    ["GeofenceType"] = geofence.GeofenceType.ToString(),
                    ["AddedDate"] = geofence.AddedDate.ToString(),
                    ["StrockWeight"] = geofence.StrockWeight.ToString(),
                    ["StrockColor"] = geofence.StrockColor.ToString(),
                    ["StrockOpacity"] = geofence.StrockOpacity.ToString(),
                    ["FillColor"] = geofence.FillColor.ToString(),
                    ["FillOpacity"] = geofence.FillOpacity.ToString()

                };
                var response = new
                {
                    gvar = gvar
                };
                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");

        }







       

      


    }
}
