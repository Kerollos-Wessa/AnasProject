namespace AnasProject.DTOS
{
    public class CircularGeofenceForGetDTO
    {
        public long GeofenceId { get; set; }
        public long Radius { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
