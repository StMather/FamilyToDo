using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FamilyToDo.Models
{
    public class TaskContext :DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        public DbSet<ToDo>ToDo { get; set; }

    }
}
