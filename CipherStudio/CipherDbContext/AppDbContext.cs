using CipherStudio.Models;
using CipherStudio.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CipherStudio.CipherDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("cn")
        {
           
        }
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Gender>genders{ get; set; }
        public DbSet<User>users{ get; set; }
        public DbSet<StudentTeacherSubjectViewModel> studentDetails{ get; set; }

      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Classes)
                .WithMany(c => c.Teachers)
                .Map(m =>
                {
                    m.ToTable("TeacherClasses");
                    m.MapLeftKey("TeacherId");
                    m.MapRightKey("ClassId");
                });

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers)
                .Map(m =>
                {
                    m.ToTable("TeacherSubjects");
                    m.MapLeftKey("TeacherId");
                    m.MapRightKey("SubjectId");
                });

            modelBuilder.Entity<Subject>()
                .HasRequired(s => s.Class)
                .WithMany(c => c.Subjects)
                .HasForeignKey(s => s.ClassId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }



    }
}