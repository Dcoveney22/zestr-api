using System.ComponentModel.DataAnnotations;

namespace ZestrApi.Models
{
    public class StaffMember
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string Department { get; set; } = string.Empty;
        public PersonnelType PersonnelType { get; set; }

        public bool IsActive { get; set; }

    }

}