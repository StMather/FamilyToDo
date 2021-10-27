using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FamilyToDo.Models
{
    public static class ModelBulderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(
                new ToDo { Id = 1, Title = "Dishes", Discription = "Unload dishwasher", Priority = 1, Category = "Chore", DueDate = new DateTime(2021, 11, 9, 8, 30, 00), Assignment = "Ryan", CompletionDate = new DateTime(2021, 10, 14, 10, 30, 00) },
                new ToDo { Id = 2, Title = "Walk Dog", Discription = "Walk the dog around the corner", Priority = 7, Category = "Chore", DueDate = new DateTime(2021, 11, 14, 8, 30, 00), Assignment = "Steven", CompletionDate = null },
                new ToDo { Id = 3, Title = "Trash", Discription = "Take out trash", Priority = 3, Category = "Chore", DueDate = new DateTime(2021, 11, 12, 8, 30, 00), Assignment = "Any", CompletionDate = null },
                new ToDo { Id = 4, Title = "Vaccume", Discription = "Vaccume from room", Priority = 5, Category = "Chore", DueDate = new DateTime(2021, 4, 9, 8, 30, 00), Assignment = "Ryan", CompletionDate = null },
                new ToDo { Id = 5, Title = "Trash", Discription = "Take trash to curb", Priority = 1, Category = "Chore", DueDate = new DateTime(2021, 5, 9, 8, 00, 00), Assignment = "Steven", CompletionDate = new DateTime(2021, 10, 27, 1, 00, 00) },
                new ToDo { Id = 6, Title = "Shopping list", Discription = "1.Milk 2. Bread", Priority = 3, Category = "List", DueDate = new DateTime(2021, 8, 9, 8, 21, 00), Assignment = "Jon", CompletionDate = null });
          
        }
    }
}
