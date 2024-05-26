namespace AnasProject.DTOS
{
    public class RouteHistoryForGetAllDTO
    {
        public long VehicleId { get; set; }
        public long? VehicleNumber { get; set; }
        public float? LastLatitude { get; set; }
        public float? LastLongitude { get; set; }
        public int? VehicleDirection { get; set; }
        public char? Status { get; set; }
    }
}
