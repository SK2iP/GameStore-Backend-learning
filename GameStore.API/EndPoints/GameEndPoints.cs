using GameStore.API.contracts;
using GameStore.API.Data;
using GameStore.API.Entities;
using GameStore.API.mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.EndPoints;

public static class GameEndPoints{
    const string GetGameEndpointById = "GetGameById";

    private static readonly List<GameSummaryDto> games =
    [
        new(1,
            "Cyberpunk 2077",
            "CD Projekt Red",
            100.99M,
            new DateOnly(2020, 12, 10)),
        new(2,
            "The Witcher 3: Wild Hunt",
            "CD Projekt Red",
            45.99M,
            new DateOnly(2015, 5, 19)),
        new(3,
            "The Elder Scrolls V: Skyrim",
            "Bethesda Game Studios",
            39.99M,
            new DateOnly(2011, 11, 11)),
        new(4,
            "Grand Theft Auto V",
            "Rockstar Games",
            29.99M,
            new DateOnly(2013, 9, 17))
    ];

    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/games").WithParameterValidation();
        //Get all games
        group.MapGet("/", () => games);

        //Get game by id
        group.MapGet("/{id}", (int id,GameStoreContext dbContext) =>{ 
            Game? game = dbContext.Games.Find(id);

            return game != null ? Results.Ok(game.toDetailedDto()) : Results.NotFound();

        }).WithName(GetGameEndpointById);

        //Post game 
        group.MapPost("/", (CreateGameDto game , GameStoreContext dbContext) => {

            Game db_game = game.toEntities();

            dbContext.Games.Add(db_game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndpointById, new {id = games.Count + 1}, db_game.toDetailedDto());
        });


        //Update game by id
        group.MapPut("/{id}", (int id , UpdateGameDto updated_game , GameStoreContext dbDontext) => {
            var context_game = dbDontext.Games.Find(id);
            if (context_game == null)
            {
                return Results.NotFound();
            }
            else
            {
                dbDontext.Entry(context_game).CurrentValues.SetValues(updated_game.toEntities(id));
                dbDontext.SaveChanges();

                return Results.Ok(context_game.toDetailedDto());
            }
        });

        //Delete game by id

        group.MapDelete("/{id}" , (int id ,GameStoreContext dbContext) => {
            var context_game = dbContext.Games.Find(id);
            if (context_game == null)
            {
                return Results.NotFound();
            }
            else
            {
                dbContext.Games.Remove(context_game);
                dbContext.SaveChanges();

                return Results.Ok();
            }
        });

        return group;
    }


}