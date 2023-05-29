using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Model
{
    [Table("Urunler")]
    public class Urunler
    {
        [Key]
        public int UrunId { get; set; }
        [Required, StringLength(150, ErrorMessage = "150 karekter olmalıdır")]
        [DisplayName("Urun Baslik")]
        public string Baslik { get; set; }
        [DisplayName("Urun Aciklama")]
        public string Aciklama { get; set; }
        [DisplayName("Urun Resim")]
        public string ResimURL { get; set; }

    }
}