using Microsoft.EntityFrameworkCore;
namespace StudentAdmissionSystem.Models
{
    public class AdmissionDBcontext:DbContext
        {
        public AdmissionDBcontext(DbContextOptions<AdmissionDBcontext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<AppUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admission>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StuId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
