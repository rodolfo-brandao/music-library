using Microsoft.EntityFrameworkCore;
using MusicLibrary.Core.Models.Abstract;
using MusicLibrary.Data.ContractResolvers;
using Newtonsoft.Json;

namespace MusicLibrary.Data.Extensions;

internal static class ModelBuilderExtension
{
    public static ModelBuilder SeedModel<TEntity>(this ModelBuilder modelBuilder, string path) where TEntity : Entity
    {
        using var streamReader = new StreamReader(path);
        var models = JsonConvert.DeserializeObject<List<TEntity>>(streamReader.ReadToEnd(), new JsonSerializerSettings
        {
            ContractResolver = new NonPublicPropertiesContractResolver()
        });

        modelBuilder.Entity<TEntity>().HasData(models);
        return modelBuilder;
    }
}