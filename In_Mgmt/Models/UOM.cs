using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.UI;
using System.Web.Mvc;

namespace In_Mgmt.Models
{
    public class UOM
    {
        [Key]
        public int UOMID { get; set; }
        
        [Required(ErrorMessage = "UOM Code is required")]
        [DisplayName("UOM Code:")]
        [Remote("ValidateUOMCode", "Home", AdditionalFields = "InitialCode, UOMID", HttpMethod = "POST", ErrorMessage = "UOM Code already exists!")]
        [StringLength(40, ErrorMessage = "UOM Code cannot be longer than 40 characters.")]
        public string UOM_Code { get; set; }
        
        // for validation
        [ScaffoldColumn(false)]
        public string InitialCode { get; set; }
        
        //[Required(ErrorMessage = "UOM Name is required")]
        [DisplayName("UOM Name:")]
        [StringLength(80, ErrorMessage = "UOM Name cannot be longer than 80 characters.")]
        public string UOM_Name { get; set; }
                
        [DisplayName("Factor:")]
        [Required(ErrorMessage = "Factor is required.")]
        public int Factor { get; set; }

        // Foreign key
        public int UOM_TypeID { get; set; }
        [DisplayName("UOM Type:")]
        public virtual UOM_Type UOM_Type { get; set; }

        public virtual ICollection<Container> Containers { get; set; }

    }
        
}