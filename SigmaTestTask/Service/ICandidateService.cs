using SigmaTestTask.DTOs;
using SigmaTestTask.Helper;

namespace SigmaTestTask.Service
{
    public interface ICandidateService
    {
        Task<Result> AddOrUpdateCandidateAsync(CandidateDto contactDto);

    }

}
