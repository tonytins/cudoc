using CsvHelper;
using System.Globalization;
using System.Xml.Linq;
using Markdig;
using CaseyUniverse.DOC.Models;
using Microsoft.AspNetCore.Components;

namespace CaseyUniverse.DOC;

public static class SiteHelper
{
    /// <summary>
    /// Resolves the image path based on the given image and path parameters.
    /// </summary>
    /// <param name="image">The name of the image.</param>
    /// <param name="path">The name of the path.</param>
    /// <returns>The resolved image path as a string.</returns>
    public static string ResolveImagePath(string image, string path) => @$"../images/{path}/{image}";

    /// <summary>
    /// Returns the local CDN path based on the given csv and path parameters.
    /// </summary>
    /// <param name="csv">The name of the csv file.</param>
    /// <param name="path">The name of the path.</param>
    /// <returns>The local CDN path as a string.</returns>
    public static string LocalCDN(string csv, string path) => $@"../data/{path}/{csv}.csv";

    /// <summary>
    /// Returns the local CDN path based on the given csv parameter.
    /// </summary>
    /// <param name="csv">The name of the csv file.</param>
    /// <returns>The local CDN path as a string.</returns>
    public static string LocalCDN(string csv) => $@"../data/{csv}.csv";

    /// <summary>
    /// Returns the permalink based on the given name and key parameters.
    /// </summary>
    /// <param name="name">The name of the permalink.</param>
    /// <param name="key">The key for the permalink.</param>
    /// <returns>The permalink as a string.</returns>
    public static string Permalink(string name, string key) => @$"{name}/{key}";

    /// <summary>
    /// Retrieves all the records from the provided CSV data and returns them as an enumerable collection of Gallery objects.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <returns>A list of Gallery objects.</returns>
    public static List<Gallery> GalleryRecords(Stream csv)
    {
        using var reader = new StreamReader(csv);
        using var file = new CsvReader(reader, CultureInfo.InvariantCulture);
        return file.GetRecords<Gallery>().ToList();
    }

    /// <summary>
    /// Retrieves all the records from the provided CSV data and returns them as an enumerable collection of Gallery objects.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <returns>A list of Gallery objects.</returns>
    public static List<Comic> ComicRecords(Stream csv)
    {
        using var reader = new StreamReader(csv);
        using var file = new CsvReader(reader, CultureInfo.InvariantCulture);
        return file.GetRecords<Comic>().ToList();
    }

    /// <summary>
    /// Retrieves the Gallery object associated with the given ID from the provided CSV data.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <param name="id">The ID of the Gallery object to retrieve.</param>
    /// <returns>The Gallery object associated with the ID.</returns>
    /// <exception cref="IOException">Thrown when there is a problem locating the file.</exception>
    public static Gallery GalleryDb(Stream csv, int id)
    {
        var records = GalleryRecords(csv);

        foreach (var record in records)
        {
            if (id == record.Id)
            {
                return new Gallery
                {
                    Id = record.Id,
                    Filename = record.Filename,
                    Title = record.Title,
                    Path = record.Path
                };
            }
        }

        throw new IOException("There was a problem locating the file.");
    }

    /// <summary>
    /// Retrieves the Gallery object associated with the given filename from the provided CSV data.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <param name="file">The filename of the Gallery object to retrieve.</param>
    /// <returns>The Gallery object associated with the filename.</returns>
    /// <exception cref="IOException">Thrown when there is a problem locating the file.</exception>
    public static Gallery GalleryDb(Stream csv, string file)
    {
        var records = GalleryRecords(csv);

        foreach (var record in records)
        {
            if (file == record.Filename)
            {
                return new Gallery
                {
                    Id = record.Id,
                    Filename = record.Filename,
                    Title = record.Title,
                    Path = record.Path
                };
            }
        }

        throw new IOException("There was a problem locating the file.");
    }

    /// <summary>
    /// Retrieves the Gallery object associated with the given filename from the provided CSV data.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <param name="file">The filename of the Gallery object to retrieve.</param>
    /// <returns>The Gallery object associated with the filename.</returns>
    /// <exception cref="IOException">Thrown when there is a problem locating the file.</exception>
    public static Comic ComicDb(Stream csv, int id)
    {
        var records = ComicRecords(csv);

        foreach (var record in records)
        {
            if (id == record.Id)
            {
                return new Comic
                {
                    Id = record.Id,
                    Filename = record.Filename,
                    Page = record.Page,
                    Issue = record.Issue
                };
            }
        }

        throw new IOException("There was a problem locating the file.");
    }


    /// <summary>
    /// Converts the given Markdown content to HTML.
    /// </summary>
    /// <param name="content">The Markdown content to convert.</param>
    /// <returns>The HTML markup string.</returns>
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

