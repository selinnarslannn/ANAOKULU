using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaokuluKatmanli.Model.Models
{
    public class Ogrenciler
    {
        [Key]
        public int OgrenciID { get; set; }

        [ForeignKey("Ogretmenler")]//fk tanımlamak için
        public int OgretmenID { get; set; }//fk tanımlamak içn
        public virtual Ogretmenler Ogretmenler { get; set; } //sanal:virtual 
        public string OgrenciAdsoyad { get; set; }
        public int Yas { get; set; }

    }
}
