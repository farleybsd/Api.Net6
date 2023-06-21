using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context)
        => Ok(context.Todos.ToList());

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                NotFound();
            return Ok(todo);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] TodoModel todoModel, [FromServices] AppDbContext context)
        {
            context.Todos.Add(todoModel);
            context.SaveChanges();
            return Created($"/{todoModel.Id}", todoModel);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put([FromRoute] int id,
                             [FromBody] TodoModel todo,
                             [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Update(model);
            context.SaveChanges();
            return Ok(todo);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id,
                                [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            
            if (model == null)
                NotFound();

            context.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}
