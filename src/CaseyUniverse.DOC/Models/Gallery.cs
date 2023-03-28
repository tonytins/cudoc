using CsvHelper.Configuration.Attributes;

namespace CaseyUniverse.DOC.Models;

public record Gallery
{
    [Name("Id")] public int Id { get; set; } = 0;
    [Name("Filename")] public string Filename { get; set; } = string.Empty;
    [Name("Title")] public string Title { get; set; } = string.Empty;
    [Name("Path")] public string Path { get; set; } = "gallery";
}
