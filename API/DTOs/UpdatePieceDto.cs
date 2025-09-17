using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UpdatePieceDto : CreatePieceDto
{
    [Required]
    public int Id { get; set; }
}
