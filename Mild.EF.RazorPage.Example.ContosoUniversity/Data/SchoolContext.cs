using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mild.EF.RazorPage.Example.ContosoUniversity.Models;

namespace Mild.EF.RazorPage.Example.ContosoUniversity.Data
{

    // This DbContext is generated by 
    // dotnet aspnet-codegenerator razorpage -m Student \
    //  -dc Mild.EF.RazorPage.Example.ContosoUniversity.Data.SchoolContext -udl -outDir Pages/Students \
    //  --referenceScriptLibraries -sqlite
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        // Entity set contains multiple entities, 
        // many developers prefer the DBSet property names should be plural.
        // 
        // Creates a DbSet<TEntity> property for each entity set. In EF Core terminology:
        //  - An `entity set` typically corresponds to a database table.
        //  - An `entity` corresponds to a row in the table.
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        // OnModelCreating: 
        //  Is called when `SchoolContext` has been initialized, but before the model has been locked down and used to initialize the context.
        //  Is required because later in the tutorial the Student entity will have references to the other entities.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
