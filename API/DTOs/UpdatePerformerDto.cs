using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UpdatePerformerDto : CreatePerformerDto
{

    [Required]
    public int Id { get; set; }
}
