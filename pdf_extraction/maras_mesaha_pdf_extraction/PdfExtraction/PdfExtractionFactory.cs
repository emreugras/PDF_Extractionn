using iText.Kernel.Pdf.Canvas.Parser.Listener;
using maras_mesaha_pdf_extraction.Implementations.NedoSys.Sssolo;

using System.Collections.Generic;
using System.Linq;

namespace maras_mesaha_pdf_extraction.PdfExtraction
{
    public class PdfExtractionFactory
    {
        public static (ITextExtractionStrategy, string) GetStrategyAndHeaders(PdfExtractionStrategyTypes type)
        {
            ITextExtractionStrategy result = null;
            string headers = "";


            if (type == PdfExtractionStrategyTypes.SssolMesaha)
            {
                var nedoSssoloFunctions = new Dictionary<NedoSysRowTypes, NedoSysRowTypeDecisionDelegate>
                {
                    { NedoSysRowTypes.PageTitle, (input) => { return input.StartsWith("MESAHA LİSTESİ"); } },
                    { NedoSysRowTypes.ParentHeader, (input) => { return input.StartsWith("T.C."); } },
                    { NedoSysRowTypes.ParentRow, (input) => { return input.Contains("****"); } },
                    { NedoSysRowTypes.DetailHeader, (input) => { return input.Contains("2024"); } },
                    /*{ NedoSysRowTypes.YearHeader, (input) => { return input.StartsWith("2024"); } }*/
                            { NedoSysRowTypes.DetailRow, (input) => { return input.Contains("ÜRÜN"); } },
                };

                result = new NedoSysRecordExtractionStrategy<SssolMesahaCiftciRecord, SssolMesahaRecord>
                 (
                    SssolMesahaCiftciRecord.ColumnDenifinitions.FirstOrDefault(x => x.Header == "Ekim Alanı"),
                    new System.Globalization.CultureInfo("en-EN"),
                    nedoSssoloFunctions,
                    7f,
                    3f
                 );

                headers = SssolMesahaCiftciRecord.GetHeaderCsv() + SssolMesahaRecord.GetHeaderCsv();
            }

            //    if (type == PdfExtractionStrategyTypes.NedoSysMarasMesaha)
            //    {
            //        var nedoSysMarasRowTypeDecideFuntions = new Dictionary<NedoSysRowTypes, NedoSysRowTypeDecisionDelegate>
            //        {
            //            { NedoSysRowTypes.PageTitle, (input) => { return input.StartsWith("MESAHA LİSTESİ"); } },
            //            { NedoSysRowTypes.ParentHeader, (input) => { return input.StartsWith("T.C."); } },
            //            { NedoSysRowTypes.ParentRow, (input) => { return input.Contains("****"); } },
            //            { NedoSysRowTypes.DetailHeader, (input) => { return input.StartsWith("YILI"); } },
            //            { NedoSysRowTypes.DetailRow, (input) => { return input.StartsWith("2024"); } }
            //        };

            //        result = new NedoSysRecordExtractionStrategy<NedoSysMarasCiftciRecord, NedoSysMarasMesahaRecord>
            //         (
            //            NedoSysMarasMesahaRecord.Columns.FirstOrDefault(x => x.Header == "Ekim Alanı"),
            //            new System.Globalization.CultureInfo("en-EN"),
            //            nedoSysMarasRowTypeDecideFuntions,
            //            7f,
            //            3f
            //         );

            //        headers = NedoSysMarasCiftciRecord.GetHeaderCsv() + NedoSysMarasMesahaRecord.GetHeaderCsv();
            //    }


            //    if (type == PdfExtractionStrategyTypes.NedoSysKozanMesaha)
            //    {
            //        var nedoSysRowTypeDecideFuntions = new Dictionary<NedoSysRowTypes, NedoSysRowTypeDecisionDelegate>
            //        {
            //            { NedoSysRowTypes.PageTitle, (input) => { return input.StartsWith("MESAHA LİSTESİ"); } },
            //            { NedoSysRowTypes.ParentHeader, (input) => { return input.StartsWith("T.C."); } },
            //            { NedoSysRowTypes.ParentRow, (input) => { return input.Contains("***"); } },
            //            { NedoSysRowTypes.DetailHeader, (input) => { return input.StartsWith("YILI"); } },
            //            { NedoSysRowTypes.DetailRow, (input) => { return input.StartsWith("2024"); } }
            //        };

            //        result = new NedoSysRecordExtractionStrategy<NedoSysKozanMesahaCiftciRecord, NedoSysKozanMesahaRecord>
            //         (
            //            NedoSysKozanMesahaRecord.Columns.FirstOrDefault(x => x.Header == "Ekim Alanı"),
            //            new System.Globalization.CultureInfo("en-EN"),
            //            nedoSysRowTypeDecideFuntions,
            //            6f,
            //            3f
            //         );

            //        headers = NedoSysKozanMesahaCiftciRecord.GetHeaderCsv() + NedoSysKozanMesahaRecord.GetHeaderCsv();
            //    }

            //    if (type == PdfExtractionStrategyTypes.NedoSysKozanBeyan)
            //    {
            //        var nedoSysRowTypeDecideFuntions = new Dictionary<NedoSysRowTypes, NedoSysRowTypeDecisionDelegate>
            //        {
            //            { NedoSysRowTypes.PageTitle, (input) => { return input.StartsWith("2024 YILI BEYAN LİSTESİ"); } },
            //            { NedoSysRowTypes.ParentHeader, (input) => { return input.StartsWith("T.C."); } },
            //            { NedoSysRowTypes.ParentRow, (input) => { return input.Contains("***"); } },
            //            { NedoSysRowTypes.DetailHeader, (input) => { return input.StartsWith("YILI"); } },
            //            { NedoSysRowTypes.DetailRow, (input) => { return input.StartsWith("2024"); } }
            //        };

            //        result = new NedoSysRecordExtractionStrategy<NedoSysKozanBeyanCiftciRecord, NedoSysKozanBeyanRecord>
            //         (
            //            NedoSysKozanBeyanRecord.Columns.FirstOrDefault(x => x.Header == "Ekim Alanı"),
            //            new System.Globalization.CultureInfo("en-EN"),
            //            nedoSysRowTypeDecideFuntions,
            //            6f,
            //            3f
            //         );

            //        headers = NedoSysKozanBeyanCiftciRecord.GetHeaderCsv() + NedoSysKozanBeyanRecord.GetHeaderCsv();
            //    }


            return (result, headers);
        }
    }
}
