using GameStore.API.contracts;
using GameStore.API.EndPoints;
using GameStore.API.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndPoints();

app.MigrateDB();

app.Run();
