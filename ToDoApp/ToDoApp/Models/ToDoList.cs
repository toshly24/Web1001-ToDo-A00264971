using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    //This is the model class
    public class ToDoList 
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
    }
}

