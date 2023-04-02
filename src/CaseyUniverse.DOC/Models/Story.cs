using YamlDotNet.Serialization;

namespace CaseyUniverse.DOC.Models;

public record Story
{
    [YamlMember(Alias = "description")] public string Description { get; set; } = string.Empty;
    [YamlMember(Alias = "authors")] public string Authors { get; set; } = string.Empty;
}
