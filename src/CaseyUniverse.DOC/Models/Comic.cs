using CsvHelper.Configuration.Attributes;

namespace CaseyUniverse.DOC.Models;

public record Comic
{
    [Name("Id")] public int Id { get; set; } = 0;
    [Name("Issue")] public string Issue { get; set; } = string.Empty;
    [Name("Page")] public string Page { get; set; } = string.Empty;
    [Name("Filename")] public string Filename { get; set; } = string.Empty;
}

