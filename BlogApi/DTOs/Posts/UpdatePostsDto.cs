
using System.ComponentModel.DataAnnotations;

public class UpdatePostDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public bool? Published { get; set; }

        // FK → User
        [Required]
        public int UserId { get; set; }
    }