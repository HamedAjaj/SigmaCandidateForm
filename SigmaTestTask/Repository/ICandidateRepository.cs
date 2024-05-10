using SigmaTestTask.Domain;

namespace SigmaTestTask.Repository
{
    public interface ICandidateRepository
    {
        Task<Contact> GetCandidateByEmailAsync(string email);
        Task AddCandidateAsync(Contact contact);
        void UpdateCandidate(Contact contact);
        Task Complete();
    }
}
