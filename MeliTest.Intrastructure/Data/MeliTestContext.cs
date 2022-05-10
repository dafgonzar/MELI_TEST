using MeliTest.Core.Entities;
using MeliTest.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MeliTest.Infrastructure.Data
{
    public partial class MeliTestContext : DbContext
    {
        public MeliTestContext()
        {
        }

        public MeliTestContext(DbContextOptions<MeliTestContext> options) : base(options)
        {
        }

        public virtual DbSet<TbContenedores> TbContenedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContainersConfigurations());
        }

    }
}
