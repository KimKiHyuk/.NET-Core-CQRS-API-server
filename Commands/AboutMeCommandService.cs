using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Dto;

namespace RestApi.Commands
{
    public class AboutMeCommandService : ICommandService<AboutMeDto>
    {
        public AboutMeCommandService()
        {
        }

        public async Task<AboutMeDto> SavePost(AboutMeDto dto)
        {
            return dto;
        }
    }

}