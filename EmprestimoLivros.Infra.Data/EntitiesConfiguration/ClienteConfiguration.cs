using EmprestimoLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.bi).IsRequired().HasMaxLength(11);
            builder.Property(c => c.nome).IsRequired().HasMaxLength(200);
            builder.Property(c => c.endereco).IsRequired().HasMaxLength(50);
            builder.Property(c => c.cidade).IsRequired().HasMaxLength(50);
            builder.Property(c => c.bairro).IsRequired().HasMaxLength(50);
            builder.Property(c => c.numero).IsRequired().HasMaxLength(50);
            builder.Property(c => c.telefone).IsRequired().HasMaxLength(11);
            builder.Property(c => c.telefoneFixo).IsRequired().HasMaxLength(10);

        }
    }
}
