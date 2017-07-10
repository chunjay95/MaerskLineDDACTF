using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaerskLineDDACTF.Models
{
    public class Ship
    {
        public int ShipID { get; set; }

        public String ShipName { get; set; }

        public int Capacity { get; set; }

        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}