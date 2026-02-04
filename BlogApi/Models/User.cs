public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    
    public List<Post> Posts { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();

}