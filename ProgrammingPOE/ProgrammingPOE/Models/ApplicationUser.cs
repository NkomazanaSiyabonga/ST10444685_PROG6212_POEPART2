using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingPOE.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Display(Name = "Staff ID")]
        [StringLength(20)]
        public string StaffId { get; set; }

        [Display(Name = "Department")]
        [StringLength(50)]
        public string Department { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}