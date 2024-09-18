using maras_mesaha_pdf_extraction.PdfExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maras_mesaha_pdf_extraction
{
    public class PdfRowEstimator
    {
        public List<List<PdfTextChunk>> EstimateRows(List<PdfTextChunk> chunks, float eps, int minPoints)
        {
            var clusters = new List<List<PdfTextChunk>>();
            var visited = new HashSet<PdfTextChunk>();
            var noise = new List<PdfTextChunk>();

            foreach (var chunk in chunks)
            {
                if (visited.Contains(chunk))
                    continue;

                visited.Add(chunk);
                var neighbors = GetNeighbors(chunk, chunks, eps);

                if (neighbors.Count < minPoints)
                {
                    noise.Add(chunk);
                }
                else
                {
                    var cluster = new List<PdfTextChunk>();
                    ExpandCluster(chunk, neighbors, cluster, visited, chunks, eps, minPoints);
                    clusters.Add(cluster);
                }
            }

            return clusters;
        }

        private void ExpandCluster(PdfTextChunk chunk, List<PdfTextChunk> neighbors, List<PdfTextChunk> cluster, HashSet<PdfTextChunk> visited, List<PdfTextChunk> chunks, float eps, int minPoints)
        {
            cluster.Add(chunk);

            for (int i = 0; i < neighbors.Count; i++)
            {
                var neighbor = neighbors[i];

                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    var newNeighbors = GetNeighbors(neighbor, chunks, eps);

                    if (newNeighbors.Count >= minPoints)
                    {
                        neighbors.AddRange(newNeighbors);
                    }
                }

                if (!cluster.Contains(neighbor))
                {
                    cluster.Add(neighbor);
                }
            }
        }

        private List<PdfTextChunk> GetNeighbors(PdfTextChunk chunk, List<PdfTextChunk> chunks, float eps)
        {
            var neighbors = new List<PdfTextChunk>();

            foreach (var other in chunks)
            {
                if (Math.Abs(chunk.Row - other.Row) <= eps)
                {
                    neighbors.Add(other);
                }
            }

            return neighbors;
        }
    }

}
