using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class StudentSubjectConfig : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(ss => new { ss.StudentId, ss.SubjectId });
            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.Subjects)
                .HasForeignKey(ss => ss.StudentId);
        }
    }
}
