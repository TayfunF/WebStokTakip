using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStokTakip.Models
{
    public class Shelf
    {
        public Shelf()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DisplayName("Raf Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DisplayName("Raf Kapasitesi")]
        public int Capacity { get; set; }

        public int WarehouseId { get; set; }


        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Kullanılıyor Mu ?")]
        public bool IsActive { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}