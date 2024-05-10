using DMBD.Kernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Types.Configurations
{
    internal class FilesConfiguration : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.TcNo).IsRequired();
            builder.Property(x => x.Transcript).IsRequired();
            builder.Property(x => x.SubjectContent).IsRequired();
        }
    }
}
