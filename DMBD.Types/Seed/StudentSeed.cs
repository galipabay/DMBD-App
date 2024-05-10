using DMBD.Kernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Types.Seed
{
    internal class StudentSeed : IEntityTypeConfiguration<Student>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Student> builder)
        {
            builder.HasData(new Student 
            { 
                Id = 1,
                Name = "Galip",
                Surname = "Abay",
                TcNo = "2637239385",
                DepartmentId = "2362",
                DepartmentName = "Muhendislik ve mimarlik",
                MailAddress = "w31312",
                PhoneNumber = "1234567890",
                PreDepartmentName = "1234567890",
                PreFacultyName = "1234567890",
                PreSchoolName = "1234567890",
                StudentNo = "1234567890",
                StudentId = "1234567890",
                CreatedDate = DateTime.Now,
            });
        }
    }
}
