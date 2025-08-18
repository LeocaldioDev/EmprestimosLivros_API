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
    internal class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.id);
            builder.Property(l => l.nome).IsRequired().HasMaxLength(50);
            builder.Property(l => l.autor).IsRequired().HasMaxLength(200);
            builder.Property(l => l.editora).IsRequired().HasMaxLength(50);
            builder.Property(l => l.edicao).IsRequired().HasMaxLength(50);

        }
    }
}
