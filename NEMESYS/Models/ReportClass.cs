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
        public string ReportTitle { get; set; }

        [Required]
        public string HazardLocation { get; set; }

        [Required]
        public string HazardType { get; set; }

        [Required]
        public string HazardDate { get; set; }

        [Required]
        public string HazardDescription { get; set; }

        public string ReporterFirstName { get; set; }
        public string ReporterLastName { get; set; }
        public string ReporterEmail { get; set; }
        public string ReporterMobile { get; set; }
        public string HazardStatus { get; set; }
        public byte[] HazardPhoto { get; set; }
        public string HazardUpvotes { get; set; }       

        public string Investigator { get; set; }

        public string InvestigationEntryID { get; set; }

    }
}
