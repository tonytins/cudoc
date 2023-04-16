using CsvHelper.Configuration.Attributes;

namespace CaseyUniverse.DOC.Models;

public record Comic
{
    [Name("Id")] public int Id { get; set; } = 0;
    [Name("Volume")] public string Volume { get; set; } = string.Empty;
    [Name("Previous")] public int Previous { get; set; } = 0;
    [Name("Next")] public int Next { get; set; } = 0;
    [Name("Filename")] public string Filename { get; set; } = string.Empty;
}

