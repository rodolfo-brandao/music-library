using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Core.Models.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MusicLibrary.Data.Extensions;

[ExcludeFromCodeCoverage]
internal static class ModelBuilderExtension
{
    public static ModelBuilder SeedModel<TEntity>(this ModelBuilder modelBuilder, string path) where TEntity : Entity
    {
        using var streamReader = new StreamReader(path);
        var models = JsonConvert.DeserializeObject<List<TEntity>>(streamReader.ReadToEnd(), new JsonSerializerSettings
        {
            ContractResolver = new NonPublicPropertiesResolver()
        });
        
        modelBuilder.Entity<TEntity>().HasData(models);
        return modelBuilder;
    }

    private class NonPublicPropertiesResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);

            if (member is not PropertyInfo propertyInfo)
            {
                return jsonProperty;
            }

            jsonProperty.Readable = propertyInfo.GetMethod != null;
            jsonProperty.Writable = propertyInfo.SetMethod != null;
            return jsonProperty;
        }
    }
}
