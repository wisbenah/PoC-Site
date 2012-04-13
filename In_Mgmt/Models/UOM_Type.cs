using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace In_Mgmt.Models
{
    [DisplayName("UOM Type:")]
    public class UOM_Type
    {
        [Key]
        public int UOM_TypeID { get; set; }

        [Required, StringLength(20, ErrorMessage = "UOM Code is required")]
        [DisplayName("UOM Type Name:")]
        public string UOM_Type_Name { get; set; }
                
        public virtual ICollection<UOM> UOMs { get; set; }

    }
}