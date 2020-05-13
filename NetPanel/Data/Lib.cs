using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NetPanel.Data
{
    public class Lib
    {
        public static void ExecuteShell(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/bin/bash", Arguments = $"{command}", };
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
            proc.WaitForExit();
            proc.Dispose();
        }

        public static void ExecuteShellAsync(string command) => Task.Factory.StartNew(() => ExecuteShell(command));

        public static StreamReader ExecuteShellWithOutput()
        {
            return new StreamReader(new AnonymousPipeClientStream(PipeDirection.InOut, String.Empty));
        }

    }
}
