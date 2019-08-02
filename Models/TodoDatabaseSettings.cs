namespace todo_api.Models
{
    public class TodoDatabaseSettings : ITodoDatabaseSettings
    {
        public string TodoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string Databasename { get; set; }
    }

    public interface ITodoDatabaseSettings
    {
        string TodoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string Databasename { get; set; }
    }
}