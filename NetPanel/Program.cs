using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetPanel.Data;

namespace NetPanel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO TESTING MONGODB INSTALL ON FIRST RUN
            //var mdb = Task.Run(() =>
            //{
            //    Console.Write("MongoDB install not detected on your system, do you wish to install it now? [Y/n]:");
            //    switch (Console.ReadLine().ToLowerInvariant())
            //    {
            //        case "y":
            //            Lib.ExecuteShell("sudo apt install mongodb");
            //            Lib.ExecuteShell("sudo systemctl enable mongodb");
            //            break;
            //        case "n":
            //            break;
            //        default:
            //            break;
            //    }
            //});

            ////mdb.Wait();
            //TODO


            //create folder if not exists
            Task.Run(delegate
            {
                if (!Directory.Exists("/home/netpanel/apps")) Directory.CreateDirectory("/home/netpanel/apps");
            });



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
