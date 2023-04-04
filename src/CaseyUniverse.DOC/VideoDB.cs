namespace CaseyUniverse.DOC;

public class VideoDB
{

    /// <summary>
    /// Gets a list of image files from a specified path.
    /// </summary>
    /// <param name="csv">The CSV file stream containing Videos records.</param>
    /// <param name="path">The path to filter the Videos records by.</param>
    /// <returns>A list of image file names.</returns>
    public static List<string> ThumbnailsFromPath(Stream csv, string path)
    {
        var records = SiteHelper.DatabaseRecords<Videos>(csv);
        var files = new List<string>();

        foreach (var record in records)
        {
            if (path == record.Path)
            {
                files.Add(record.Thumbnail);
            }
        }

        return files;
    }

    /// <summary>
    /// Retrieves the Videos object associated with the given ID from the provided CSV data.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <param name="id">The ID of the Videos object to retrieve.</param>
    /// <returns>The Videos object associated with the ID.</returns>
    /// <exception cref="IOException">Thrown when there is a problem locating the file.</exception>
    public static Videos Reader(Stream csv, int id)
    {
        var records = SiteHelper.DatabaseRecords<Videos>(csv);

        foreach (var record in records)
        {
            if (id == record.Id)
            {
                return new Videos
                {
                    Id = record.Id,
                    Filename = record.Filename,
                    Thumbnail = record.Thumbnail,
                    Title = record.Title,
                    Path = record.Path
                };
            }
        }

        throw new IOException("There was a problem locating the file.");
    }

    public static List<Videos> Reader(Stream csv)
    {
        var records = SiteHelper.DatabaseRecords<Videos>(csv);
        var videos = new List<Videos>();

        foreach (var record in records)
            videos.Add(record);

        return videos;

        throw new IOException("There was a problem locating the file.");
    }


    /// <summary>
    /// Retrieves the Videos object associated with the given filename from the provided CSV data.
    /// </summary>
    /// <param name="csv">The CSV data stream.</param>
    /// <param name="file">The filename of the Videos object to retrieve.</param>
    /// <returns>The Videos object associated with the filename.</returns>
    /// <exception cref="IOException">Thrown when there is a problem locating the file.</exception>
    public static Videos Reader(Stream csv, string file)
    {
        var records = SiteHelper.DatabaseRecords<Videos>(csv);

        foreach (var record in records)
        {
            if (file == record.Filename)
            {
                return new Videos
                {
                    Id = record.Id,
                    Filename = record.Filename,
                    Thumbnail = record.Thumbnail,
                    Title = record.Title,
                    Path = record.Path
                };
            }
        }

        throw new IOException("There was a problem locating the file.");
    }
}
