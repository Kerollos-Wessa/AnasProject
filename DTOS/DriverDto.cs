using System.ComponentModel.DataAnnotations;

namespace AnasProject.DTOS
{
    public class DriverDTO
    {
        [Required]
        public string DriverName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
