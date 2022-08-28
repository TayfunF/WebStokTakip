using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStokTakip.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }

        [DisplayName("Kullanılıyor Mu ?")]
        public bool IsActive { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}