
namespace GarageInventory.Core.Converters.Json
{
    public class CreateItemDtoConverter //: JsonConverter<CreateItemDto>
    {
        //public override CreateItemDto Read(
        //    ref Utf8JsonReader reader,
        //    Type typeToConvert,
        //    JsonSerializerOptions options)
        //{
        //    using var document = JsonDocument.ParseValue(ref reader);

        //    var root = document.RootElement;

        //    // Read ItemType first
        //    if (!root.TryGetProperty("itemType", out var itemTypeProperty))
        //    {
        //        throw new JsonException("Property 'ItemType' is required.");
        //    }

        //    if (!Enum.TryParse<ItemTypes>(
        //            itemTypeProperty.GetString(),
        //            ignoreCase: true,
        //            out var itemType))
        //    {
        //        throw new JsonException(
        //            $"Unknown ItemType: {itemTypeProperty}");
        //    }

        //    if (!root.TryGetProperty("subModel", out var itemProperty))
        //    {
        //        throw new JsonException("Property 'SubModel' is required.");
        //    }

        //    // Deserialize Item according to ItemType
        //    BaseItemModel item = itemType switch
        //    {
        //        //ItemTypes.Wheel =>
        //        //    itemProperty.Deserialize<WheelDto>(options)
        //        //    ?? throw new JsonException("Invalid WheelModel."),

        //        ItemTypes.Tool =>
        //            itemProperty.Deserialize<ToolDto>(options)
        //            ?? throw new JsonException("Invalid ToolDto."),

        //        //ItemTypes.AutoPart =>
        //        //    itemProperty.Deserialize<AutoPartDto>(options)
        //        //    ?? throw new JsonException("Invalid AutoPartDto."),

        //        _ => throw new JsonException(
        //            $"Unsupported ItemType: {itemType}")
        //    };

        //    return new GeneralItemModel
        //    {
        //        ItemType = itemType,
        //        Item = item
        //    };
        //}

        //public override void Write(
        //    Utf8JsonWriter writer,
        //    GeneralItemModel value,
        //    JsonSerializerOptions options)
        //{
        //    writer.WriteStartObject();

        //    writer.WriteString(
        //        "itemType",
        //        value.ItemType.ToString());

        //    writer.WritePropertyName("item");

        //    JsonSerializer.Serialize(
        //        writer,
        //        value.Item,
        //        value.Item.GetType(),
        //        options);

        //    writer.WriteEndObject();
        //}
    }
}
