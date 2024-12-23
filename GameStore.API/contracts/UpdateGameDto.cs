using System.ComponentModel.DataAnnotations;

namespace GameStore.API.contracts;

public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required] int GenreId,
    [Required][Range(1,100)] decimal Price,
    DateOnly ReleaseDate);