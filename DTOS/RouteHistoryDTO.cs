namespace AnasProject.DTOS
{
    public class RouteHistoryDTO
    {
        public long VehicleId { get; set; }
        public int? VehicleDirection { get; set; }
        public char? Status { get; set; }
        public string? VehicleSpeed { get; set; }
        public long? Epoch { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
    }
}
