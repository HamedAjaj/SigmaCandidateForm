using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigmaTestTask.Domain;
using SigmaTestTask.DTOs;
using SigmaTestTask.Helper;
using SigmaTestTask.Repository;
using SigmaTestTask.Service;

namespace SigmaTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
           _candidateService = candidateService;
        }

        // ActionResult<Result> shows the response's format to assist the front-end developer.

        [HttpPost("AddOrEdit")]
        public async Task<ActionResult<Result>> AddOrEdit( [FromBody] CandidateDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _candidateService.AddOrUpdateCandidateAsync(contactDto);
            if (result.IsSuccess)
                return Ok(new { result.IsSuccess, result.Message });
            else
                return BadRequest(result.Message);
        }
        
    }
}
