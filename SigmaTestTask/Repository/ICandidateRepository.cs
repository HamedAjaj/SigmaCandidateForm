using SigmaTestTask.Domain;

namespace SigmaTestTask.Repository
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateByEmailAsync(string email);
        Task AddCandidateAsync(Candidate contact);
        void UpdateCandidate(Candidate contact);
        Task Complete();
    }
}
