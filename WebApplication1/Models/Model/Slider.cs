using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderID{ get; set; }
        [Display(Name = "Slider Başlık"),StringLength(30,ErrorMessage ="30 Karakter Olmalıdır")]
        public string Baslik { get; set; }
        [Display(Name = "Slider Açıklama"),StringLength(150,ErrorMessage ="150 Karakter olmalıdır")]
        public string Aciklama { get; set; }
        [Display(Name = "Slider Resim"),StringLength(250)] 
        public string ResimURL { get; set; }
    }
}