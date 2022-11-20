using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext context;

        public ToDoController(ToDoContext context)
        {
            this.context = context;
        }

        // GET /
        public async Task<ActionResult> Index()
        {
            IQueryable<ToDoList> items = from i in context.ToDo orderby i.Id select i;

            List<ToDoList> todoList = await items.ToListAsync();

            return View(todoList);

        }

        // GET /todo/create
        public IActionResult Create() => View();

        // POST /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);

        }

        // GET /todo/edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ToDoList item = await context.ToDo.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }

        // POST /todo/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET /todo/delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ToDoList item = await context.ToDo.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                context.ToDo.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");
        }
    }
}
