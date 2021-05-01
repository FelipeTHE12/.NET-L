using cadastro_restfull.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_restfull.Infraestruture.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USER");
            builder.HasKey(prop => prop.Code);
            builder.Property(p => p.Code).ValueGeneratedOnAdd();
            builder.Property(p => p.Login).ValueGeneratedOnAdd();
            builder.Property(p => p.Password).ValueGeneratedOnAdd();
            builder.Property(p => p.Email).ValueGeneratedOnAdd();
        }
    }
}
