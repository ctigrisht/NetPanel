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
