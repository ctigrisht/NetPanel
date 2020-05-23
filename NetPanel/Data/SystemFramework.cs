using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace NetPanel.Data
{
    [BsonNoId]
    public class SystemFramework
    {
        public string FrameworkName { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public bool Installed { get; set; }
        public BaseDistro Distro { get; set; }

        public List<string> InstallCommands = new List<string>();

        public void Install()
        {
            foreach (var installCommand in InstallCommands)
            {
                Lib.ExecuteShell(installCommand);
            }
        }
    }
    public enum BaseDistro
    {
        Debian,
        Fedora,
        Arch
    }

    public class PermanentFrameworks
    {
        public PermanentFrameworks()
        {
            var frameworks = new List<SystemFramework>
            {
                new SystemFramework
                {
                    FrameworkName = ".NET Core Runtime",
                    Version = "3.1",
                    Description = "Cross Platform framework to run .NET applications",
                    Distro = BaseDistro.Debian,
                    InstallCommands = new List<string>()
                    {
                        "sudo wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb",
                        "sudo dpkg -i packages-microsoft-prod.deb",
                        "sudo apt-get update",
                        "sudo apt-get install apt-transport-https",
                        "sudo apt-get update",
                        "sudo apt-get install dotnet-runtime-3.1",
                    }
                },
                new SystemFramework
                {
                    FrameworkName = "NodeJS",
                    Version = "Latest",
                    Description = "Javascript Interpreter/Web server",

                    InstallCommands = new List<string>()
                    {
                        "sudo apt install nodejs"
                    }
                },
                new SystemFramework
                {
                    FrameworkName = "PHP",
                    Version = "Latest",
                    Description = "PHP Runtime",
                    InstallCommands = new List<string> {
                        "sudo apt install php"
                    }
                },
                new SystemFramework
                {
                    FrameworkName = "MySql",
                    Version = "Latest",
                    Description = "Relational database server",
                    InstallCommands = new List<string> {
                        "sudo apt install mysql"
                    }
                },
                new SystemFramework
                {
                    FrameworkName = "PostGre Sql",
                    Version = "Latest",
                    Description = "Relational database server",
                    InstallCommands = new List<string> {
                        "sudo apt install postgresql postgresql-contrib"
                    }
                },
                new SystemFramework
                {
                    FrameworkName = "Redis memory store",
                    Version = "Latest",
                    Description = "Key-Value pair memory store",
                    InstallCommands = new List<string> {
                        "sudo apt install redis"
                    }
                },
                new SystemFramework {
                    FrameworkName = "Nginx web server (installed by default)",
                    Version = "Latest",
                    Description = "High performance web server and reverse proxy",
                    InstallCommands = new List<string>()
                    {
                        "sudo apt install nginx"
                    }
                },
                new SystemFramework()
                {
                    FrameworkName = "LetsEncrypt Certbot",
                    Version = "Latest",
                    Description = "SSL/TLS Certificate generator from LetsEncrypt",
                    InstallCommands = new List<string>()
                    {
                        "sudo apt install certbot"
                    }
                }
            };

        }

        public void AddFrameworksToDb()
        {

        }
    }


}
