using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelInt_WebHelper.Models.DataModels
{
    public class GanerateContracts
    {
        readonly string pathToExcelFile = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + @"\Docs\курсовая для работы\Книга регистрации клиентов.xlsx";
        private string pathToDocFile;

        public string GenDocxContract(Contract contract)
        {
            if (contract == null)
                pathToDocFile = System.IO.Path.GetTempPath() + "temp.docx";
            else
                pathToDocFile = string.Concat(System.IO.Path.GetTempPath(), @contract.CompanyName, ".docx");

            //            using WordprocessingDocument doc =
            //WordprocessingDocument.Create(pathToDocFile,
            //                           WordprocessingDocumentType.Document,
            //                           true);
            //            MainDocumentPart mainPart = doc.AddMainDocumentPart();
            //            mainPart.Document = new Document();
            //            Body body = mainPart.Document.AppendChild(new Body());
            //            SectionProperties props = new SectionProperties();
            //            body.AppendChild(props);
            new GeneratedCode.GeneratedClass().CreatePackage(pathToDocFile);
            return pathToDocFile;
        }
        public List<Contract> GetExcelItems()
        {
            var contracts = new List<Contract>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(pathToExcelFile, false))
            {
                WorkbookPart wbPart = doc.WorkbookPart;
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
      Where(s => s.Name == "договоры").FirstOrDefault();
                WorksheetPart wsPart =
               (WorksheetPart)(wbPart.GetPartById(theSheet.Id));
                foreach (Row r in wsPart.Worksheet.Descendants<Row>())
                {
                    if (r.RowIndex < wsPart.Worksheet.Descendants<Row>().Count() && r.RowIndex > 2)
                    {
                        try
                        {
                            Contract contract = ReadExcelRow(r, wbPart);
                            contracts.Add(contract);

                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    else continue;
                }
            }
            return contracts;
        }
        private string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            var cellValue = cell.CellValue;
            var text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable
                    .Elements<SharedStringItem>().ElementAt(
                        Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }
            return (text ?? string.Empty).Trim();
        }
        private Contract ReadExcelRow(Row r, WorkbookPart workbookPart)
        {
            Contract contract = new Contract
            {
                RowNumber = int.Parse(ReadExcelCell(r.Elements<Cell>().ElementAt(0), workbookPart)),
                Date = DateTime.FromOADate(double.Parse(ReadExcelCell(r.Elements<Cell>().ElementAt(1), workbookPart))).ToString("dd/MM/yyyy"),
                ContractId = ReadExcelCell(r.Elements<Cell>().ElementAt(2), workbookPart),
                CompanyName = ReadExcelCell(r.Elements<Cell>().ElementAt(3), workbookPart),
                CurrencyContractId = ReadExcelCell(r.Elements<Cell>().ElementAt(4), workbookPart)
            };
            contract.RegDateCurrContract = double.TryParse(ReadExcelCell(r.Elements<Cell>().ElementAt(5), workbookPart), out double somedate) ? DateTime.FromOADate(somedate).ToString("dd/MM/yyyy") : ReadExcelCell(r.Elements<Cell>().ElementAt(5), workbookPart);
            contract.SummaryPayment = ReadExcelCell(r.Elements<Cell>().ElementAt(6), workbookPart);
            contract.ContractCurrency = ReadExcelCell(r.Elements<Cell>().ElementAt(7), workbookPart);
            contract.ContractPayment = ReadExcelCell(r.Elements<Cell>().ElementAt(8), workbookPart);
            contract.CountryOfRegister = ReadExcelCell(r.Elements<Cell>().ElementAt(9), workbookPart);
            contract.DateOfContract = ReadExcelCell(r.Elements<Cell>().ElementAt(10), workbookPart);
            contract.UserId = ReadExcelCell(r.Elements<Cell>().ElementAt(11), workbookPart);
            contract.PaymentType = ReadExcelCell(r.Elements<Cell>().ElementAt(12), workbookPart);
            contract.Reward = ReadExcelCell(r.Elements<Cell>().ElementAt(13), workbookPart);
            contract.IsYearWork = !string.IsNullOrWhiteSpace(ReadExcelCell(r.Elements<Cell>().ElementAt(14), workbookPart));
            return contract;
        }
        public Contract ReadExcelRow(int RowNumber)
        {            
            Contract contract = new Contract();
            using SpreadsheetDocument doc = SpreadsheetDocument.Open(pathToExcelFile, false);
            WorkbookPart wbPart = doc.WorkbookPart;
            Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
  Where(s => s.Name == "договоры").FirstOrDefault();
            WorksheetPart wsPart =
           (WorksheetPart)(wbPart.GetPartById(theSheet.Id));
            foreach (Row r in wsPart.Worksheet.Descendants<Row>())
            {
                if (r.RowIndex == RowNumber)
                {
                    contract = ReadExcelRow(r, wbPart);
                    return contract;
                }
            }
            return contract;
        }
    }
}
