using System;
using Markdig;
using Markdig.Extensions.Yaml;
using YamlDotNet.Serialization;
using Markdig.Syntax;
using Microsoft.AspNetCore.Components;

namespace CaseyUniverse.DOC;

public static class MarkdownParser
{

    static readonly IDeserializer YamlDeserializer =
    new DeserializerBuilder()
    .IgnoreUnmatchedProperties()
    .Build();

    static readonly MarkdownPipeline Pipeline
        = new MarkdownPipelineBuilder()
        .UseYamlFrontMatter()
        .Build();

    /// <summary>
    /// Converts a Markdown-formatted string to an HTML-formatted string.
    /// </summary>
    /// <param name="content">The Markdown-formatted string to convert.</param>
    /// <returns>An HTML-formatted string.</returns>
    public static MarkupString MarkdownToHtml(this string content)
    {
        switch (string.IsNullOrEmpty(content))
        {
            case true:
                return (MarkupString)string.Empty;
            case false:
                {
                    var pipeline = new MarkdownPipelineBuilder()
                        .UseSmartyPants()
                        .UseYamlFrontMatter()
                        .DisableHtml()
                        .Build();

                    return (MarkupString)Markdown.ToHtml(content, pipeline);
                }
        }
    }

    /// <summary>
    /// Parses YAML front matter from the given markdown string.
    /// </summary>
    /// <typeparam name="T">The type of the front matter.</typeparam>
    /// <param name="markdown">The markdown string to parse the front matter from.</param>
    /// <returns>The front matter object of type T.</returns>
    public static T GetFrontMatter<T>(this string markdown)
    {
        // Parse the markdown document
        var document = Markdown.Parse(markdown, Pipeline);

        // Find the YAML front matter block
        var block = document
            .Descendants<YamlFrontMatterBlock>()
            .FirstOrDefault();

        // Return null if the front matter is not present
        if (block == null)
            return default;

        // Extract the YAML front matter as a string
        var yaml =
            block
            // this is not a mistake
            // we have to call .Lines 2x
            .Lines // StringLineGroup[]
            .Lines // StringLine[]
            .OrderByDescending(x => x.Line)
            .Select(x => $"{x}\n")
            .ToList()
            .Select(x => x.Replace("---", string.Empty))
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Aggregate((s, agg) => agg + s);

        // Deserialize the YAML front matter into an object of type T
        return YamlDeserializer.Deserialize<T>(yaml);
    }
}


