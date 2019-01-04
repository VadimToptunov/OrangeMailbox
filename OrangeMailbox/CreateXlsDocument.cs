using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
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
        static String XlsFilename = DateTime.UtcNow.Date.ToString("dd_MM_yyyy") + "_Mailboxes.xls";
        static String FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), XlsFilename);

        public static void FileExists(String FilePath)
        {
            Console.WriteLine(File.Exists(FilePath) ? String.Format("OK. The file %s exists.", FilePath) : String.Format("Error: The file %s does not exist.", FilePath));
        }

        //static void CreateFile()
        //{
        //    //Create an xls file
        //}

        //static void WriteDownUIntoFile()
        //{
        //    //Write down information into the file specified file
        //}

        public static void WriteToFile(string password)
        {
            StreamWriter SW = new StreamWriter(FilePath, false, Encoding.GetEncoding("windows-1251"));
            SW.Write(password);
            SW.Close();
            SW.Dispose();
        }
    }
}
