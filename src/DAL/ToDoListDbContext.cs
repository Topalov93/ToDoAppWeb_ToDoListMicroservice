using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        public ToDoListDbContext()
        {

        }

        public DbSet<ToDoList> ToDoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

    //            modelBuilder.Entity<Grade>()
    //.HasMany<Student>(g => g.Students)
    //.WithRequired(s => s.CurrentGrade)
    //.HasForeignKey<int>(s => s.CurrentGradeId);

            modelBuilder.Entity<ToDoList>()
                .Property(t => t.AddedOn)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<ToDoList>()
                .Property(t => t.EditedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
