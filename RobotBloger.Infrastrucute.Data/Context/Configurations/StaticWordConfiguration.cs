using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RobotBloger.Domain.Entitys;

namespace RobotBloger.Infrastrucute.Data.Context.Configurations
{

    public class StaticWordConfiguration : IEntityTypeConfiguration<StaticWord>
    {
        public void Configure(EntityTypeBuilder<StaticWord> builder)
        {
            builder.ToTable("StaticWords");
        }
    }
}
