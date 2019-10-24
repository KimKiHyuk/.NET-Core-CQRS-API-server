using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Dto;
using RestApi.Model;

namespace RestApi.Commands
{
    public class AboutMeCommandService : ICommandService<AboutMeDto>
    {
        private readonly DatabaseContext database;
        
        public AboutMeCommandService(DatabaseContext database)
        {
            this.database = database;
        }

        public async Task<AboutMeDto> SavePost(AboutMeDto dto)
        {
            await database.AboutMe.AddAsync(dto);
            await database.SaveChangesAsync();
            return dto;
        }
    }

}