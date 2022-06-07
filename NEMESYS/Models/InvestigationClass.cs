using System.ComponentModel.DataAnnotations;

namespace NEMESYS.Models
{
    public class InvestigationClass
    {

        [Key]
        public int InvestigationID { get; set; }

        [Required]
        public string InvestigationDescription { get; set; }

        [Required]
        public string InvestigationDate { get; set; }

        [Required]
        public string InvestigatorFirstName { get; set; }

        [Required]
        public string InvestigatorLastName { get; set; }

        [Required]
        public string InvestigatorEmail { get; set; }

        public string InvestigatorMobile { get; set; }

    }
}
