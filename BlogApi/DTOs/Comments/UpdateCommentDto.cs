using System.ComponentModel.DataAnnotations;

public class UpdateCommentDto
    {
        [Required]
        public string Content { get; set; } = null!;

        // FK → Post
        [Required]
        public int PostId { get; set; }

        public bool Published { get; set; } = false;
        
        // FK → User
        [Required]
        public int UserId { get; set; }
    }