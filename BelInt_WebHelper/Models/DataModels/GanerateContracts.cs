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
        public string GenDocxContract(Contract contract)
        {
            string pathToDocFile = System.IO.Path.GetTempPath() + "temp.docx";
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
        public List<Contract> GetExcelItems(string pathToExcelFile = "")
        {
            var di = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            pathToExcelFile = di.Parent.Parent.Parent.FullName + @"\Docs\курсовая для работы\Книга регистрации клиентов.xlsx";

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
                            contracts.Add(new Contract()
                            {
                                RowNumber = int.Parse(ReadExcelCell(r.Elements<Cell>().ElementAt(0), wbPart)),
                                Date = ReadExcelCell(r.Elements<Cell>().ElementAt(1), wbPart),
                                ContractId = ReadExcelCell(r.Elements<Cell>().ElementAt(2), wbPart),
                                CompanyName = ReadExcelCell(r.Elements<Cell>().ElementAt(3), wbPart),
                                CurrencyContractId = ReadExcelCell(r.Elements<Cell>().ElementAt(4), wbPart),
                                RegDateCurrContract = ReadExcelCell(r.Elements<Cell>().ElementAt(5), wbPart),
                                SummaryPayment = ReadExcelCell(r.Elements<Cell>().ElementAt(6), wbPart),
                                ContractCurrency = ReadExcelCell(r.Elements<Cell>().ElementAt(7), wbPart),
                                ContractPayment = ReadExcelCell(r.Elements<Cell>().ElementAt(8), wbPart),
                                CountryOfRegister = ReadExcelCell(r.Elements<Cell>().ElementAt(9), wbPart),
                                DateOfContract = ReadExcelCell(r.Elements<Cell>().ElementAt(10), wbPart),
                                UserId = ReadExcelCell(r.Elements<Cell>().ElementAt(11), wbPart),
                                PaymentType = ReadExcelCell(r.Elements<Cell>().ElementAt(12), wbPart),
                                Reward = ReadExcelCell(r.Elements<Cell>().ElementAt(13), wbPart),
                                IsYearWork = !string.IsNullOrWhiteSpace(ReadExcelCell(r.Elements<Cell>().ElementAt(14), wbPart)),
                            });

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
    }
}
