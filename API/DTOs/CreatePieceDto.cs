using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreatePieceDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public int ComposerId { get; set; }

}
