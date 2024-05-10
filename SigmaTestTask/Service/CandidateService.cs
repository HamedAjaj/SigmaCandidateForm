using AutoMapper;
using SigmaTestTask.Domain;
using SigmaTestTask.DTOs;
using SigmaTestTask.Helper;
using SigmaTestTask.Repository;

namespace SigmaTestTask.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _contactRepository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Result> AddOrUpdateCandidateAsync(CandidateDto contactDto)
        {
            var existingCandidate = await _contactRepository.GetCandidateByEmailAsync(contactDto.Email);

            if (existingCandidate == null)
            {
                await _contactRepository.AddCandidateAsync(_mapper.Map<Candidate>(contactDto));
            }
            else
            {
                _contactRepository.UpdateCandidate(_mapper.Map(contactDto, existingCandidate));
            }

            try
            {
                await _contactRepository.Complete();
                return new Result { IsSuccess = true, Message = existingCandidate == null ? "Created Successfully" : "Updated Successfully" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = " An error occurred while saving the data." };
            }
        }

    }
 }

