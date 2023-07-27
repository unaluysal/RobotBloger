using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RobotBloger.Domain.Entitys;

namespace RobotBloger.Infrastrucute.Data.Context.Configurations
{

    public class BlogTypeConfiguration : IEntityTypeConfiguration<BlogType>
    {

        public void Configure(EntityTypeBuilder<BlogType> builder)
        {
            builder.ToTable("BlogTypes");
        }
    }
}
