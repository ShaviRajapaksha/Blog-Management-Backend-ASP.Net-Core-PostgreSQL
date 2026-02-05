using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/comments")]
public class CommentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public CommentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentDto dto)
    {
    var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserId);
    var postExists = await _context.Posts.AnyAsync(p => p.Id == dto.PostId);

        if (!userExists || !postExists)
            return BadRequest("User or Post does not exist");    
        var comment = new Comment
        {
            Content = dto.Content,
            UserId = dto.UserId,
            PostId = dto.PostId,
        };
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return Ok(comment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Comments
        .Include(c => c.User)
        .Include(c => c.Post)
        .ToListAsync()
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCommentDto dto)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        comment.Content = dto.Content ?? comment.Content;
        await _context.SaveChangesAsync();
        return Ok(comment);
    }

        [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null) return NotFound();

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}