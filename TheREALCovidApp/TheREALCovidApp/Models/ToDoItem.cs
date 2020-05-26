using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheREALCovidApp.Models
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime dueDate { get; set; }
    }
}
