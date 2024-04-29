using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Lab.Domain.DBObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Lab.Data.EntityConfig
{
    public class EscolaConfiguration : IEntityTypeConfiguration<EscolaDB>
    {
        public void Configure(EntityTypeBuilder<EscolaDB> builder)
        {
           // builder.HasKey(c => c.Id);
            builder .HasIndex(u => u.Nome).IsUnique();
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(30).IsRequired();
            builder.Property(c => c.Provincia).HasMaxLength(50).IsRequired();
        }
    }
}
