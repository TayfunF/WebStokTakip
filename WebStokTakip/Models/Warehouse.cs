using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStokTakip.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DisplayName("Depo Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DisplayName("Depo Kapasitesi")]
        public int Capacity { get; set; }

        [DisplayName("Kullanılıyor Mu ?")]
        public bool IsActive { get; set; }

        public virtual List<Shelf> Shelves { get; set; }
    }
}