namespace AnasProject.DTOS
{
    public class VehiclesInformationForGetAllDTO
    {
        public long? VehicleNumber { get; set; }
        public string VehicleType { get; set; } = string.Empty;
        public string DriverName { get; set;}
        public float? LastLatitude { get; set; }
        public float? LastLongitude { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string PhoneNumber { get; set; }


    }
}
