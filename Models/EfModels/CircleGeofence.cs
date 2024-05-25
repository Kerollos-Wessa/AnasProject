using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class CircleGeofence
{
    public long Id { get; set; }

    public long? GeofenceId { get; set; }

    public long? Radius { get; set; }


    public float? Latitude { get; set; }

    public float? Longitude { get; set; }

    public bool IsDeleted { get; set; } = false;

    public virtual Geofence? Geofence { get; set; }
}
