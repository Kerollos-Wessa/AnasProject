using AnasProject.DTOS;
using AnasProject.Repos.CircularGeofenceRepository;
using AnasProject.Repos.RectangularGeofenceReopsitory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangularGeofenceController : ControllerBase
    {
        private readonly IRectangularGeofenceRepo rectangularGeofenceRepo;
        public RectangularGeofenceController(IRectangularGeofenceRepo rectangularGeofenceRepo)
        {
            this.rectangularGeofenceRepo = rectangularGeofenceRepo;
        }

        [HttpGet("rectangular")]
        public IActionResult GetrectangularGeofences()
        {

            var rectangularGeofences = rectangularGeofenceRepo.GetAll();
            var dataTable = new DataTable("RectangleGeofences");
            dataTable.Columns.Add("GeofenceId", typeof(long));
            dataTable.Columns.Add("North", typeof(double));
            dataTable.Columns.Add("West", typeof(double));
            dataTable.Columns.Add("East", typeof(double));
            dataTable.Columns.Add("South", typeof(double));

            foreach (var geofence in rectangularGeofences)
            {
                dataTable.Rows.Add(geofence.GeofenceId, geofence.North, geofence.West, geofence.East,geofence.South);
            }

            var gvar = new GVAR();
            gvar.AddDataTable("RectangleGeofences", dataTable);

            // Wrap the GVAR object into a response structure
            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }





        [HttpPost("rectangular/add")]
        public IActionResult AddrectangularGeofence([FromBody] RectangularGeofenceDTO rectangularGeofenceDTO )
        {
            if (ModelState.IsValid)
            {
                var rectangleGeofence = new RectangleGeofence
                {
                    GeofenceId = rectangularGeofenceDTO.GeofenceId,
                    North = rectangularGeofenceDTO.North,
                    West = rectangularGeofenceDTO.West,
                    East = rectangularGeofenceDTO.East,
                    South = rectangularGeofenceDTO.South

                };

                rectangularGeofenceRepo.Insert(rectangleGeofence);
                rectangularGeofenceRepo.Save();


                // Create a GVAR object and populate the DicOfDic with driver data
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["GeofenceId"] = rectangleGeofence.GeofenceId.ToString(),
                    ["North"] = rectangleGeofence.North.ToString(),
                    ["West"] = rectangleGeofence.West.ToString(),
                    ["East"] = rectangleGeofence.East.ToString(),
                    ["South"] = rectangleGeofence.South.ToString()

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
