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
        public int[,] soruBoya { get; set; }

        public VIndexSoruModel()
        {
            Soru = new int[,] {
                { 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0 },
                { 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
                { 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
        }
        public VIndexSoruModel(int xDiziBoyutu,int yDiziBoyutu)
        {      
            Soru =new int[xDiziBoyutu, yDiziBoyutu];
            Random rdm = new Random();
            for (int x = 0; x < Soru.GetLength(0); x++)
            {
                for (int y = 0; y < Soru.GetLength(1); y++)
                {
                    Soru[x, y] = rdm.Next(0, 2);
                }
            }
        }
    }
}
