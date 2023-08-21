using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MusicLibrary.Data.ContractResolvers;

public class NonPublicPropertiesContractResolver : DefaultContractResolver
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