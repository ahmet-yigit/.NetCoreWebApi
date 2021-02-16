using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class Sepet
    {
        [Key]
        public int SepetId { get; set; }
        public int MusteriId { get; set; }
        [JsonIgnore]
        public Musteri Musteri { get; set; }
        [JsonIgnore]
        public List<SepetUrun> SepetUrun { get; set; }
    }
}
