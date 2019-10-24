using System.Data.SqlClient;
using RestApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace RestApi.Queries
{
    public class AboutMeQuery : IQueryService<AboutMeDto>
    {
        private readonly string connectionString;

        public AboutMeQuery(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<AboutMeDto>> All()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return await conn.QueryAsync<AboutMeDto>("SELECT * FROM dbo.AboutMe;");    
            }
        }
    }
}