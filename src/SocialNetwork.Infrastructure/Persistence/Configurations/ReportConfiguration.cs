﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entity.System;

namespace SocialNetwork.Infrastructure.Persistence.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasOne(s => s.TargetPost).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.TargetUser).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.TargetGroup).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.TargetComment).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
