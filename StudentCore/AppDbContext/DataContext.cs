using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentCore.AppDbContext
{
    public partial class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<StudentEntities> Students { get; set; } = default!;
        public DbSet<TeacherEntities> Teachers { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("Data Source=CNS-127\\SQLDEV2019;initial catalog=DAMPDBNew;integrated security=false;Encrypt=False;User Id=sa;password=Canarys@123");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
            
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
