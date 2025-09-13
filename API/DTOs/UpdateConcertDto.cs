using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UpdateConcertDto : CreateConcertDto
{

    [Required]
    public int Id { get; set; }
}
