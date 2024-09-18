namespace maras_mesaha_pdf_extraction.PdfExtraction.Record
{
    public interface IDetailRecord : IRecord
    { 
        IRecord ParentRecord { get; set; }
        IRecord YearParent {  get; set; }

    }
}
