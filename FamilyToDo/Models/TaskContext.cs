﻿using System;
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
        public DbSet<Task>Tasks { get; set; }
        public DbSet<User>Users { get; set; }
    }
}
