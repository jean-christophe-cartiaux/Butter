using Butter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.DataAcces.Configs
{
    internal class PayementConfig : IEntityTypeConfiguration<PayementEntity>
    {
        public void Configure(EntityTypeBuilder<PayementEntity> builder)
        {
            // !pas une Bonne idée d'avoir un nom FR alors qu'on 
            //! est en EN ...  En Bref  change moi ça !!!!!
            builder.ToTable("MoyenDePaiment");

            //! Définir nos colonnes
            //! PK 
            builder.HasKey(e => e.PayementId)
                   .HasName("PK_Payement")
                   .IsClustered(true);
            //! auto-increment pk
            builder.Property("PayementId")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.PayementName)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(200);
                
        }
    }
}
