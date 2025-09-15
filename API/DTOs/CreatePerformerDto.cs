using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreatePerformerDto
{

    [Required]
    public string Name { get; set; } = string.Empty;
}
