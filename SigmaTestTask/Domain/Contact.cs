using System.ComponentModel.DataAnnotations;

namespace SigmaTestTask.Domain
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PreferredCallTime { get; set; } 
        public string LinkedInProfileUrl { get; set; }
        public string GithubProfileUrl { get; set; }
        public string Comment { get; set; }
    }
}
