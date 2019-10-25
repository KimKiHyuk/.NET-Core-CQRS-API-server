using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Dto;

namespace RestApi.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<AboutMePostDto>()
                    .Property(p => p.Id)
                    .ValueGeneratedOnAdd();
                    */
        }
        public DbSet<AboutMeDto> AboutMe { get; set; }
    }
}