using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public static class DataExtentions
{
    public static void MigrateDB(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var DBContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        DBContext.Database.Migrate();
        
    }
}
