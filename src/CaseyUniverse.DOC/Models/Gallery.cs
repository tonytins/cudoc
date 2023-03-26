using System.Text.Json.Serialization;

namespace CaseyUniverse.DOC.Models;

public record Gallery(
    [property: JsonPropertyName("Title")] string Title,
    [property: JsonPropertyName("Path")] string Path,
    [property: JsonPropertyName("Source")] string Source,
    [property: JsonPropertyName("Address")] string Address
);

public record Databases(
    [property: JsonPropertyName("gallery")] IReadOnlyList<Gallery> Gallery
);

