namespace AnasProject.DTOS
{
    public class VehicleDtoGetAll
    {
        public long VehicleId { get; set; }
        public long? VehicleNumber { get; set; } 
        public string VehicleType { get; set; } = string.Empty;
        public int? LastDirection { get; set; }
        public char? LastStatus { get; set; }
        public string? LastAddress { get; set; }
        public float? LastLatitude { get; set; }
        public float? LastLongitude { get; set; }
    }
}
