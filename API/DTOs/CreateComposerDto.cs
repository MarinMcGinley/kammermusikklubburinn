using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateComposerDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
