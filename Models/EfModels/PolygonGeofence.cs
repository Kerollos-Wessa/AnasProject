using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class PolygonGeofence
{
    public long Id { get; set; }

    public long? GeofenceId { get; set; }

    public float? Latitude { get; set; }
    public bool IsDeleted { get; set; } = false;

    public float? Longitude { get; set; }

    public virtual Geofence? Geofence { get; set; }
}
