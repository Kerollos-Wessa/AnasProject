using System.ComponentModel.DataAnnotations;

namespace AnasProject.DTOS
{
    public class DriverDto
    {
        [Required]
        public string DriverName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
