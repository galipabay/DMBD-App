using DMBD.Kernel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Types.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// Bu prop builder bizim entitylerimizin ozelliklerini-
        /// belirleyebilmemizi sinirlarini koyabilmemizi saglar.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.MailAddress).IsRequired();
            builder.Property(x => x.RegisterType).IsRequired();
            builder.Property(x => x.PreSchoolName).IsRequired();
            builder.Property(x => x.PreFacultyName).IsRequired();
            builder.Property(x => x.PreDepartmentName).IsRequired();
            builder.Property(x => x.DepartmentId).IsRequired();

            builder.ToTable("Student");
        }
    }
}
