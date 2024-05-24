﻿using AnasProject;
using AnasProject;
using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class Vehicle
{
    public long VehicleId { get; set; }

    public long? VehicleNumber { get; set; }

    public string? VehicleType { get; set; }

    public virtual RouteHistory? RouteHistory { get; set; }

    public virtual ICollection<VehiclesInformation> VehiclesInformations { get; set; } = new List<VehiclesInformation>();
}
