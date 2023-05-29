using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Model
{
    [Table("Kimlik")]
    public class Kimlik
    {
        [Key]
        public int KimlikId { get; set; }
      
        [DisplayName("Site Baslik")]
        [Required, StringLength(100, ErrorMessage = "100 karekter olmalıdır")]
        public string Ttile { get; set; }
        [DisplayName("Anahtar Kelimeler")]
        [Required, StringLength(100, ErrorMessage = "200 karekter olmalıdır")]
        public string Keywords { get; set; }
        [DisplayName("Site Açıklama")]
        [Required, StringLength(100, ErrorMessage = "300 karekter olmalıdır")]
        public string Description { get; set; }
        [DisplayName("Site Logo")]
        
        public string LogoURL { get; set; }
        [DisplayName("Site Unvan")]

        public string Unvan { get; set; }


    }
}