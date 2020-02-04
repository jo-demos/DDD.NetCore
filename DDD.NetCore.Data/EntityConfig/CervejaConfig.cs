using DDD.NetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.NetCore.Data.EntityConfig
{
    public class CervejaConfig : ConfigBase<CervejaEntity>
    {
        public override void Configure(EntityTypeBuilder<CervejaEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_CERVEJA");
            builder.Property(c => c.DsNome).HasColumnName("DS_NOME").IsRequired().HasMaxLength(50);
            builder.Property(c => c.VlTeorAlcoolico).HasColumnName("VL_TEORALCOOLICO").IsRequired();
            builder.Property(c => c.VlPreco).HasColumnName("VL_PRECO").IsRequired();
        }
    }
}