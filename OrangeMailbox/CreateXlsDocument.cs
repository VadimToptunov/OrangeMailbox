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
        const string XLSDOCUMENT = ""; //(Create user_name/Documents/OrangeMailboxData/MailboxData_<CURRENT_DATE>)
        static Boolean FileExists()
        {
            //Check if file exists
            return true;
        }

        static void CreateFile()
        {
            //Crete an .xml file
        }

        static void WriteDownUIntoFile()
        {
            //Write down information into the file specified file
        }

        static void WriteToFile(string password)
        {
            StreamWriter SW = new StreamWriter(XLSDOCUMENT, false, Encoding.GetEncoding("windows-1251"));
            SW.Write(password);
            SW.Close();
            SW.Dispose();
        }
    }
}
