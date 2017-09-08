using System;
using System.Diagnostics;
using System.Threading;

namespace WSAutomation
{
    class Helpers
    {
        Process process;
        public Helpers()
        {
            Init();
        }
        private void Init()
        {
            process = new System.Diagnostics.Process();

            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            startInfo.RedirectStandardInput = true;

            startInfo.UseShellExecute = false;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "";
            process = Process.Start(startInfo);

            process.StandardInput
                .WriteLine(@"D:\sdk-tools-windows\platform-tools\adb.exe kill-server");
            Thread.Sleep(3000);
            process.StandardInput
                .WriteLine(@"D:\sdk-tools-windows\platform-tools\adb.exe start-server");
            Thread.Sleep(3000);
            process.StandardInput
                .WriteLine(@"D:\sdk-tools-windows\platform-tools\adb.exe devices");

            process.StandardInput
               .WriteLine(@"D:\sdk-tools-windows\platform-tools\adb.exe shell");
            //Console.ReadKey();
        }

        public void startApp()
        {
            process.StandardInput
               .WriteLine(@"");
        }

        public void operationSequence()
        {
            process.StandardInput
               .WriteLine(@"");
        }

        public void saveObject()
        {
            process.StandardInput
               .WriteLine(@"");
        }
        public void downloadLocal()
        {
            process.StandardInput
               .WriteLine(@"");
        }
    }
}
