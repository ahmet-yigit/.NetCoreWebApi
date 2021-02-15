using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.DataConnections;
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
        public List<Musteri> viewAllCustomers()
        {
            return _context.Musteris.ToList();
        }

        
        [HttpGet("{musteriId}")]
        public Musteri viewCustomerById(int musteriId)
        {
            var dgr = _context.Musteris.Find(musteriId);
            return dgr;
        }

        
        [HttpPost]
        public ActionResult addCustomer([FromBody]Musteri musteri)
        {
            try
            {
                var dgr = new Musteri { Ad = musteri.Ad, Soyad = musteri.Soyad, Sehir = musteri.Sehir };
                _context.Musteris.Add(dgr);
                _context.SaveChanges();
                return Ok(dgr);
            }
            catch (Exception)
            {
                return BadRequest("Ekleme Başarısız");
            }
        }
    }
}
