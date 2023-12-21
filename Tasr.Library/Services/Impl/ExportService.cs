using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasr.Library.Models;

namespace Tasr.Library.Services.Impl
{
    public class ExportService : IExportService
    {
        public async Task<string> ExportAsWord(ExportResult exportResult)
        {
            string documentName = exportResult.Time + ".docx";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            documentName);
            using (WordprocessingDocument document = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                // 添加主文档部分
                MainDocumentPart mainPart = document.AddMainDocumentPart();

                // 创建文档结构
                Document documentElement = new Document();
                Body body = new Body();


                Paragraph paragraph = new Paragraph(
                    new Run(
                        new Text($"创建日期: {exportResult.Time}"),
                        new Break(),
                        new Break(),
                        new Text($"原始内容: "),
                        new Break(),
                        new Text($"{exportResult.SourceResult}"),
                        new Break(),
                        new Break(),
                        new Text($"总结内容: "),
                        new Break(),
                        new Text($"{exportResult.SummaryResult}")
                    )
                );
                body.Append(paragraph);



                // 将文档结构添加到主文档部分
                documentElement.Append(body);
                mainPart.Document = documentElement;
            }
                
            return filePath;
        }
    }
}
