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
                .WriteLine(@"adb kill-server");
            Thread.Sleep(3000);
            process.StandardInput
                .WriteLine(@"adb start-server");
            Thread.Sleep(3000);
            process.StandardInput
                .WriteLine(@"adb devices");

            //process.StandardInput
            //   .WriteLine(@"D:\sdk-tools-windows\platform-tools\adb.exe");
            //Console.ReadKey();
        }

        public void startApp()
        {
            Thread.Sleep(1500);
            //select from library
            process.StandardInput
               .WriteLine(@"adb shell input tap 420 1150");
            Thread.Sleep(300);
        }

        public void fromCameraRoll(int index)
        {
            Thread.Sleep(500);
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
            Thread.Sleep(2000);
            // select image page
            for (int i = 0; i < 10; i++)
            {
                process.StandardInput.WriteLine(@"adb shell input swipe 300 300 300 1240");
                Thread.Sleep(1500);
            }
            //guard condition
            if (page > 8)
                return;
            // select image page
            for (int i = 0; i < page; i++)
            {
                process.StandardInput.WriteLine(@"adb shell input swipe 300 1240 300 300");
                Thread.Sleep(1500);
            }
            //Gird start at 300 increment 230, width start at 140, 360, 600
            Thread.Sleep(1000);
            switch (index)
            {
                case 1:
                    process.StandardInput.WriteLine(@"adb shell input tap 140 300");
                    break;
                case 2:
                    process.StandardInput.WriteLine(@"adb shell input tap 360 300");
                    break;
                case 3:
                    process.StandardInput.WriteLine(@"adb shell input tap 600 300");
                    break;
                case 4:
                    process.StandardInput.WriteLine(@"adb shell input tap 140 530");
                    break;
                case 5:
                    process.StandardInput.WriteLine(@"adb shell input tap 360 530");
                    break;
                case 6:
                    process.StandardInput.WriteLine(@"adb shell input tap 600 530");
                    break;
                case 7:
                    process.StandardInput.WriteLine(@"adb shell input tap 140 760");
                    break;
                case 8:
                    process.StandardInput.WriteLine(@"adb shell input tap 360 760");
                    break;
                case 9:
                    process.StandardInput.WriteLine(@"adb shell input tap 600 760");
                    break;
                case 10:
                    process.StandardInput.WriteLine(@"adb shell input tap 140 990");
                    break;
                case 11:
                    process.StandardInput.WriteLine(@"adb shell input tap 360 990");
                    break;
                case 12:
                    process.StandardInput.WriteLine(@"adb shell input tap 600 990");
                    break;
                default:
                    process.StandardInput.WriteLine(@"adb shell input tap 140 300");
                    break;
            }
            Thread.Sleep(2000);
            //skip effect
            process.StandardInput.WriteLine(@"adb shell input tap 700 30");
        }


        public void editText(string text)
        {
            //double tap
            Thread.Sleep(1500);
            process.StandardInput.WriteLine(@"adb shell input tap 360 500 && adb shell input tap 360 500");
            //Thread.Sleep(100);
            //process.StandardInput.WriteLine(@"adb shell input tap 360 500");
            Thread.Sleep(2000);

            process.StandardInput.WriteLine(@"adb shell input tap 600 30");
            //for (int i = 0; i < 30; i++)
            //{
            //    Thread.Sleep(1000);
            //    process.StandardInput.WriteLine(@"adb shell input keyevent 67");
            //}
            Thread.Sleep(2000);
            //clear text
            process.StandardInput.WriteLine(@"adb shell input tap 700 30");
            //parse text

            var array = text.Split(' ');
            for (int n = 0; n < array.GetLength(0); n++)
            {
                Thread.Sleep(1000);
                process.StandardInput.WriteLine(@"adb shell input text " + array[n]);
                Thread.Sleep(1000);
                process.StandardInput.WriteLine(@"adb shell input keyevent 62");
            }
            Thread.Sleep(1500);
            process.StandardInput.WriteLine(@"adb shell input tap 360 800");
        }


        public void editEffect()
        {
            Thread.Sleep(1500);
            process.StandardInput.WriteLine(@"adb shell input tap 200 1150");
        }
        public void saveObject()
        {
            Thread.Sleep(1500);
            process.StandardInput.WriteLine(@"adb shell input tap 700 30");
            Thread.Sleep(2000);

            process.StandardInput.WriteLine("adb shell screencap -p \"/mnt/sdcard/output.png\" && adb pull \"/mnt/sdcard/output.png\" \"" + Environment.CurrentDirectory + "\" && adb shell rm \"/mnt/sdcard/output.png\"");
            Thread.Sleep(3000);

            ImageComparer Im = new ImageComparer();
            while (!Im.IsOK())
            {
                process.StandardInput.WriteLine("adb shell screencap -p \"/mnt/sdcard/output.png\" && adb pull \"/mnt/sdcard/output.png\" \"" + Environment.CurrentDirectory + "\" && adb shell rm \"/mnt/sdcard/output.png\"");
                Thread.Sleep(2000);
            }
            Thread.Sleep(1500); // Ok
            process.StandardInput.WriteLine(@"adb shell input tap 360 700");
            Thread.Sleep(1500); // New
            process.StandardInput.WriteLine(@"adb shell input tap 700 30");
            Thread.Sleep(1500); // Yes
            process.StandardInput.WriteLine(@"adb shell input tap 200 700");
        }

        public void downloadLocal()
        {
            process.StandardInput
               .WriteLine(@"");
        }
    }
}
