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
        public void GenDocxContract(string pathToDocFile = @"C:\Users\myaki\source\repos\BelInt_WebHelper\BelInt_WebHelper\Docs\курсовая для работы\Договоры\temp.docx")
        {
            using WordprocessingDocument doc =
WordprocessingDocument.Create(pathToDocFile,
                           WordprocessingDocumentType.Document,
                           true);
            MainDocumentPart mainPart = doc.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());
            SectionProperties props = new SectionProperties();
            body.AppendChild(props);
        }
        public List<Contract> GetExcelItems(string pathToExcelFile = @"C:\Users\myaki\source\repos\BelInt_WebHelper\BelInt_WebHelper\Docs\курсовая для работы\Книга регистрации клиентов.xlsx")
        {
            var contracts = new List<Contract>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(pathToExcelFile, false))
            {
                WorkbookPart wbPart = doc.WorkbookPart;
                WorksheetPart worksheetPart = wbPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                foreach (Row r in sheetData.Elements<Row>())
                {
                    try
                    {
                        contracts.Add(new Contract()
                        {
                            RowNomer = int.Parse(r.Elements<Cell>().ElementAt(1).CellValue.InnerText),
                            Date = DateTime.Parse(r.Elements<Cell>().ElementAt(2).CellValue.InnerText),
                            ContractId = r.Elements<Cell>().ElementAt(3).CellValue.InnerText,
                            CompanyName = r.Elements<Cell>().ElementAt(4).CellValue.InnerText,
                            CurrencyContractId = r.Elements<Cell>().ElementAt(5).CellValue.InnerText,
                            RegDateCurrContract = DateTime.Parse(r.Elements<Cell>().ElementAt(6).CellValue.InnerText),
                            SummaryPayment = double.Parse(r.Elements<Cell>().ElementAt(7).CellValue.InnerText),
                            ContractCurrency = r.Elements<Cell>().ElementAt(8).CellValue.InnerText,
                            ContractPayment = r.Elements<Cell>().ElementAt(9).CellValue.InnerText,
                            CountryOfRegister = r.Elements<Cell>().ElementAt(10).CellValue.InnerText,
                            DateOfContract = DateTime.Parse(r.Elements<Cell>().ElementAt(11).CellValue.InnerText),
                            UserId = r.Elements<Cell>().ElementAt(12).CellValue.InnerText,
                            PaymentType = r.Elements<Cell>().ElementAt(13).CellValue.InnerText,
                            Reward = r.Elements<Cell>().ElementAt(14).CellValue.InnerText,
                            IsYearWork = bool.Parse(r.Elements<Cell>().ElementAt(15).CellValue.InnerText),
                        });

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }

            return contracts;
        }
    }
}
