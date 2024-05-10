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
    internal class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        /// <summary>
        /// Bu prop builder bizim entitylerimizin ozelliklerini-
        /// belirleyebilmemizi sinirlarini koyabilmemizi saglar.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.SubjectId);
            builder.Property(x => x.TcNo).IsRequired();
            builder.Property(x => x.SubjectName).IsRequired(); 
            builder.Property(x => x.SubjectCredit).IsRequired(); 
            builder.Property(x => x.ExemptSubjectName).IsRequired(); 
            builder.Property(x => x.ExemptSubjectCredit).IsRequired(); 
            builder.Property(x => x.ExemptSubjectAkts).IsRequired(); 
            builder.Property(x => x.ExemptSubjectId).IsRequired();

            builder.ToTable("Subject");
        }
    }
}
