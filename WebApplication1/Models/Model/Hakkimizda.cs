using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Model
{
    [Table("Hakkimizda")]
    public class Hakkimizda
    {
        [Key]
        public int HakkimizdaID { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karekter olmalıdır")]
        [DisplayName( "Acıklama")]
        public string Aciklama { get; set; }
    }
}