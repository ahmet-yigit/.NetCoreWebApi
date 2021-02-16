using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private readonly Context _context;
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

        [HttpPost]
        public object addCustomer([FromBody]Musteri musteri)
        {
            var dgr = new Musteri { Ad = musteri.Ad, Soyad = musteri.Soyad, Sehir = musteri.Sehir };
            _context.Musteris.Add(dgr);
            _context.SaveChanges();
            return Ok(dgr);
        }

        [HttpPut("{customerId}")]
        public object updateCustomerById([FromBody]Musteri musteri,int customerId)
        {
            var dgr = _context.Musteris.FirstOrDefault(x => x.MusteriId == customerId);
            dgr.Ad = musteri.Ad;
            dgr.Soyad = musteri.Soyad;
            dgr.Sehir = musteri.Sehir;
            _context.SaveChanges();
            return Ok(dgr);
        }

        [HttpDelete("{customerId}")]
        public object deleteCustomerById(int customerId)
        {
            var dgr = _context.Musteris.FirstOrDefault(x => x.MusteriId == customerId);
            _context.Musteris.Remove(dgr);
            _context.SaveChanges();
            return Ok(dgr);
        }

        
    }
}
