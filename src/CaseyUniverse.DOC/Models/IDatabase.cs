namespace CaseyUniverse.DOC.Models;

public interface IDatabase
{
    /// <summary>
    /// Gets or sets the ID of the database record.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the database record.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the filename of the database record.
    /// </summary>
    public string Filename { get; set; }

    /// <summary>
    /// Gets or sets the path of the database record.
    /// </summary>
    public string Path { get; set; }
}