using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingPOE.Models
{
    public enum ClaimStatus
    {
        Submitted,
        Verified,
        Approved,
        Rejected
    }

    public class Claim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LecturerId { get; set; }

        [Required]
        [Display(Name = "Hours Worked")]
        [Range(0.5, 160, ErrorMessage = "Hours worked must be between 0.5 and 160")]
        public decimal HoursWorked { get; set; }

        [Required]
        [Display(Name = "Hourly Rate")]
        [Range(10, 500, ErrorMessage = "Hourly rate must be between 10 and 500")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount => HoursWorked * HourlyRate;

        [Display(Name = "Additional Notes")]
        [StringLength(500)]
        public string AdditionalNotes { get; set; }

        public ClaimStatus Status { get; set; } = ClaimStatus.Submitted;

        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ApplicationUser Lecturer { get; set; }
        public virtual ICollection<SupportingDocument> SupportingDocuments { get; set; } = new List<SupportingDocument>();
    }
}