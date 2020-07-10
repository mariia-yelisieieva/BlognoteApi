using System;

namespace BlognoteApi
{
    public class BlognoteDatabaseSettings : IBlognoteDatabaseSettings
    {
        public string AuthorsCollectionName { get; set; }
        public string ArticlesCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBlognoteDatabaseSettings
    {
        string AuthorsCollectionName { get; set; }
        string ArticlesCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
