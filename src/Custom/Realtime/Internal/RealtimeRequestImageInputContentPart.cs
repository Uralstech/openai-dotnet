using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Realtime;

public partial class RealtimeRequestImageInputContentPart : ConversationContentPart, IJsonModel<RealtimeRequestImageInputContentPart>
{
    public string InternalTextValue { get; set; }

    public RealtimeRequestImageInputContentPart(string internalTextValue) : base(ConversationContentPartKind.InputImage)
    {
        Argument.AssertNotNull(internalTextValue, nameof(internalTextValue));

        InternalTextValue = internalTextValue;
    }

    internal RealtimeRequestImageInputContentPart(ConversationContentPartKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, string internalTextValue) : base(kind, additionalBinaryDataProperties)
    {
        InternalTextValue = internalTextValue;
    }

    internal RealtimeRequestImageInputContentPart() : this(ConversationContentPartKind.InputImage, null, null)
    {
    }

    void IJsonModel<RealtimeRequestImageInputContentPart>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<RealtimeRequestImageInputContentPart>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(RealtimeRequestImageInputContentPart)} does not support writing '{format}' format.");
        }
        base.JsonModelWriteCore(writer, options);
        if (_additionalBinaryDataProperties?.ContainsKey("image_url") != true)
        {
            writer.WritePropertyName("image_url"u8);
            writer.WriteStringValue(InternalTextValue);
        }
    }

    RealtimeRequestImageInputContentPart IJsonModel<RealtimeRequestImageInputContentPart>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (RealtimeRequestImageInputContentPart)JsonModelCreateCore(ref reader, options);

    protected override ConversationContentPart JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<RealtimeRequestImageInputContentPart>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(RealtimeRequestImageInputContentPart)} does not support reading '{format}' format.");
        }
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeInternalRealtimeRequestImageInputContentPart(document.RootElement, options);
    }

    internal static RealtimeRequestImageInputContentPart DeserializeInternalRealtimeRequestImageInputContentPart(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        ConversationContentPartKind kind = default;
        IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        string internalTextValue = default;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("type"u8))
            {
                kind = new ConversationContentPartKind(prop.Value.GetString());
                continue;
            }
            if (prop.NameEquals("image_url"u8))
            {
                internalTextValue = prop.Value.GetString();
                continue;
            }
            // Plugin customization: remove options.Format != "W" check
            additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
        }
        return new RealtimeRequestImageInputContentPart(kind, additionalBinaryDataProperties, internalTextValue);
    }

    BinaryData IPersistableModel<RealtimeRequestImageInputContentPart>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

    protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<RealtimeRequestImageInputContentPart>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options, OpenAIContext.Default);
            default:
                throw new FormatException($"The model {nameof(RealtimeRequestImageInputContentPart)} does not support writing '{options.Format}' format.");
        }
    }

    RealtimeRequestImageInputContentPart IPersistableModel<RealtimeRequestImageInputContentPart>.Create(BinaryData data, ModelReaderWriterOptions options) => (RealtimeRequestImageInputContentPart)PersistableModelCreateCore(data, options);

    protected override ConversationContentPart PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<RealtimeRequestImageInputContentPart>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                using (JsonDocument document = JsonDocument.Parse(data))
                {
                    return DeserializeInternalRealtimeRequestImageInputContentPart(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(RealtimeRequestImageInputContentPart)} does not support reading '{options.Format}' format.");
        }
    }

    string IPersistableModel<RealtimeRequestImageInputContentPart>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}