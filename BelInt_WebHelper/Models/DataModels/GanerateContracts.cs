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
        public void GenDocxContract()
        {
            string pathToDocFile = System.IO.Path.GetTempPath() + "temp.docx";
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
        public List<Contract> GetExcelItems(string pathToExcelFile = "")
        {
            var di = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            pathToExcelFile = di.Parent.Parent.Parent.FullName + @"\Docs\курсовая для работы\Книга регистрации клиентов.xlsx";

            var contracts = new List<Contract>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(pathToExcelFile, false))
            {
                int i = 0;
                WorkbookPart wbPart = doc.WorkbookPart;
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
      Where(s => s.Name == "договоры").FirstOrDefault();
                WorksheetPart wsPart =
               (WorksheetPart)(wbPart.GetPartById(theSheet.Id));
                foreach (Row r in wsPart.Worksheet.Descendants<Row>())
                {
                    i++;
                    if (r.Elements<Cell>().ElementAt(0).DataType != null)
                    {
                        try
                        {
                            contracts.Add(new Contract()
                            {
                                RowNomer = int.Parse(r.Elements<Cell>().ElementAt(0).CellValue.Text),
                                Date = DateTime.Parse(r.Elements<Cell>().ElementAt(1).CellValue.Text),
                                ContractId = r.Elements<Cell>().ElementAt(2).CellValue.Text,
                                CompanyName = r.Elements<Cell>().ElementAt(3).CellValue.Text,
                                CurrencyContractId = r.Elements<Cell>().ElementAt(4).CellValue.Text,
                                RegDateCurrContract = DateTime.Parse(r.Elements<Cell>().ElementAt(5).CellValue.Text),
                                SummaryPayment = double.Parse(r.Elements<Cell>().ElementAt(6).CellValue.Text),
                                ContractCurrency = r.Elements<Cell>().ElementAt(7).CellValue.Text,
                                ContractPayment = r.Elements<Cell>().ElementAt(8).CellValue.Text,
                                CountryOfRegister = r.Elements<Cell>().ElementAt(9).CellValue.Text,
                                DateOfContract = DateTime.Parse(r.Elements<Cell>().ElementAt(10).CellValue.Text),
                                UserId = r.Elements<Cell>().ElementAt(11).CellValue.Text,
                                PaymentType = r.Elements<Cell>().ElementAt(12).CellValue.Text,
                                Reward = r.Elements<Cell>().ElementAt(13).CellValue.Text,
                                IsYearWork = bool.Parse(r.Elements<Cell>().ElementAt(14).CellValue.Text),
                            });

                        }
                        catch (Exception)
                        {

                            continue;
                        }
                    }
                }
            }

            return contracts;
        }
    }
}
