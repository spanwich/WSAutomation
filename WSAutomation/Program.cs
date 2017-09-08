using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using OfficeOpenXml;
using System.IO;

namespace WSAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            Helpers proc = new Helpers();
            FileInfo newFile = new FileInfo(Environment.CurrentDirectory + "\\quotes.xlsx");

            List<string> quotes = new List<string>();
            if (newFile.Exists)
            {

                using (var package = new ExcelPackage(newFile))
                {
                    var sheet = package.Workbook.Worksheets[1];
                    var columnimport = sheet.Cells["A:A"];
                    foreach (var cell in columnimport)
                    {
                        var column1CellValue = cell.GetValue<string>();
                        quotes.Add(column1CellValue);
                    }
                }

                var idea = quotes.Count;
                var s = idea / 12;
                var t = idea % 12;

                foreach (var quote in quotes)
                {
                    proc.startApp();
                    proc.selectImage(t, s);
                    proc.editText(quote);
                    proc.editEffect();
                    proc.saveObject();
                }
            }
            else
            {
                Console.WriteLine("File not existed.");
            }
            Console.ReadKey();
        }
    }
}
