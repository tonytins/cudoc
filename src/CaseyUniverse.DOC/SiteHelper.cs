using Markdig;
using Microsoft.AspNetCore.Components;
namespace CaseyUniverse.DOC;

/// <summary>
/// A helper class for site-related functions.
/// </summary>
public static class SiteHelper
{
    /// <summary>
    /// Gets a list of image files from a specified path.
    /// </summary>
    /// <param name="csv">The CSV file stream containing gallery records.</param>
    /// <param name="path">The path to filter the gallery records by.</param>
    /// <returns>A list of image file names.</returns>
    public static List<string> ImagesFromPath(Stream csv, string path)
    {
        var records = SiteHelper.DatabaseRecords<Gallery>(csv);
        var files = new List<string>();

        foreach (var record in records)
        {
            if (path == record.Path)
            {
                files.Add(record.Filename);
            }
        }

        return files;
    }

    /// <summary>
    /// Reads and deserializes records from a CSV file.
    /// </summary>
    /// <typeparam name="T">The type of database record.</typeparam>
    /// <param name="csv">The CSV file stream to read from.</param>
    /// <returns>A list of deserialized database records.</returns>
    public static List<IDatabase> DatabaseRecords<IDatabase>(Stream csv)
    {
        using var reader = new StreamReader(csv);
        using var file = new CsvReader(reader, CultureInfo.InvariantCulture);
        return file.GetRecords<IDatabase>().ToList();
    }

    /// <summary>
    /// Converts a Markdown-formatted string to an HTML-formatted string.
    /// </summary>
    /// <param name="content">The Markdown-formatted string to convert.</param>
    /// <returns>An HTML-formatted string.</returns>
    public static MarkupString MarkdownToHtml(this string content)
    {
        if (!string.IsNullOrEmpty(content))
        {
            var pipeline = new MarkdownPipelineBuilder()
                .DisableHtml()
                .Build();

            return (MarkupString)Markdown.ToHtml(content, pipeline);
        }
        else
            return (MarkupString)string.Empty;
    }

}

