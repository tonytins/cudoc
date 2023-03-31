namespace CaseyUniverse.DOC;

public class GalleryDB
{
    /// <summary>
    /// Retrieves the Gallery object associated with the given ID from the provided CSV data.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <param name="id">The ID of the Gallery object to retrieve.</param>
    /// <returns>The Gallery object associated with the ID.</returns>
    /// <exception cref="IOException">Thrown when there is a problem locating the file.</exception>
    public static Gallery Reader(Stream csv, int id)
    {
        var records = SiteHelper.DatabaseRecords<Gallery>(csv);

        foreach (var record in records)
        {
            if (id == record.Id)
            {
                return new Gallery
                {
                    Id = record.Id,
                    Filename = record.Filename,
                    Title = record.Title,
                    Path = record.Path,
                    Description = record.Description
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
    public static Gallery Reader(Stream csv, string file)
    {
        var records = SiteHelper.DatabaseRecords<Gallery>(csv);

        foreach (var record in records)
        {
            if (file == record.Filename)
            {
                return new Gallery
                {
                    Id = record.Id,
                    Filename = record.Filename,
                    Title = record.Title,
                    Path = record.Path,
                    Description = record.Description
                };
            }
        }

        throw new IOException("There was a problem locating the file.");
    }
}
