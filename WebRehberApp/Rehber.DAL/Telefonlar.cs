namespace Rehber.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Telefonlar
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage="Numara alanı zorunlu bir alandır.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Numara alanı başında '0' olmadan 10 karakter olarak girilmeli.")]
        public string TelefonNo { get; set; }

        [Required(ErrorMessage = "İsim alanı zorunlu bir alandır.")]
        public string TelefonAdı { get; set; }
    }
}
