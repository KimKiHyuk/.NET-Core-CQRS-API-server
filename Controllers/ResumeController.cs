using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestApi.Dto;
using Microsoft.AspNetCore.Mvc;
using RestApi.Commands;
using RestApi.Queries;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ResumeController : ControllerBase
    {
        private readonly IQueryService<AboutMeDto> queryAboutMe;
        private readonly ICommandService<AboutMeDto> aboutMeCommandService;

        public ResumeController(ICommandService<AboutMeDto> aboutMeCommandService, IQueryService<AboutMeDto> queryAboutMe) 
        {
            this.aboutMeCommandService = aboutMeCommandService;
            this.queryAboutMe = queryAboutMe;
        }

        [HttpGet]
        public async Task<IEnumerable<AboutMeDto>> AboutMe() 
        {
            return await this.queryAboutMe.All();
        }

        [HttpPost]
        public async Task<AboutMeDto> AboutMe([FromBody] AboutMeDto value)
        {
            return await this.aboutMeCommandService.SavePost(value);
        }
    }
}