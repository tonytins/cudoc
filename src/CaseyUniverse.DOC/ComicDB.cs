namespace CaseyUniverse.DOC;

public class ComicDB
{
    /// <summary>
    /// Retrieves the Gallery object associated with the given filename from the provided CSV data.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <param name="file">The filename of the Gallery object to retrieve.</param>
    /// <returns>The Gallery object associated with the filename.</returns>
    /// <exception cref="IOException">Thrown when there is a problem locating the file.</exception>
    public static Comic Reader(Stream csv, int id)
    {
        var records = SiteHelper.DatabaseRecords<Comic>(csv);

        foreach (var record in records)
        {
            if (id == record.Id)
            {
                return new Comic
                {
                    Id = record.Id,
                    Filename = record.Filename,
                    Page = record.Page,
                    Issue = record.Issue
                };
            }
        }

        throw new IOException("There was a problem locating the file.");
    }
}
