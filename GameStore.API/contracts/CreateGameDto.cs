using System.ComponentModel.DataAnnotations;

namespace GameStore.API.contracts;

public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    [Required] int GenreID,
    [Required][Range(1,100)] decimal Price,
    DateOnly ReleaseDate);
