using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UpdateComposerDto : CreateComposerDto
{
    [Required]
    public int Id { get; set; }
}
