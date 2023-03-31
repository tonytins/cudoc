using Markdig;
using Microsoft.AspNetCore.Components;

namespace CaseyUniverse.DOC;

public static class SiteHelper
{
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

