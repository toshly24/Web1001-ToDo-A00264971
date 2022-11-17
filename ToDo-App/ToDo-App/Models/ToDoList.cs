using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo_App.Models
{
    public class ToDoList
    {
        public int Id { get; set; }

        [Required]
        public string? Content { get; set; }

    }
}

