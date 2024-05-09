using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigmaTestTask.Domain;
using SigmaTestTask.DTOs;
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

        [HttpPost("AddOrEdit")]
        public async Task<ActionResult<ContactDto>> AddOrEdit(ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _candidateService.AddOrUpdateCandidateAsync(contactDto);
            if (result.IsSuccess)
                return Ok(new { result.Message, contactDto });
            else
                return BadRequest(result.Message);
        }
        
    }
}
