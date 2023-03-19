namespace Catalog.Api.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string BookCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
