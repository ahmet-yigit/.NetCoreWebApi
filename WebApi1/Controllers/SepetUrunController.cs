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
    public class SepetUrunController : ControllerBase
    {
        private readonly Context _context;

        public SepetUrunController(Context context)
        {
            _context = context;
        }
        //tüm ürünleri görüntüleme
        [HttpGet]
        public List<SepetUrun> viewAllBasketProducts()
        {
            return _context.SepetUruns.ToList();
        }

        //basketProductId'ye sepetteki seçili ürünü getirir
        [HttpGet("{basketProductId}")]
        public SepetUrun viewBasketProductById(int basketProductId)
        {
            var dgr = _context.SepetUruns.Find(basketProductId);
            return dgr;
        }

        //sepet ıd ye göre ekleme yapmak için bir sepet Id verilmeli
        [HttpPost("{sepetId}")]
        public ActionResult addBasketWithBasketId([FromBody] SepetUrun sepetUrun, int sepetId)
        {
            try
            {
                var dgr = new SepetUrun
                {
                    SepetId = sepetId,
                    Tutar = sepetUrun.Tutar,
                    Aciklama = sepetUrun.Aciklama
                };
                _context.SepetUruns.Add(dgr);
                _context.SaveChanges();
                return Ok(dgr);
            }
            catch (Exception)
            {
                return BadRequest("Ekleme Başarısız");
            }
        }

        //musteri ıd ye göre eekleme yapmak için url e bir müşteri ıd verilmeli
        [HttpPost("{musteriId}")]
        public ActionResult addBasketWithCustomerId([FromBody] SepetUrun sepetUrun, int musteriId)
        {
            try
            {
                var dgr = new Sepet { MusteriId = musteriId };
                _context.Sepets.Add(dgr);
                _context.SaveChanges();
                return Ok(addBasketWithBasketId(sepetUrun, dgr.SepetId));
            }
            catch (Exception)
            {
                return BadRequest("Ekleme Başarısız");
            }
        }


        
    }
}
