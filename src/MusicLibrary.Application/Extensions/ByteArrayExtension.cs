using System.Text;

namespace MusicLibrary.Application.Extensions;

internal static class ByteArrayExtension
{
    public static string ParseToString(this byte[] bytes, string format = default)
    {
        var stringBuilder = new StringBuilder();

        foreach (var @byte in bytes)
        {
            stringBuilder.Append(@byte.ToString(format));
        }

        return stringBuilder.ToString();
    }
}