using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDo_App.Models;

namespace ToDo_App.Controllers;

public class ToDoController : Controller
{

    public string Index()
    {
        return "test";
    }
}