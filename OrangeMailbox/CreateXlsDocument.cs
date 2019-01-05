using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMailbox
{
    class CreateXlsDocument
    {
        private static ExcelPackage excel;
        static DateTime Date = DateTime.UtcNow.Date;
        static String XlsFilename = Date.ToString("dd_MM_yyyy") + "_Mailboxes.xlsx";
        static String FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), XlsFilename);

        public static void FileExists(String FilePath)
        {
            Console.WriteLine(File.Exists(FilePath) ? String.Format("OK. The file %s exists.", FilePath) : String.Format("Error: The file %s does not exist.", FilePath));
        }

        public static void CreateFile()
        {
            using (excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Orange Mailboxes");

                var headerRow = new List<string[]>()
                {
                    new string[] { "Date", "First Name", "Last Name", "Login", "Password", "Secret Question", "Secret Answer" }
                };

                // Determine the header range (e.g. A1:G1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["Orange Mailboxes"];

                // Popular header row data
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                worksheet.Cells[headerRange].Style.Font.Bold = true;
                worksheet.Cells[headerRange].Style.Font.Size = 14;
                worksheet.Cells[headerRange].Style.Font.Color.SetColor(System.Drawing.Color.Black);

                FileInfo excelFile = new FileInfo(FilePath);
                excel.SaveAs(excelFile);
            }
        }

        static void WriteDownUIntoFile(string date, string name, string lastName, string login, string passw, string secretQ, string secretA)
        {
            //Write down information into the file specified file
            var dataRow = new List<string[]>()
                {
                    new string[] { date, name, lastName, login, passw, secretQ, secretA }
                };

            // Determine the header range (e.g. A1:G1)
            string headerRange = "A1:" + Char.ConvertFromUtf32(dataRow[0].Length + 64) + "1";

            // Target a worksheet
            var worksheet = excel.Workbook.Worksheets["Orange Mailboxes"];

            // Popular header row data
            worksheet.Cells[headerRange].LoadFromArrays(dataRow);
        }

        public static void WriteToFile(string password)
        {
            StreamWriter SW = new StreamWriter(FilePath, false, Encoding.GetEncoding("windows-1251"));
            SW.Write(password);
            SW.Close();
            SW.Dispose();
        }
    }
}
