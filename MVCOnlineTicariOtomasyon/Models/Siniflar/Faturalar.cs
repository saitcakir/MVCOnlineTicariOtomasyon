using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {

        [Key]
        public int Faturaİd { get; set; }

        [Column(TypeName = "nchar")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }
        public DateTime Tarih { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        public DateTime Saat { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}