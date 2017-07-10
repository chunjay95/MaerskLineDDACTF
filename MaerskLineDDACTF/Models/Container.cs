using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaerskLineDDACTF.Models
{
    public class Container
    {
        public int ContainerID { get; set; }

        public String Description { get; set; }

        public String DetailedDescription { get; set; }

        public int AmountOfContainers { get; set; }

        public double TotalWeight { get; set; }
    }
}