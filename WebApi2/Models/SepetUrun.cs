using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi2.Models
{
    public class SepetUrun
    {
        [Key]
        public int SepetUrunId { get; set; }
        public int SepetId { get; set; }
        [JsonIgnore]
        public Sepet Sepet { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}
