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

         [HttpGet("/{id:int}")] //Rota
       // ou [Route("/")]
        public TodoModel GetById([FromRoute]int id = 0, [FromServices] AppDbContext context) //dependency injection
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }
   } 
}