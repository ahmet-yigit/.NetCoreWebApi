using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class DtoSehirAnaliz
    {
        [Key]
        public int id { get; set; }
        public string SehirAdi { get; set; }
        public int SepetAdet { get; set; }
        public int ToplamTutar { get; set; }
    }
}
