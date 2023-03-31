using Markdig;
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
    /// Retrieves all the records from the provided CSV data and returns them as an enumerable collection of Gallery objects.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <returns>A list of Gallery objects.</returns>
    public static List<IDatabase> DatabaseRecords<IDatabase>(Stream csv)
    {
        using var reader = new StreamReader(csv);
        using var file = new CsvReader(reader, CultureInfo.InvariantCulture);
        return file.GetRecords<IDatabase>().ToList();
    }

    /// <summary>
    /// Returns the permalink based on the given name and key parameters.
    /// </summary>
    /// <param name="name">The name of the permalink.</param>
    /// <param name="key">The key for the permalink.</param>
    /// <returns>The permalink as a string.</returns>
    public static string Permalink(string name, string key) => @$"{name}/{key}";

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

