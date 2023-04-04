using CsvHelper.Configuration.Attributes;

namespace CaseyUniverse.DOC.Models;

public record Videos : IDatabase
{
    /// <summary>
    /// Gets or sets the ID of the video.
    /// </summary>
    [Name("Id")] public int Id { get; set; } = 0;

    /// <summary>
    /// Gets or sets the filename of the video.
    /// </summary>
    [Name("Filename")] public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the thumbnail of the video.
    /// </summary>
    [Name("Thumbnail")] public string Thumbnail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title of the gallery.
    /// </summary>
    [Name("Title")] public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the thumbnail of the video.
    /// </summary>
    [Name("Path")] public string Path { get; set; } = string.Empty;
}

