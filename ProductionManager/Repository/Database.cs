using LiteDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Repository
{
    public static class Database
    {
        public static readonly LiteRepository DbInstance;

        static Database()
        {
            DbInstance = new LiteRepository(ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString);
        }
    }
}
