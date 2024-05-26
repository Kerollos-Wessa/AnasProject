using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class RectangleGeofence
{
    public long Id { get; set; }

    public long? GeofenceId { get; set; }

    public double? North { get; set; }

    public double? East { get; set; }

    public bool IsDeleted { get; set; } = false;

    public double? West { get; set; }

    public double? South { get; set; }

    public virtual Geofence? Geofence { get; set; }
}
