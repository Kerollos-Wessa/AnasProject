namespace AnasProject.DTOS
{
    public class VehiclesInformationDTO
    {
        public long VehicleId { get; set; }
        public long DriverId { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public long PurchaseDate { get; set; }
    }
}
