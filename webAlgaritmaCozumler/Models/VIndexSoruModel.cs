using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAlgaritmaCozumler.Models
{
    public class VIndexSoruModel
    {
        public List<IndexBelirteci> Cevaplar { get; set; }
        public int[,] Soru { get; set; }

        public VIndexSoruModel()
        {
            Soru = new int[,] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 1, 1, 1, 1 } };
        }
    }
}
