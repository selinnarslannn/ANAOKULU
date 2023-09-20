using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaokuluKatmanli.Model.Models
{
    public class Dersler
    {
        [Key]
        public int DersID { get; set; }
     

        [ForeignKey("Ogretmenler")]//fk tanımlamak için
        public int OgretmenID { get; set; }//fk tanımlamak içn
       
        public virtual Ogretmenler Ogretmenler { get; set; } //sanal:virtual 
        public string DersAdi { get; set; }
        //[StringLength(25), Required]
        public int YasGrubu { get; set; }
        public string Konu { get; set; }
    }
}
