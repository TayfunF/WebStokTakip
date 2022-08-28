using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStokTakip.Models
{
    public class Product
    {
        public Product()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Kullanılıyor Mu ?")]
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public int ShelfId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Shelf Shelf { get; set; }
    }
}