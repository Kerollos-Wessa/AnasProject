using AnasProject.DTOS;
using AnasProject.Models;

namespace AnasProject.Repos.GeofenceRepository
{
    public class GeofenceRepo : Repository<Geofence>, IGeofenceRepo
    {
        Context context;
        public GeofenceRepo(Context _context) : base(_context)
        {
            context = _context;
        }


        public List<GeofenceDTO> GetAllGeofences()
        {
            return context.Geofences
                .Select(g => new GeofenceDTO
                {
                    GeofenceId = g.GeofenceId,
                    GeofenceType = g.GeofenceType,
                    AddedDate = g.AddedDate,
                    StrockColor = g.StrockColor,
                    StrockOpacity = g.StrockOpacity,
                    StrockWeight = g.StrockWeight,
                    FillColor = g.FillColor,
                    FillOpacity = g.FillOpacity
                })
                .ToList();
        }

        public List<CircularGeofenceDTO> GetCircularGeofences()
        {
            return context.CircleGeofences
                .Select(g => new CircularGeofenceDTO
                {
                    GeofenceId = g.Id,
                    Radius = g.Radius,
                    Latitude = g.Latitude,
                    Longitude = g.Longitude
                })
                .ToList();
        }

        public List<RectangularGeofenceDTO> GetRectangularGeofences()
        {
            return context.RectangleGeofences
                .Select(g => new RectangularGeofenceDTO
                {
                    GeofenceId = g.GeofenceID,
                    North = g.North,
                    East = g.East,
                    West = g.West,
                    South = g.South
                })
                .ToList();
        }

        public List<PolygonGeofenceDTO> GetPolygonGeofences()
        {
            return context.PolygonGeofences
                .Select(g => new PolygonGeofenceDTO
                {
                    GeofenceID = g.GeofenceID,
                    Latitude = g.Latitude,
                    Longitude = g.Longitude
                })
                .ToList();
        }


    }
}
