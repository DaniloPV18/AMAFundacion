﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FundacionAMA.Domain.Entities;
using FundacionAMA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FundacionAMA.Infrastructure.Persistence.Configurations
{
    public partial class BeneficiaryConfiguration : IEntityTypeConfiguration<Beneficiary>
    {
        public void Configure(EntityTypeBuilder<Beneficiary> entity)
        {
            entity.HasKey(e => e.PersonId);
             
            entity.Property(e => e.Description)
            .HasMaxLength(200)
            .IsFixedLength();
            entity.Property(e => e.Status)
            .IsRequired()
            .HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.Person).WithOne(p => p.Beneficiary)
            .HasForeignKey<Beneficiary>(d => d.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Beneficiaries_Persons");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Beneficiary> entity);
    }
}
