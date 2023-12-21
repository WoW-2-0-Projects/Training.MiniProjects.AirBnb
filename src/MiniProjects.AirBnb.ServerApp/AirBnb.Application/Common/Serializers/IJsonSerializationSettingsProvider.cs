using Newtonsoft.Json;

namespace AirBnb.Application.Common.Serializers;

public interface IJsonSerializationSettingsProvider
{
    JsonSerializerSettings Get(bool clone = false);
}