using CsvHelper.Configuration.Attributes;

namespace CaseyUniverse.DOC.Models;

public record Gallery : IDatabase
{
    /// <summary>
    /// Gets or sets the ID of the gallery.
    /// </summary>
    [Name("Id")] public int Id { get; set; } = 0;

    /// <summary>
    /// Gets or sets the filename of the gallery.
    /// </summary>
    [Name("Filename")] public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title of the gallery.
    /// </summary>
    [Name("Title")] public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the path of the gallery.
    /// </summary>
    [Name("Path")] public string Path { get; set; } = string.Empty;
}