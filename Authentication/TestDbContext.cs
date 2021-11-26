using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPIBackend.Data;

namespace TestAPIBackend.Authentication
{
    public partial class TestDbContext : IdentityDbContext<ApplicationUser>
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genrer> Genrers { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<LikedMoviesUsers> LikedMoviesUserss { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}
    }
}
