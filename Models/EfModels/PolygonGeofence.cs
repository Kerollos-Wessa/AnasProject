using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class PolygonGeofence
{
    public long Id { get; set; }

    public long? GeofenceId { get; set; }

    public double? Latitude { get; set; }
    public bool IsDeleted { get; set; } = false;

    public double? Longitude { get; set; }

    public virtual Geofence? Geofence { get; set; }
}
