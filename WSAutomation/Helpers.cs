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

            //process.StandardInput
            //   .WriteLine(@"D:\sdk-tools-windows\platform-tools\adb.exe");
            //Console.ReadKey();
        }

        public void startApp()
        {
            //select from library
            process.StandardInput
               .WriteLine(@"adb shell input tap 420 1150");
            Thread.Sleep(300);
        }

        public void fromCameraRoll(int index)
        {
            //select camera roll
            process.StandardInput
               .WriteLine(@"adb shell input tap 700 30");
            Thread.Sleep(300);
            //select Gallery
            process.StandardInput
               .WriteLine(@"adb shell input tap 200 400");
            switch (index)
            {
                case 1:
                    process.StandardInput.WriteLine(@"adb shell input tap 100 100");
                    break;
                case 2:
                    process.StandardInput.WriteLine(@"adb shell input tap 200 100");
                    break;
                default:
                    process.StandardInput.WriteLine(@"adb shell input tap 100 100");
                    break;
            }

        }

        public void selectImage(int index, int page)
        {
            // select image page
            for (int i = 0; i < 10; i++)
            {
                process.StandardInput.WriteLine(@"adb shell input swipe 300 300 300 1240");
                Thread.Sleep(500);
            }
            //guard condition
            if (page > 8)
                return;
            // select image page
            for (int i = 0; i < page; i++)
            {
                process.StandardInput.WriteLine(@"adb shell input swipe 300 1240 300 300");
                Thread.Sleep(500);
            }
            //Gird start at 300 increment 230, width start at 140, 360, 600
            Thread.Sleep(1000);
            switch (index)
            {
                case 1:
                    process.StandardInput.WriteLine(@"adb shell input tap 300 140");
                    break;
                case 2:
                    process.StandardInput.WriteLine(@"adb shell input tap 300 360");
                    break;
                case 3:
                    process.StandardInput.WriteLine(@"adb shell input tap 300 600");
                    break;
                case 4:
                    process.StandardInput.WriteLine(@"adb shell input tap 530 140");
                    break;
                case 5:
                    process.StandardInput.WriteLine(@"adb shell input tap 530 360");
                    break;
                case 6:
                    process.StandardInput.WriteLine(@"adb shell input tap 530 600");
                    break;
                case 7:
                    process.StandardInput.WriteLine(@"adb shell input tap 760 140");
                    break;
                case 8:
                    process.StandardInput.WriteLine(@"adb shell input tap 760 360");
                    break;
                case 9:
                    process.StandardInput.WriteLine(@"adb shell input tap 760 600");
                    break;
                case 10:
                    process.StandardInput.WriteLine(@"adb shell input tap 990 140");
                    break;
                case 11:
                    process.StandardInput.WriteLine(@"adb shell input tap 990 360");
                    break;
                case 12:
                    process.StandardInput.WriteLine(@"adb shell input tap 990 600");
                    break;
            }
            Thread.Sleep(500);
            //skip effect
            process.StandardInput.WriteLine(@"adb shell input tap 700 30");
        }


        public void editText(string text)
        {
            //double tap
            process.StandardInput.WriteLine(@"adb shell input tap 360 500");
            process.StandardInput.WriteLine(@"adb shell input tap 360 500");

            Thread.Sleep(500);

            process.StandardInput.WriteLine(@"adb shell input tap 600 30");
            for (int i = 0; i < 30; i++)
                process.StandardInput.WriteLine(@"adb shell input keyevent 67");

            //parse text

            var array = text.Split(' ');
            for (int n = 0; n < array.GetLength(0); n++)
            {
                process.StandardInput.WriteLine(@"adb shell input text " + array[n]);
                process.StandardInput.WriteLine(@"adb shell input keyevent 62");
            }

            process.StandardInput.WriteLine(@"adb shell input tap 360 800");
        }


        public void editEffect()
        {
            process.StandardInput.WriteLine(@"adb shell input tap 200 1150");
        }
        public void saveObject()
        {
            process.StandardInput.WriteLine(@"adb shell input tap 700 30");
            Thread.Sleep(2000);
            ImageComparer Im = new ImageComparer();
            while (!Im.IsOK())
            {
                process.StandardInput.WriteLine("adb shell screencap -p \"/mnt/sdcard/output.png\" && adb pull \"/mnt/sdcard/output.png\" \"" + Environment.CurrentDirectory + "\" && adb shell rm \"/mnt/sdcard/output.png\"");
                Thread.Sleep(2000);
            }
            Thread.Sleep(300); // Ok
            process.StandardInput.WriteLine(@"adb shell input tap 360 700");
            Thread.Sleep(300); // New
            process.StandardInput.WriteLine(@"adb shell input tap 700 30");
            Thread.Sleep(300); // Yes
            process.StandardInput.WriteLine(@"adb shell input tap 200 700");
        }

        public void downloadLocal()
        {
            process.StandardInput
               .WriteLine(@"");
        }
    }
}
