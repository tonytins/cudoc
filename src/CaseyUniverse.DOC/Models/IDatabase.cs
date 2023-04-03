namespace CaseyUniverse.DOC.Models;

public interface IDatabase
{
    /// <summary>
    /// Gets or sets the ID of the database record.
    /// </summary>
    int Id { get; set; }

    /// <summary>
    /// Gets or sets the filename of the database record.
    /// </summary>
    string Filename { get; set; }

    /// <summary>
    /// Gets or sets the path of the database record.
    /// </summary>
    string Path { get; set; }
}