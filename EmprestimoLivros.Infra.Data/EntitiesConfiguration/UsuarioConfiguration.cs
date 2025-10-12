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
    class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure( EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.id);
            builder.Property(u => u.nome).IsRequired().HasMaxLength(200);
            builder.Property(u => u.email).IsRequired().HasMaxLength(200);
            builder.Property(u => u.passwordHash);
            builder.Property(u => u.passwordSalt);

        }
    }
}
