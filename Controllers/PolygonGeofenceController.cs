using AnasProject.DTOS;
using AnasProject.Repos.PolygonGeofenceRepository;
using AnasProject.Repos.RectangularGeofenceReopsitory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolygonGeofenceController : ControllerBase
    {
        private readonly IPolygonGeofenceRepo polygonGeofenceRepo ;
        public PolygonGeofenceController(IPolygonGeofenceRepo polygonGeofenceRepo)
        {
            this.polygonGeofenceRepo = polygonGeofenceRepo;
        }

        [HttpGet("polygon")]
        public IActionResult GetPolygonGeofences()
        {

            var polygonGeofences = polygonGeofenceRepo.GetAll();
            var dataTable = new DataTable("PolygonGeofences");
            dataTable.Columns.Add("GeofenceId", typeof(long));
            dataTable.Columns.Add("Longitude", typeof(double));
            dataTable.Columns.Add("Latitude", typeof(double));
          

            foreach (var geofence in polygonGeofences)
            {
                dataTable.Rows.Add(geofence.GeofenceId, geofence.Longitude, geofence.Latitude);
            }

            var gvar = new GVAR();
            gvar.AddDataTable("PolygonGeofences", dataTable);

            // Wrap the GVAR object into a response structure
            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }





        [HttpPost("polygon/add")]
        public IActionResult AddPolygonGeofence([FromBody] PolygonGeofenceDTO polygonGeofenceDTO )
        {
            if (ModelState.IsValid)
            {
                var polygonGeofence = new PolygonGeofence 
                {
                    GeofenceId = polygonGeofenceDTO.GeofenceId,
                    Longitude = polygonGeofenceDTO.Longitude,
                    Latitude = polygonGeofenceDTO.Latitude


                };

                polygonGeofenceRepo.Insert(polygonGeofence);
                polygonGeofenceRepo.Save();


                // Create a GVAR object and populate the DicOfDic with driver data
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["GeofenceId"] = polygonGeofence.GeofenceId.ToString(),
                    ["Longitude"] = polygonGeofence.Longitude.ToString(),
                    ["Latitude"] = polygonGeofence.Latitude.ToString(),
                   
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
