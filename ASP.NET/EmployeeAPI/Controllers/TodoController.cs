using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoApiController : ControllerBase
{
    private readonly TodoContext _db;

    public TodoApiController(TodoContext db) => _db = db;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TodoCreateDto dto)
    {
        var todo = new TodoItem
        {
            Title = dto.Title,
            IsDone = false
        };

        _db.TodoItems.Add(todo);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var todo = await _db.TodoItems.FindAsync(id);
        return todo is null ? NotFound() : Ok(todo);
    }
}