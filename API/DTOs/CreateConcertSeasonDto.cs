using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateConcertSeasonDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    // Example for double
    // [Range(0.01, double.MaxValue, ErrorMessage = "Prixe must be greater than zero")]
    // public decimal Prize { get; set; }
}
