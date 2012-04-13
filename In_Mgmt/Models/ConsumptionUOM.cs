using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace In_Mgmt.Models
{
    public class ConsumptionUOM
    {
        [Key]
        public int CUOMID { get; set; }
                
        [Required(ErrorMessage = "CUOM Name is required")]
        public string CUOM_Name { get; set; }

        [Required(ErrorMessage = "UOM Code is required")]
        [DisplayName("CUOM Code:")]
        public string CUOM_Code { get; set; }

        [DisplayName("Factor:")]
        [Required(ErrorMessage = "Factory is required")]
        public int Factor { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        
    }


    public class StoredUOM
    {
        [Key]
        public int SUOMID { get; set; }

        [Required(ErrorMessage = "SUOM Name is required")]
        public string SUOM_Name { get; set; }

        [Required(ErrorMessage = "SUOM Code is required")]
        [DisplayName("SUOM Code:")]
        public string SUOM_Code { get; set; }

        [DisplayName("Factor:")]
        [Required(ErrorMessage = "Factory is required")]
        public int Factor { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }

    public class DisplayUOM
    {
        [Key]
        public int DUOMID { get; set; }

        [Required(ErrorMessage = "DUOM Name is required")]
        public string DUOM_Name { get; set; }

        [Required(ErrorMessage = "SUOM Code is required")]
        [DisplayName("DUOM Code:")]
        public string DUOM_Code { get; set; }

        [DisplayName("Factor:")]
        [Required(ErrorMessage = "Factory is required")]
        public int Factor { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}