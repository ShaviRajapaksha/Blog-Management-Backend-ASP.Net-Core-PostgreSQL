using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PostsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostDto dto)
    {
        var post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            UserId = dto.UserId,
            Published = false 
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return Ok(post);
    }

    [HttpGet]
    public async Task<IActionResult>GetAll()
    {
        return Ok(await _context.Posts
        .Include(p => p.User)
        .Include(p => p.Comments)
        .ToListAsync()
        );
    }

    [HttpPut("{id}")] 
    public async Task<IActionResult> Update(int id, UpdatePostDto dto)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        post.Title = dto.Title ?? post.Title;
        post.Content = dto.Content ?? post.Content;
        post.Published = dto.Published ?? post.Published;

        await _context.SaveChangesAsync();
        return Ok(post);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return NotFound();

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}