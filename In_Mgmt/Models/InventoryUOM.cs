using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace In_Mgmt.Models
{
    public class InventoryUOM
    {
        [Key]
        public int IUOMID { get; set; }

        [Required(ErrorMessage = "IUOM Name is required")]
        public string IUOM_Name { get; set; }

        [Required(ErrorMessage = "IUOM Code is required")]
        [DisplayName("IUOM Code:")]
        public string SUOM_Code { get; set; }

        [DisplayName("Factor:")]
        [Required(ErrorMessage = "Factory is required")]
        public int Factor { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}