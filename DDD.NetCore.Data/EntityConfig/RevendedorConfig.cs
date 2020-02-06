using DDD.NetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.NetCore.Data.EntityConfig
{
    public class RevendedorConfig : ConfigBase<RevendedorEntity>
    {
        public override void Configure(EntityTypeBuilder<RevendedorEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_REVENDEDOR");
            builder.Property(c => c.DsNome).HasColumnName("DS_NOME").IsRequired().HasMaxLength(70);
        }
    }
}
