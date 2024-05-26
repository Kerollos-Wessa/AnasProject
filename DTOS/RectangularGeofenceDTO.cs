namespace AnasProject.DTOS
{
    public class RectangularGeofenceDTO
    {
        public long GeofenceId { get; set; }
        public double North { get; set; }
        public double East { get; set; }
        public double West { get; set; }
        public double South { get; set; }
    }
}
