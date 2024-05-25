using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class RouteHistory
{
    public long RouteHistoryId { get; set; }

    public long VehicleId { get; set; }

    public int? VehicleDirection { get; set; }

    public char? Status { get; set; }

    public string? VehicleSpeed { get; set; }
    public bool IsDeleted { get; set; } = false;

    public long? Epoch { get; set; }

    public float? Latitude { get; set; }

    public float? Longitude { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
