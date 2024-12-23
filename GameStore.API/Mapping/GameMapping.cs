using GameStore.API.contracts;
using GameStore.API.Entities;

namespace GameStore.API.mapping;

public static class GameMapping
{
    public static Game toEntities(this CreateGameDto game)
    {
        return new Game
        {
            Name = game.Name,
            GenreId = game.GenreID,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public static GameDetailedDto toDetailedDto(this Game game)
    {
        return new GameDetailedDto(game.Id, game.Name, game.GenreId, game.Price, game.ReleaseDate);
    }
    public static GameSummaryDto toSummaryDto(this Game game)
    {
        return new GameSummaryDto(game.Id, game.Name, game.Genre!.Name, game.Price, game.ReleaseDate);
    }

    public static Game toEntities(this UpdateGameDto game , int id)
    {
        return new Game
        {
            Id = id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

}