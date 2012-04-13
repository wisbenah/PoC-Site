using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.ComponentModel;
using System.Web.Mvc;


namespace In_Mgmt.Models
{
    public class Container
    {
        [Key]
        public int ContainerID { get; set; }
        
        [Required(ErrorMessage = "Container Code is required.")]
        [DisplayName("Container Code:")]
        [Remote("ValidateContainerCode", "Home", AdditionalFields = "InitialCCode, ContainerID", HttpMethod = "POST", ErrorMessage = "Container Code already exists!")]
        [StringLength(40, ErrorMessage = "Container Code cannot be longer than 40 characters.")]
        public string ContainerCode { get; set; }

        // validation
        [ScaffoldColumn(false)]
        public string InitialCCode { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        [DisplayName("Container Name:")]
        [StringLength(80, ErrorMessage = "Container Name cannot be longer than 80 characters.")]
        public string ContainerName { get; set; }

        [Required(ErrorMessage = "Max Capacity is required.")]
        [DisplayName("Max Capacity:")]
        public int Max_Capacity { get; set; }

        //[Required(ErrorMessage = "Date Created is required.")]
        //[DisplayName("Date Created:")]
        //[DataType(DataType.Date)]
        //public DateTime DateCreated = DateTime.Now; //{ get; set; } 

        //Foriegn key
        [Required(ErrorMessage = "UOM is required.")]
        public int UOMID { get; set; }
        public virtual UOM UOM { get; set; }

        //Foriegn key
        public int KPIID { get; set; }
        //public virtual KPI KPI { get; set; } //display on container

        public virtual ICollection<KPI> KPIs { get; set; } //display on kpi
                
                               
    }
    
}