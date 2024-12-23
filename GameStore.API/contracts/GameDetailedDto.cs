namespace GameStore.API.contracts;

public record class GameDetailedDto(
    int id,
    string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate);
