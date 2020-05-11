using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
}
