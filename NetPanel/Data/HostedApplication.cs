using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace NetPanel.Data
{
    public class Mock
    {
        public Mock()
        {
            var frameworks = new List<SystemFramework>()
            {
                new SystemFramework()
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
                new SystemFramework()
                {
                    FrameworkName = "NodeJS",
                    Version = "Latest",
                    Description = "Javascript Interpreter/Web server",
                    
                    InstallCommands = new List<string>()
                    {
                        "sudo apt install nodejs"
                    }
                }
            };

        }
    }


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

    public class HostedApplication
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //status
        public bool IsRunning { get; set; }
        public int ProcId { get; set; }

        //meta
        public bool IsBinary { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AppDir { get; set; }
        public string MainExe { get; set; }
        public string StartArgs { get; set; }
        public string StartupCommand { get; set; }
        public ProcessPriorityClass Priority { get; set; }

        public StreamReader StartProcess()
        {
            try
            {
                var info = new ProcessStartInfo($"{MainExe}", StartArgs)
                {
                    CreateNoWindow = true
                };
                var proc = new Process
                {
                    StartInfo = info,
                    PriorityClass = Priority,
                };

                return proc.StandardOutput;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    [BsonNoId]
    public class HAppCommand
    {
        public string AppId { get; set; }
        public string CommandText { get; set; }
        public string CommandName { get; set; }
    }

    [BsonNoId]
    public class RconTask
    {
        public string AppId { get; set; }
        public string Command { get; set; }
        public CommandType Type { get; set; }
        public DateTime LastExec { get; set; }
        public TimeSpan Span { get; set; }

        public void ExecuteShell()
        {
            var happ = Db.HostedApps.Find(x => x.Id == AppId).FirstOrDefault();
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/bin/bash", Arguments = $"{happ.AppDir}{Command}", };
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
        }
    }

    public enum CommandType
    {
        None,
        Shell,
        Restart,
        Shutdown,
        Start
    }
}
