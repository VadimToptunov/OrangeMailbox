
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrangeMailbox
{
    class CreateXlsDocument
    {
        public static void CreateAndFillFile()
        {
            List<CodeDetail> codeDetails = PopulateCodeDetails();
            DateTime Date = DateTime.UtcNow.Date;
            Random random = new Random();
            String XlsFilename = Date.ToString("dd_MM_yyyy") + "_" + random.Next(12324).ToString() + "_Mailboxes.xlsx";
            String FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), XlsFilename);
            FileInfo fileInfo = new FileInfo(FilePath);

            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                var workSheet = GetWorkSheet(excelPackage, 0);
                workSheet.Cells["A2"].LoadFromCollection(codeDetails, false, OfficeOpenXml.Table.TableStyles.Medium14);
                excelPackage.Save();
            }
        }

        static ExcelWorksheet GetWorkSheet(ExcelPackage excelPackage, int count)
        {
            var workSheet = excelPackage.Workbook.Worksheets.Add("Orange Mailboxes");

            workSheet.View.ShowGridLines = true;
            workSheet.Cells["A1"].Value = "Date";
            workSheet.Cells["B1"].Value = "First name";
            workSheet.Cells["C1"].Value = "Last name";
            workSheet.Cells["D1"].Value = "Login";
            workSheet.Cells["E1"].Value = "Password";
            workSheet.Cells["F1"].Value = "Secret Question";
            workSheet.Cells["G1"].Value = "Secret Answer";
            workSheet.Cells["A1:G1"].Style.Font.Bold = true;
            workSheet.Cells["A1:G1"].AutoFitColumns();
            //workSheet.Cells["A2:A100000"].AutoFitColumns();
            return workSheet;
        }

        public static List<CodeDetail> PopulateCodeDetails()
        {
            List<CodeDetail> codeDetails = new List<CodeDetail>();
            Random random = new Random();
            for (int i = 1; i <= 100; i++)
            {
                CodeDetail codeDetail = new CodeDetail();
                codeDetail.Date = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
                codeDetail.FirstName = random.Next(12324343).ToString();
                codeDetail.LastName = random.Next(12324343).ToString();
                codeDetail.Login = random.Next(12324343).ToString();
                codeDetail.Password = random.Next(123243435).ToString();
                codeDetail.SecretQuestion = random.Next(12324343).ToString();
                codeDetail.SecretAnswer = random.Next(123).ToString();
                codeDetails.Add(codeDetail);
            }
            return codeDetails;
        }
    }
}

    

public class CodeDetail
{
    public string Date { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string SecretQuestion { get; set; }
    public string SecretAnswer { get; set; }
}
