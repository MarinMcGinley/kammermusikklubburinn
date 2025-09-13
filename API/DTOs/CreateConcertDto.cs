using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateConcertDto
{
    public string? Description { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int ConcertSeasonId { get; set; }
}
