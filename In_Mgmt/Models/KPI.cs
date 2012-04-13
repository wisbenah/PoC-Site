using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace In_Mgmt.Models
{
    public class KPI
    {
        [Key]
        public int KPIID { get; set; }
        
        [Required]
        [StringLength(40, ErrorMessage = "KPI Code cannot be longer than 40 characters.")]
        [Remote("ValidateKPICode", "Home", AdditionalFields = "InitialKCode, KPIID, ContainerID, InitialCID", HttpMethod = "POST", ErrorMessage = "KPI Code already exists!")]
        [DisplayName("KPI Code:")]
        public string KPI_Code { get; set; }

        // validation
        [ScaffoldColumn(false)]
        public string InitialKCode { get; set; }

        // validation
        [ScaffoldColumn(false)]
        public string InitialCID { get; set; }
                
        //[Required]
        [StringLength(80, ErrorMessage = "KPI Name cannot be longer than 80 characters.")]
        [DisplayName("KPI Name:")]
        public string KPI_Name { get; set; }

        [Required]
        [DisplayName("Percentage: (include Zero & Period ahead)"), DisplayFormat(ApplyFormatInEditMode=false, 
            DataFormatString= "{0:0%}")]
        [Range(0.001, 1)]
        public decimal Percentage { get; set; }

        //Foriegn key
        public int ContainerID { get; set; } //display on kpi
        public virtual Container Container { get; set; } //display on kpi
                
        public virtual ICollection<Container> Containers { get; set; }
        


    }
}