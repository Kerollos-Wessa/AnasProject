using AnasProject.DTOS;
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
    public class CircularGeofenceController : ControllerBase
    {
        private readonly ICircularGeofenceRepo circularGeofenceRepo;
        public CircularGeofenceController(ICircularGeofenceRepo circularGeofenceRepo)
        {
            this.circularGeofenceRepo = circularGeofenceRepo;
        }

        [HttpGet("circular")]
        public IActionResult GetCircularGeofences()
        {

            var circularGeofences = circularGeofenceRepo.GetAll();
            var dataTable = new DataTable("CircleGeofences");
            dataTable.Columns.Add("GeofenceID", typeof(long));
            dataTable.Columns.Add("Radius", typeof(long));
            dataTable.Columns.Add("Latitude", typeof(double));
            dataTable.Columns.Add("Longitude", typeof(double));

            foreach (var geofence in circularGeofences)
            {
                dataTable.Rows.Add(geofence.GeofenceId, geofence.Radius, geofence.Latitude, geofence.Longitude);
            }

            var gvar = new GVAR();
            gvar.AddDataTable("CircularGeofences", dataTable);

            // Wrap the GVAR object into a response structure
            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }





        [HttpPost("circular/add")]
        public IActionResult AddCircularGeofence([FromBody] CircularGeofenceDTO circularGeofenceDTO)
        {
            if (ModelState.IsValid)
            {
                var Circlegeofence = new CircleGeofence
                {
                    GeofenceId = circularGeofenceDTO.GeofenceId,
                    Radius = circularGeofenceDTO.Radius,
                    Latitude = circularGeofenceDTO.Latitude,
                    Longitude = circularGeofenceDTO.Longitude
                };

                circularGeofenceRepo.Insert(Circlegeofence);
                circularGeofenceRepo.Save();


                // Create a GVAR object and populate the DicOfDic with driver data
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["GeofenceId"] = Circlegeofence.GeofenceId.ToString(),
                    ["Radius"] = Circlegeofence.Radius.ToString(),
                    ["Latitude"] = Circlegeofence.Latitude.ToString(),
                    ["Longitude"] = Circlegeofence.Longitude.ToString()
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
    }
}
