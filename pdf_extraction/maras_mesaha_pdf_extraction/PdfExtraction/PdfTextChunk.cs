using iText.Kernel.Geom;

namespace maras_mesaha_pdf_extraction.PdfExtraction
{
    public class PdfTextChunk
    {
        public string Text { get; }
        public Vector Position { get; }

        public float Col { get { return Position.Get(0); } }
        public float Row { get { return Position.Get(1); } }

        public PdfTextChunk(string text, Vector position)
        {
            Text = text;
            Position = position;
        }
    }

}
