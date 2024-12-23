namespace GameStore.API.contracts;

public record class GameSummaryDto(
    int id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);
