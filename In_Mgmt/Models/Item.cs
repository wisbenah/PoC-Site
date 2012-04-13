using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace In_Mgmt.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [DisplayName("Item Code:")]
        public string ItemCode { get; set; }

        [Required]
        [DisplayName("Item Name:")]
        public string ItemName { get; set; }

        public int CUOMID { get; set; }
        public virtual ConsumptionUOM ConsumptionUOM { get; set; }

        public int IUOMID { get; set; }
        public virtual InventoryUOM InventoryUOM { get; set; }

        public int SUOMID { get; set; }
        public virtual StoredUOM StoredUOMs { get; set; }

        public int DUOMID { get; set; }
        public virtual DisplayUOM DisplayUOMs { get; set; }

        [DisplayName("Container & Location:")]
        public string ContainerLocation { get; set; }
    }
}