using Microsoft.AspNetCore.Mvc;
using TodoMVC.Data;
using TodoMVC.Models;

namespace TodoMVC.Controllers
{
   [ApiController]
   public class HomeController : ControllerBase
   {
        [HttpGet("/")] //Rota
       // ou [Route("/")]
        public List<TodoModel> Get([FromServices] AppDbContext context) //dependency injection
        {
            return context.Todos.ToList();
        }

        [HttpPost("/")] //Rota
       // ou [Route("/")]
        public TodoModel Post(TodoModel model, [FromServices] AppDbContext context) //dependency injection
        {
            context.Todos.Add(model);
            context.SaveChanges();

            return model;
        }

      [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todos == null)
                return NotFound();

            return Ok(todos);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            context.Todos.Remove(model);
            context.SaveChanges();

            return Ok(model);
        }
   } 
}