using LiteDB;
using ProductionManager.Model;
using System.Configuration;

namespace ProductionManager.Repository
{
    public static class Database
    {
        public static readonly LiteRepository LiteDbInstance;

        static Database()
        {
            switch (ConfigurationManager.AppSettings["DB"])
            {
                case "LITEDB":
                    LiteDbInstance = new LiteRepository(ConfigurationManager.ConnectionStrings["LITEDB"].ConnectionString);
                    break;
                default:
                    LiteDbInstance = new LiteRepository(ConfigurationManager.ConnectionStrings["LITEDB"].ConnectionString);
                    break;
            }
        }

        public static IRepository<T> CreateRepositoryForModel<T>() where T : BasicModel
        {
            switch (ConfigurationManager.AppSettings["DB"])
            {
                case "LITEDB":
                    return new LiteDbRepository<T>();
                default:
                    return new LiteDbRepository<T>();
            }
        }
    }
}
