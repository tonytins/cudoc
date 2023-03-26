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
    /// Returns the local CDN path based on the given json and path parameters.
    /// </summary>
    /// <param name="json">The name of the json file.</param>
    /// <param name="path">The name of the path.</param>
    /// <returns>The local CDN path as a string.</returns>
    public static string LocalCDN(string json, string path) => $@"../data/{path}/{json}.json";

    /// <summary>
    /// Returns the local CDN path based on the given json parameter.
    /// </summary>
    /// <param name="json">The name of the json file.</param>
    /// <returns>The local CDN path as a string.</returns>
    public static string LocalCDN(string json) => $@"../data/{json}.json";

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

