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

    public class Mock
    {
        public Mock()
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
                        "sudo apt-get install dotnet-sdk-3.1",
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

                    InstallCommands = new List<string>()
                    {
                        "sudo apt install php"
                    }
                },
                new SystemFramework()
                {

                }
            };

        }
    }


}
