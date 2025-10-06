using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UpdateConcertSeasonDto : CreateConcertSeasonDto
{

    [Required]
    public int Id { get; set; }
}
