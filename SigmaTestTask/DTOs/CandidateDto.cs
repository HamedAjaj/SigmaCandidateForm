using System.ComponentModel.DataAnnotations;

namespace SigmaTestTask.DTOs
{
    public class CandidateDto
    {
        [MinLength(3, ErrorMessage = " FirstName must be more than or equal : 3 ")]
        [MaxLength(50, ErrorMessage = " FirstName must be less than : 50 characters")]
        public string FirstName { get; set; }

        [MinLength(3, ErrorMessage = " LastName must be more than or equal : 3 ")]
        [MaxLength(50 ,ErrorMessage = " LastName must be less than : 50 characters")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone ,MinLength(10,ErrorMessage ="Phone number must be min length is : 10")]
        public string PhoneNumber { get; set; }

        // may be enum like ['morning','evening',...]
        [Required]
        public DateTime PreferredCallTime { get; set; }

        [Required]
        [MaxLength(250)]
        public string LinkedInProfileUrl { get; set; }

        [Required]
        [MaxLength(250)]
        public string GithubProfileUrl { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
