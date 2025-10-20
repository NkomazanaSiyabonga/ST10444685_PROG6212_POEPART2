using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingPOE.Models
{
    public class SupportingDocument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClaimId { get; set; }

        [Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        public string ContentType { get; set; }

        public long FileSize { get; set; }

        // Navigation property
        public virtual Claim Claim { get; set; }
    }
}