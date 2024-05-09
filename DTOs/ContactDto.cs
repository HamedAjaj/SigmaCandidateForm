using System.ComponentModel.DataAnnotations;

namespace SigmaTestTask.DTOs
{
    public class ContactDto
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        
        public string PreferredCallTime { get; set; }

        [StringLength(250)]
        public string LinkedInProfileUrl { get; set; }

        [StringLength(250)]
        public string GithubProfileUrl { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }
    }
}
