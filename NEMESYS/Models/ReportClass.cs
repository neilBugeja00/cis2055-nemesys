using System.ComponentModel.DataAnnotations;

namespace NEMESYS.Models
{
    public class ReportClass
    {
        [Key]
        public int ReportID { get; set; }

        [Required]
        public string ReportDate { get; set; }

        [Required]
        public string HazardLocation { get; set; }

        [Required]
        public string HazardType { get; set; }

        [Required]
        public string HazardDate { get; set; }

        [Required]
        public string HazardDescription { get; set; }

    }
}
