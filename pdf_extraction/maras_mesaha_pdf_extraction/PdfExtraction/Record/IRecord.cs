using System.Collections.Generic;

namespace maras_mesaha_pdf_extraction.PdfExtraction.Record
{
    public interface IRecord
    {
        List<PdfColumnDefinition> GetColumnDefinitions();

        void SetValue(PdfColumnDefinition column, string value);

        void SetValue(string columnName, string value);

        string GetValue(PdfColumnDefinition column);

        string ToCsv();
    }
}
