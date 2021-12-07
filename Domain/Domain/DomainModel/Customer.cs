using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Model
{
    public partial class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Invalid Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Invalid Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Address { get; set; }

        public byte? State { get; set; }

        public string ZipCode { get; set; }

        public byte? Type { get; set; }
    }
}