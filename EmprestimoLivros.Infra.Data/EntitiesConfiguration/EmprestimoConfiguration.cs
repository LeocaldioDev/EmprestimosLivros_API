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
    internal class EmprestimoConfiguration : IEntityTypeConfiguration<LivroCLienteEmprestimo>
    {
        public void Configure(EntityTypeBuilder<LivroCLienteEmprestimo> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.clienteId).IsRequired();
            builder.Property(x => x.livroId).IsRequired();
            builder.Property(x => x.dataDevolucao).IsRequired();
            builder.Property(x => x.dataEmprestimo).IsRequired();
            builder.Property(x => x.entregue).IsRequired();


            builder.HasOne(x => x.Cliente).WithMany(x => x.Emprestimos)
                .HasForeignKey(x => x.clienteId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Livro).WithMany(x => x.Emprestimos).HasForeignKey(x => x.livroId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
