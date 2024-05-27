using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class CircleGeofence
{
    public long Id { get; set; }

    public long GeofenceId { get; set; }

    public long Radius { get; set; }


    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public bool IsDeleted { get; set; } = false;

    public virtual Geofence? Geofence { get; set; }
}
