using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyToDo.Models
{
    public class ToDo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public short Priority { get; set; }
        public string Category { get; set; }
        public DateTime DueDate { get; set; }
        public string Assignment { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
