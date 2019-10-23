using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestApi.Dto;
using Microsoft.AspNetCore.Mvc;
using RestApi.Commands;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ResumeController : ControllerBase
    {
        private readonly ICommandService<AboutMeDto> aboutMeCommandService;

        public ResumeController(ICommandService<AboutMeDto> aboutMeCommandService) 
        {
            this.aboutMeCommandService = aboutMeCommandService;
        }

        [HttpGet]
        public IEnumerable<int> AboutMe() 
        {
            return new List<int>() {1, 2, 3};
        }

        [HttpPost]
        public async Task<AboutMeDto> AboutMe([FromBody] AboutMeDto value)
        {
            return await this.aboutMeCommandService.SavePost(value);
        }
    }
}