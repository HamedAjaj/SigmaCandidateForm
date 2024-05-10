using AutoMapper;
using Moq;
using SigmaTestTask.Domain;
using SigmaTestTask.DTOs;
using SigmaTestTask.Repository;
using SigmaTestTask.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SigmaTestTask.Tests
{
    public class CandidateServiceTests
    {

        private readonly Mock<ICandidateRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CandidateService _candidateService;


        Candidate existingCandidate_DemoObject =  new Candidate {
                Email = "hamed.aja@gmail.com",
                FirstName = "Hamed",
                LastName = "Farag",
                PhoneNumber = "01033839067",
                PreferredCallTime = DateTime.Parse("2024-05-09 12:12:00.0000000"),
                LinkedInProfileUrl = "ertert",
                GithubProfileUrl = "rtet",
                Comment = "ertertert"
            };

         CandidateDto candidateDTODemoObject = new  CandidateDto
        {
            Email = "test@example.com",
            FirstName = "string",
            LastName = "string",
            PhoneNumber = "01237478858",
            PreferredCallTime = DateTime.Parse("2024-05-09T21:14:05.145Z"),
            LinkedInProfileUrl = "string",
            GithubProfileUrl = "string",
            Comment = "string"
        };

        public CandidateServiceTests()
        {
            _mockRepository = new Mock<ICandidateRepository>();
            _mockMapper = new Mock<IMapper>();
            _candidateService = new CandidateService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddOrUpdateCandidateAsync_NewCandidate_ShouldAddAndReturnFormaAddedSuccessfully()
        {
            // Arrange
            var contactDto = candidateDTODemoObject;

            _mockRepository.Setup(r => r.GetCandidateByEmailAsync(contactDto.Email)).ReturnsAsync((Candidate)null);
            _mockMapper.Setup(m => m.Map<Candidate>(contactDto)).Returns(new Candidate { });

            // Act
            var result = await _candidateService.AddOrUpdateCandidateAsync(contactDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Form Added Successfully", result.Message);
            _mockRepository.Verify(r => r.AddCandidateAsync(It.IsAny<Candidate>()), Times.Once);
            _mockRepository.Verify(r => r.Complete(), Times.Once);
        }


        [Fact]
        public async Task AddOrUpdateCandidateAsync_ExistingCandidate_ShouldUpdateAndReturnFormUpdatedSuccessfully()
        {
            // Arrange
            var existingContact = existingCandidate_DemoObject;
            var contactDto = candidateDTODemoObject;
            _mockRepository.Setup(r => r.GetCandidateByEmailAsync(contactDto.Email)).ReturnsAsync(existingContact);

            // Act
            var result = await _candidateService.AddOrUpdateCandidateAsync(contactDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Form Updated Successfully", result.Message);
            _mockMapper.Verify(m => m.Map(contactDto, existingContact));
            _mockRepository.Verify(r => r.UpdateCandidate(It.IsAny<Candidate>()));
            _mockRepository.Verify(r => r.Complete());
        }

        [Fact]
        public async Task AddOrUpdateCandidateAsync_ErrorSaving_ShouldReturnFailure()
        {
            // Arrange
            var contactDto = candidateDTODemoObject;
            _mockRepository.Setup(r => r.GetCandidateByEmailAsync(contactDto.Email)).ReturnsAsync((Candidate)null);
            _mockRepository.Setup(r => r.Complete()).ThrowsAsync(new Exception());

            // Act
            var result = await _candidateService.AddOrUpdateCandidateAsync(contactDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(" An error occurred while saving the data.", result.Message);
        }
    }
}
