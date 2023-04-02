using CsvHelper.Configuration.Attributes;

namespace CaseyUniverse.DOC.Models;

public record Videos : IDatabase
{
    [Name("Id")] public int Id { get; set; } = 0;
    [Name("Filename")] public string Filename { get; set; } = string.Empty;
    [Name("Thumbnail")] public string Thumbnail { get; set; } = string.Empty;
}


