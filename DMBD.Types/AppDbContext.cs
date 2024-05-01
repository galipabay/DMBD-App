using DMBD.Kernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Types
{
    public class AppDbContext:DbContext
    {
        /// <Options>
        /// veri tabani yolunu bu dbcontextoptions uzerinden verecegiz
        /// </Options>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        /// <Dbset>
        /// DbSet ef.core'un bize sağladığı bir nimettir.
        /// </Dbset>
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
