using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaokuluKatmanli.Model.Models
{
    public class Etkinlikler
    {
        [Key]
        public int EtkinlikID { get; set; }
 
        public string EtkinlikAdi { get; set; }
        //[StringLength(20), Required]
        public string Tarih { get; set; }
        public int YasGrubu { get; set; }



    }
}
