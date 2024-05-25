﻿using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;

namespace AnasProject.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public virtual DbSet<CircleGeofence> CircleGeofences { get; set; }

        public virtual DbSet<Driver> Drivers { get; set; }

        public virtual DbSet<Geofence> Geofences { get; set; }

        public virtual DbSet<PolygonGeofence> PolygonGeofences { get; set; }

        public virtual DbSet<RectangleGeofence> RectangleGeofences { get; set; }

        public virtual DbSet<RouteHistory> RouteHistories { get; set; }

        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<VehiclesInformation> VehiclesInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach(var type in modelBuilder.Model.GetEntityTypes())
            //{
            //    modelBuilder.Entity(type.Name).Property<bool>("IsDeleted");
            //}
            modelBuilder.Entity<Driver>().HasQueryFilter(e => !e.IsDeleted);

        }

    }
}