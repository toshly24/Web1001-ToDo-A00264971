using System;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data

{
    //This is a DbContext class. Used to connect the model to the database
    public class ToDoContext : DbContext //(Inheriting from the base class : DbContext)
    {
        //ToDoContext constructor with a parameter of the class type
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) 
        {
        }
        public DbSet<ToDoList> ToDo { get; set; }
    }
}

