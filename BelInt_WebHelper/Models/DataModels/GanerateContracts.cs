using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
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
        public List<Contract> GetExcelItems(string pathToExcelFile = @"C:\Users\Doctor\Source\Repos\boyvano\BelInt_WebHelper\BelInt_WebHelper\Docs\курсовая для работы\Книга регистрации клиентов.xlsx")
        {


            return null;
        }
    }
}
