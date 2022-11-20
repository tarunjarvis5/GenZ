using Microsoft.EntityFrameworkCore;


namespace GenZPlatformApp.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }


        public DbSet<GenzPlatformApp.Data.Model.User> Users { get; set; }
        public DbSet<GenzPlatformApp.Data.Model.DeployedDetails> DeployedDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenzPlatformApp.Data.Model.User>().Property(i => i.UserId).ValueGeneratedOnAdd();
            modelBuilder.Entity<GenzPlatformApp.Data.Model.DeployedDetails>().Property(i => i.Id).ValueGeneratedOnAdd();

        }

    }
}
