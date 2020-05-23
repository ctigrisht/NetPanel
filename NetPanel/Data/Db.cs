using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NetPanel.Data
{
    public static class Db
    {
        public static MongoClient Client = new MongoClient();
        public static IMongoDatabase Database = Client.GetDatabase("NetPanelPerm");

        public static IMongoCollection<HostedApplication> HostedApps =
            Database.GetCollection<HostedApplication>("HostedApps");

        public static IMongoCollection<User> Users = Database.GetCollection<User>("Users");

        public static IMongoCollection<SystemFramework> InstalledFrameworks =
            Database.GetCollection<SystemFramework>("InstalledFrameworks");
    }
}
