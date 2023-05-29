using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Model
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key]
        public int IletisimID { get; set; }
        [StringLength(250,ErrorMessage ="250 Karekter olmalıdır")]
        public string Adres { get; set; }
        [StringLength(250, ErrorMessage = "250 Karekter olmalıdır")]
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
    }
}