
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace OrangeMailbox
{
    class CreateXlsDocument
    {
        public static void CreateAndFillFile(List<string> bogusData)
        {
            List<CodeDetail> codeDetails = PopulateCodeDetails(bogusData);
            DateTime Date = DateTime.UtcNow.Date;
            Random random = new Random();
            String XlsFilename = String.Format("{0}_{1}_Mailboxes.xlsx", Date.ToString("dd-MM-yyyy"), random.Next(1234567890).ToString());
            String FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), XlsFilename);
            FileInfo fileInfo = new FileInfo(FilePath);

            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                var workSheet = GetWorkSheet(excelPackage, 0);
                workSheet.Cells["A2"].LoadFromCollection(codeDetails, false, OfficeOpenXml.Table.TableStyles.Medium14);
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
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
            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
            return workSheet;
        }

        public static List<CodeDetail> PopulateCodeDetails(List<string> bogusData)
        {
            List<CodeDetail> codeDetails = new List<CodeDetail>();
            CodeDetail codeDetail = new CodeDetail();
            List<string> generatedData = bogusData;
            codeDetail.Date = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            codeDetail.FirstName = generatedData[0];
            codeDetail.LastName = generatedData[1];
            codeDetail.Login = generatedData[2];
            codeDetail.Password = generatedData[3];
            codeDetail.SecretQuestion = generatedData[4];
            codeDetail.SecretAnswer = generatedData[5];
            codeDetails.Add(codeDetail);
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
