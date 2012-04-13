using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace In_Mgmt.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        [Required]
        [DisplayName("Location Name:")]
        public string LocationName { get; set; }

        [Required]
        [DisplayName("Location Code:")]
        public string LocationCode { get; set; }
        
        //foreign key
        public int ContainerID { get; set; }
        [DisplayName("Container:")]
        public virtual Container Container { get; set; }
       
    }
}