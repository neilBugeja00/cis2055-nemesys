using System.ComponentModel.DataAnnotations;

namespace NEMESYS.Models
{
    public class ReportClass
    {
        private string reporterFirstName="test";

        [Key]
        public int ReportID { get; set; }

        [Required]
        public string ReportDate { get; set; }

        [Required]
        public string ReportTitle { get; set; }

        [Required]
        public string HazardLocation { get; set; }

        [Required]
        public string HazardType { get; set; }

        [Required]
        public string HazardDate { get; set; }

        [Required]
        public string HazardDescription { get; set; }

        public string ReporterFirstName
        {
            get { return reporterFirstName; }
            set { reporterFirstName = value; }
        }

    }
}
