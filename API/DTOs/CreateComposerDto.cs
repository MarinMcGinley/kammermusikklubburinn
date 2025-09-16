using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateComposerDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
