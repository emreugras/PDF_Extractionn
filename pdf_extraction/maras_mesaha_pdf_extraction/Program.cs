using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using maras_mesaha_pdf_extraction.PdfExtraction;

namespace maras_mesaha_pdf_extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfPath = @"C:\Users\Emre\Desktop\Sssol.pdf";
            string outputPath = @"D:\Noda\Projeler\AGROWORKS_CBS\DSI BOLGELER\ADANA BOLGE\KOZAN\2024\ALINAN VERI\KOZAN BEYAN 2024 22.08.2024.csv";


            //string pdfPath = @"D:\Noda\Projeler\AGROWORKS_CBS\DSI BOLGELER\ADANA BOLGE\KOZAN\2024\ALINAN VERI\KOZAN 2024 MESEHA 22.08.2024.pdf";
            //string outputPath = @"D:\Noda\Projeler\AGROWORKS_CBS\DSI BOLGELER\ADANA BOLGE\KOZAN\2024\ALINAN VERI\KOZAN 2024 MESEHA 22.08.2024.csv";

            //string pdfPath = @"D:\Noda\Projeler\AGROWORKS_CBS\DSI BOLGELER\MARAS BOLGE\KAHRAMANMARAS\MESAHA 2024.pdf";
            //string outputPath = @"D:\Noda\Projeler\AGROWORKS_CBS\DSI BOLGELER\MARAS BOLGE\KAHRAMANMARAS\MESAHA 2024_yeni.csv";

            //string pdfPath = @"D:\test_mesaha.pdf";
            //string outputPath = @"D:\test_mesaha_sonuclar.csv";
            ConvertToTextFile(pdfPath, outputPath);
        }

        static void ConvertToTextFile(string pdfPath, string outputCsvFile)
        {
            if (File.Exists(outputCsvFile))
                File.Delete(outputCsvFile);

            using (PdfReader pdfReader = new PdfReader(pdfPath))

            using (PdfDocument pdfDoc = new PdfDocument(pdfReader))
            {
                StringWriter stringWriter = new StringWriter();

                bool headerPrinted = false;

                var (strategy,headers) = PdfExtractionFactory.GetStrategyAndHeaders(PdfExtractionStrategyTypes.NedoSysKozanBeyan);

                for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                {
                    PdfPage pdfPage = pdfDoc.GetPage(page);
                    var text = PdfTextExtractor.GetTextFromPage(pdfPage, strategy);

                    //using (StreamWriter writer = new StreamWriter(outputCsvFile, true, Encoding.UTF8))
                    //{
                    //    if (!headerPrinted)
                    //    {
                    //        writer.WriteLine(headers);
                    //        headerPrinted = true;
                    //    }

                    //    writer.WriteLine(text);
                    //}
                    //Debug.WriteLine(page + " / " + pdfDoc.GetNumberOfPages() + " yazıldı");
                }
            }
        }
    }
}
