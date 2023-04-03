using YamlDotNet.Serialization;

namespace CaseyUniverse.DOC.Models;

public record Story
{
    /// <summary>
    /// Gets or sets the description of the story.
    /// </summary>
    [YamlMember(Alias = "description")] public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the authors of the story.
    /// </summary>
    [YamlMember(Alias = "authors")] public string Authors { get; set; } = string.Empty;
}