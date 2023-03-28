using CsvHelper.Configuration.Attributes;

namespace CaseyUniverse.DOC.Models;

public record Gallery(
    [Name("Id")] int Id,
    [Name("Filename")] string Filename
);
