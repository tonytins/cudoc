using CsvHelper.Configuration.Attributes;

namespace CaseyUniverse.DOC.Models;

public class Comic
{
    [Name("Issue")] public string Issue { get; set; } = string.Empty;
    [Name("Page")] public string Page { get; set; } = string.Empty;
}

