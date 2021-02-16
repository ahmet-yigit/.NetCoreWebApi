using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.Services
{
    public class create
    {
        private readonly Context _context;

        public create(Context context)
        {
            _context = context;
        }


        public object createMusteri(string name, string surname, string city, List<int> customerList)
        {
            var dgr = new Musteri { Ad = name, Soyad = surname, Sehir = city };
            _context.Musteris.Add(dgr);
            _context.SaveChanges();
            customerList.Add(dgr.MusteriId);
            return customerList;
        }
        public object createBasket(int musteriId)
        {
            var dgr = new Sepet { MusteriId = musteriId };
            _context.Sepets.Add(dgr);
            _context.SaveChanges();
            return dgr.SepetId;
        }

        public object createProduct(int basketId, decimal price, string description)
        {
            var dgr = new SepetUrun { SepetId = basketId, Tutar = price, Aciklama = description };
            _context.SepetUruns.Add(dgr);
            _context.SaveChanges();
            return true;
        }
        
    }
}
