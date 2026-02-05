using System.ComponentModel.DataAnnotations;

public class CreatePostDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        // FK → User
        [Required]
        public int UserId { get; set; }
    }