using Microsoft.EntityFrameworkCore;
using RobotBloger.Domain.Entitys;
using RobotBloger.Infrastrucute.Data.Context.Configurations;

namespace RobotBloger.Infrastrucute.Data
{
    public class RobotBlogerDbContext : DbContext
    {
        public RobotBlogerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("RobotBloger");
          
            modelBuilder.ApplyConfiguration(new BlogTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new StaticWordConfiguration());
   

        }

      

        public DbSet<BlogType> BlogTypes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<StaticWord> StaticWords { get; set; }

       
    }


}
