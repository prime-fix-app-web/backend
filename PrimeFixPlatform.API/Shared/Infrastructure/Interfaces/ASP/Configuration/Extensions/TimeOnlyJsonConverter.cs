using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public sealed class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    private const string TimeFormat = "HH:mm:ss";

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrWhiteSpace(value))
            throw new JsonException("Time value cannot be null or empty.");

        return TimeOnly.ParseExact(value, TimeFormat, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }
}