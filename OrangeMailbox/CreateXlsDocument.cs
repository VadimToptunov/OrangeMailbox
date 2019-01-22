
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace OrangeMailbox
{
    class CreateXlsDocument
    {
        private static DateTime Date = DateTime.UtcNow.Date;

        public static String CreateFilePath()
        {
            Random random = new Random();
            String XlsFilename = String.Format("{0}_{1}_Mailboxes.xlsx", Date.ToString("dd-MM-yyyy"), random.Next(1234567890).ToString());
            String FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), XlsFilename);
            return FilePath;
        }

        static void CreateEmptyFile(ExcelWorksheet workSheet, String FilePath)
        {   
            
            FileInfo fileInfo = new FileInfo(FilePath);

            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                var workSheetCreated = workSheet;
                FillWorkSheet(workSheetCreated);
                excelPackage.Save(); // Workbook should have at least one workSheet
            }
        }

        static void CreateXmlxWithData(List<string> bogusData, ExcelPackage excelPackage, String filePath)
        {
            ExcelWorksheet workSheet = GetWorkSheet(excelPackage);
            //CreateEmptyFile(workSheet, filePath);
            FillXmlsFile(bogusData, filePath, workSheet);
            excelPackage.Save();
        }

        public static void CreateEmptyFile(String FilePath)
        {
            //Some issues can occur here
            ExcelPackage excelPackage = new ExcelPackage(new FileInfo(FilePath));
            var workSheet = GetWorkSheet(excelPackage);
            CreateEmptyFile(workSheet, FilePath);
        }

        public static void CreateXmlxWithData(List<string> bogusData, String filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage excelPackage = new ExcelPackage(fileInfo);
            CreateXmlxWithData(bogusData, excelPackage, filePath);

        } 

        static void FillXmlsFile(List<string> bogusData, String FilePath, ExcelWorksheet workSheet)
        {
            List<CodeDetail> codeDetails = PopulateCodeDetails(bogusData);
            FileInfo fileInfo = new FileInfo(FilePath);
            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                workSheet.Cells["A2"].LoadFromCollection(codeDetails, false, OfficeOpenXml.Table.TableStyles.Medium14);
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                excelPackage.Save();
            }
        }

        public static ExcelWorksheet GetWorkSheet(ExcelPackage excelPackage)
        {
            var workSheet = excelPackage.Workbook.Worksheets.Add("Orange Mailboxes");
            return workSheet;
        }

        static void FillWorkSheet(ExcelWorksheet workSheet)
        {
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
        }

        public static List<CodeDetail> PopulateCodeDetails(List<string> bogusData)
        {
            List<CodeDetail> codeDetails = new List<CodeDetail>();
            
            CodeDetail codeDetail = new CodeDetail();

            List<string> generatedData = bogusData;

            codeDetail.DateNow = Date.ToString("dd/MM/yyyy");
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
    public string DateNow { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string SecretQuestion { get; set; }
    public string SecretAnswer { get; set; }
}
