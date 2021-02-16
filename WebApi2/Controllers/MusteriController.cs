using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private Context _context;
        public MusteriController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public object viewAllCustomers()
        {
            return _context.Musteris.ToList();
        }

        [HttpGet("{customerId}")]
        public object viewCustomerById(int customerId)
        {
            return _context.Musteris.Find(customerId);
        }

        [HttpGet("{customerId}")]
        public object viewAllProductByCustomerId(int customerId)
        {
            var result = (from su in _context.SepetUruns
                          join s in _context.Sepets on su.SepetId equals s.SepetId
                          join m in _context.Musteris on s.MusteriId equals m.MusteriId
                          where m.MusteriId == customerId
                          select new
                          {
                              CustomerId = m.MusteriId,
                              CustomerFirstName = m.Ad,
                              CustomerLastName = m.Soyad,
                              CustomerCity = m.Sehir,
                              BasketId = s.SepetId,
                              BasketProductId = su.SepetUrunId,
                              Price = su.Tutar,
                              Decription = su.Aciklama,
                          }).ToList();

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("{customerId}")]
        public object sumByCustomerId(int customerId)
        {
            var total = (from su in _context.SepetUruns
                         join s in _context.Sepets on su.SepetId equals s.SepetId
                         join m in _context.Musteris on s.MusteriId equals m.MusteriId
                         where m.MusteriId == customerId
                         select new
                         {
                             CustomerId = m.MusteriId,
                             CustomerFirstName = m.Ad,
                             CustomerLastName = m.Soyad,
                             CustomerCity = m.Sehir,
                             BasketId = s.SepetId,
                             BasketProductId = su.SepetUrunId,
                             Price = su.Tutar,
                             Decription = su.Aciklama,
                         }).Sum(x => x.Price);

            return total;
        }

        [HttpGet("{customerId}")]
        public object averageByCustomerId(int customerId)
        {
            var average = (from su in _context.SepetUruns
                           join s in _context.Sepets on su.SepetId equals s.SepetId
                           join m in _context.Musteris on s.MusteriId equals m.MusteriId
                           where m.MusteriId == customerId
                           select new
                           {
                               CustomerId = m.MusteriId,
                               CustomerFirstName = m.Ad,
                               CustomerLastName = m.Soyad,
                               CustomerCity = m.Sehir,
                               BasketId = s.SepetId,
                               BasketProductId = su.SepetUrunId,
                               Price = su.Tutar,
                               Decription = su.Aciklama,
                           }).Average(x => x.Price);

            return average;
        }

        [HttpGet("{productName}")]
        public object viewCustomerByProductName(string productName)
        {
            var average = (from su in _context.SepetUruns
                           join s in _context.Sepets on su.SepetId equals s.SepetId
                           join m in _context.Musteris on s.MusteriId equals m.MusteriId
                           where su.Aciklama == productName
                           select new
                           {
                               CustomerId = m.MusteriId,
                               CustomerFirstName = m.Ad,
                               CustomerLastName = m.Soyad,
                               CustomerCity = m.Sehir,
                               BasketId = s.SepetId,
                               BasketProductId = su.SepetUrunId,
                               Price = su.Tutar,
                               Decription = su.Aciklama,
                           }).ToList();

            return average;
        }

        [HttpGet("{city}")]
        public object viewCustomerByCity(string city)
        {
            var viewCity = (from m in _context.Musteris
                            where m.Sehir == city
                            select new
                            {
                                CustomerId = m.MusteriId,
                                CustomerFirstName = m.Ad,
                                CustomerLastName = m.Soyad,
                                CustomerCity = m.Sehir,
                            }).ToList();

            return viewCity;
        }
    }
}
