using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Moq;
using SigmaTestTask.Controllers;
using SigmaTestTask.DTOs;
using SigmaTestTask.Helper;
using SigmaTestTask.Service;

namespace SigmaTestTask.Tests
{
    public class CandidateControllerTests
    {
        private readonly Mock<ICandidateService> _mockService;
        private readonly CandidateController _controller;

        public CandidateControllerTests()
        {
            _mockService = new Mock<ICandidateService>();
            _controller = new CandidateController(_mockService.Object);
        }



        [Fact]
        public async Task AddOrEdit_ModelStateInvalid_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Email", "Email is required");

            // Act
            var result = await _controller.AddOrEdit(new CandidateDto());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }


        [Fact]
        public async Task AddOrEdit_ReturnsOk_WhenCandidateAddedOrUpdatedSuccessfully()
        {
            // Arrange
            var candidateDto = new CandidateDto { 
                Email = "test@example.com",
                FirstName = "string",
                LastName = "string",
                PhoneNumber = "01237478858",
                PreferredCallTime = DateTime.Parse("2024-05-09T21:14:05.145Z"),
                LinkedInProfileUrl = "string",
                GithubProfileUrl = "string",
                Comment = "string"
            };

            var serviceResult = new Result { IsSuccess = true, Message = "Form Added Successfully" };
            _mockService.Setup(s => s.AddOrUpdateCandidateAsync(candidateDto))
                        .ReturnsAsync(serviceResult);

            // Act
            var result = await _controller.AddOrEdit(candidateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Console.WriteLine(okResult.Value);
            Assert.NotNull(okResult.Value);
            Assert.Equivalent(new { IsSuccess=true , Message = "Form Added Successfully" }, okResult.Value);
        }

    }
}