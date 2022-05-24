using PetaPoco;
using PetaPoco.Providers;
namespace BookMyShow.Services.DataBaseService
{
    public class Database
    {
        public IDatabase _db;
        public Database()
        {
            _db = DatabaseConfiguration.Build()
                     .UsingConnectionString("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True")
                     .UsingProvider<SqlSererMsDataDatabaseProvider>()
                     .UsingDefaultMapper<ConventionMapper>(m =>
                     {
                         m.InflectTableName = (inflector, s) => inflector.Pluralise(inflector.Underscore(s));
                         m.InflectColumnName = (inflector, s) => inflector.Underscore(s);
                     })
                     .Create();
        }
        public IDatabase getDb()
        {
            return _db;
        }

    }
}
