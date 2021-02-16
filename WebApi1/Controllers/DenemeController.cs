using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        private readonly Context _context;

        public DenemeController(Context context)
        {
            _context = context;
        }


        [HttpPost]
        public object testVerisiOlustur(int MusteriAdet, int SepetAdet)
        {
            string[] ad = { "Ahmet", "Ali", "Ayşe", "Yakup", "Yıldız" };
            string[] Soyad = { "Çınar", "Barut", "Çiçek", "Yılmaz", "Aslan" };
            string[] sehir = { "Ankara", "İstanbul", "İzmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakır", "Van", "Rize" };
            create c = new create(_context);
            Random rnd = new Random();
            List<int> customerList = new List<int>();

            //addCustomer Code
            for (int i = 0; i < MusteriAdet; i++)
            {
                int rndAdIndex = rnd.Next(0, ad.Length);
                int rndSoyadIndex = rnd.Next(0, Soyad.Length);
                int rndSehirIndex = rnd.Next(0, sehir.Length);
                string name = ad[rndAdIndex];
                string surname = Soyad[rndAdIndex];
                string city = sehir[rndAdIndex];
                c.createMusteri(name, surname, city, customerList);
            }

            //add Basket and Product Code
            List<int> basketList = new List<int>();
            string[] productArray = { "Laptop", "Telefon", "Araba" };
            for (int i = 0; i < SepetAdet; i++)
            {
                int rndBasketQuantity = rnd.Next(1, 5);
                int customerId = customerList[rnd.Next(0, customerList.Count)];
                int returnBasketId = Convert.ToInt32(c.createBasket(customerId).ToString());
                for (int j = 0; j < rndBasketQuantity; j++)
                {
                    decimal Price = rnd.Next(100, 1000);
                    string Description = productArray[rnd.Next(0, productArray.Length)];
                    c.createProduct(returnBasketId, Price, Description);
                }
            }
            return Ok();
        }
        [HttpGet]
        public object SehirBazliAnalizYap()
        {
            return (from cus in _context.Musteris
                         join bas in _context.Sepets on cus.MusteriId equals bas.MusteriId
                         join pro in _context.SepetUruns on bas.SepetId equals pro.SepetId
                         select new { cus.Sehir, bas.SepetId, pro.Tutar } into x
                         group x by new { x.Sehir } into g
                         select new
                         {
                             SehirAdi = g.Key.Sehir,
                             SepetAdet = g.Select(x => x.SepetId).Count(),
                             ToplamTutar = g.Select(x => x.Tutar).Sum()
                         }).OrderByDescending(x => x.SepetAdet).ToList(); ;
        }
    }
}
