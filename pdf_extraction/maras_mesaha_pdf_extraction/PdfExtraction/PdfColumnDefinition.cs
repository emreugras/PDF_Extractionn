using System.Security.Policy;

namespace maras_mesaha_pdf_extraction.PdfExtraction
{
    public delegate string ColumnValueModifierDelegate(string valueToModify);

    public class PdfColumnDefinition
    {
        public ColumnValueModifierDelegate ValueModifierMethod { get; set; }
        public int StartCol { get; set; }
        public int EndCol { get; set; }
        public string Header { get; set; }
        public bool IsNumeric { get; set; }

        public override string ToString()
        {
            return $"{Header} - [{StartCol}-{EndCol}]";
        }
    }
}
