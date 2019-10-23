using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ResumeController : ControllerBase
    {
        public ResumeController() 
        {

        }

        [HttpGet]
        public IEnumerable<int> AboutMe() 
        {
            return new List<int>() {1, 2, 3};
        }

        [HttpPost]
        public AboutMeDto AboutMe([FromBody] AboutMeDto value)
        {
            return value;
        }
    }
}