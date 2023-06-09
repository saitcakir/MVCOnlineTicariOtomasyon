using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; } = true;

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        public int KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}