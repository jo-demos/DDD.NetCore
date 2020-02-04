using DDD.NetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.NetCore.Data.EntityConfig
{
    public class ConfigBase<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.PkId);

            builder.Property(c => c.PkId).HasColumnName("PK_ID").ValueGeneratedOnAdd().IsRequired();
        }
    }
}
