using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using webAlgaritmaCozumler.Models;

namespace webAlgaritmaCozumler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        VIndexSoruModel mm = new VIndexSoruModel();
            List<IndexBelirteci> birler = new List<IndexBelirteci>();
            List<IndexBelirteci> belirle = new List<IndexBelirteci>();
        List<IndexBelirteci> sinirDevamlari = new List<IndexBelirteci>();
        void  HesaplamaAsync()
        {
            for (int x = 0; x < mm.Soru.GetLength(0); x++)
            {
                for (int y = 0; y < mm.Soru.GetLength(1); y++)
                {
                    if (mm.Soru[x, y]== 1)
                    {                       
                        if (x == 0 || x == mm.Soru.GetLength(0)-1 || y == 0 || y == mm.Soru.GetLength(1)-1)
                        {
                            belirle.Add(new IndexBelirteci { Degeri = 1, xIndex = x, yIndex = y, Kalacak = true });
                        }
                        else
                        {
                            birler.Add(new IndexBelirteci { Degeri = 1, xIndex = x, yIndex = y, Kalacak = false });
                        }
                    }
                }
            }
            //mm.Cevaplar = belirle;

            foreach (var item in belirle)
            {
              Arama(item, 0);
            }
            belirle.AddRange(sinirDevamlari);
            mm.Cevaplar = birler.Where(s => s.Kalacak == false).ToList();
        }
        void Arama(IndexBelirteci _indexNo, int _yon)
        {

            if (_indexNo.xIndex > 1)
            {
                if (_yon != 2)
                {
                    if (mm.Soru[_indexNo.xIndex - 1, _indexNo.yIndex] == 1)
                    {
                        IndexBelirteci ss = birler.SingleOrDefault(s => s.xIndex == _indexNo.xIndex - 1 && s.yIndex == _indexNo.yIndex && s.Kalacak == false);
                        if (ss != null)
                        {
                            ss.Kalacak = true;
                            sinirDevamlari.Add(new IndexBelirteci() { xIndex = ss.xIndex, yIndex = ss.yIndex, Kalacak = true });
                             Arama(ss, 1);
                        }
                    }
                }
            }
            if (_indexNo.xIndex < mm.Soru.GetLength(0) - 2)
            {
                if (_yon != 1)
                {
                    if (mm.Soru[_indexNo.xIndex + 1, _indexNo.yIndex] == 1)
                    {
                        IndexBelirteci ss = birler.SingleOrDefault(s => s.xIndex == _indexNo.xIndex + 1 && s.yIndex == _indexNo.yIndex && s.Kalacak == false);
                        if (ss != null)
                        {
                            ss.Kalacak = true;
                            sinirDevamlari.Add(new IndexBelirteci() { xIndex = ss.xIndex, yIndex = ss.yIndex, Kalacak = true });
                             Arama(ss, 2);
                        }
                    }
                }
            }
            if (_indexNo.yIndex < mm.Soru.GetLength(1) - 2)
            {
                if (_yon != 3)
                {
                    if (mm.Soru[_indexNo.xIndex, _indexNo.yIndex + 1] == 1)
                    {
                        IndexBelirteci ss = birler.SingleOrDefault(s => s.xIndex == _indexNo.xIndex && s.yIndex == _indexNo.yIndex + 1 && s.Kalacak == false);
                        if (ss != null)
                        {
                            ss.Kalacak = true;
                            sinirDevamlari.Add(new IndexBelirteci() { xIndex = ss.xIndex, yIndex = ss.yIndex, Kalacak = true });
                             Arama(ss, 4);
                        }
                    }
                }
            }
            if (_indexNo.yIndex > 0)
            {
                if (_yon != 4)
                {
                    if (mm.Soru[_indexNo.xIndex, _indexNo.yIndex - 1] == 1)
                    {
                        IndexBelirteci ss = birler.SingleOrDefault(s => s.xIndex == _indexNo.xIndex && s.yIndex == _indexNo.yIndex - 1 && s.Kalacak == false);
                        if (ss != null)
                        {
                            ss.Kalacak = true;
                            sinirDevamlari.Add(new IndexBelirteci() { xIndex = ss.xIndex, yIndex = ss.yIndex, Kalacak = true });
                             Arama(ss, 3);
                        }
                    }
                }
            }
         
           
        }
        public IActionResult Index()
        {
            HesaplamaAsync();
            return View(mm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
