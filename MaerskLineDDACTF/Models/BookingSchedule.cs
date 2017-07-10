using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaerskLineDDACTF.Models
{
    public class BookingSchedule
    {
        public int BookingScheduleID { get; set; }

        [ForeignKey("Ship")]
        public int ShipID { get; set; }
        public Ship Ship { get; set; }

        [ForeignKey("Container")]
        public int ContainerID { get; set; }
        public Container Container { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [ForeignKey("Yard")]
        public int YardID { get; set; }
        public virtual Yard Yard { get; set; }

        [ForeignKey("Yard1")]
        public int Yard1ID { get; set; }
        public virtual Yard Yard1 { get; set; }

        [DataType(DataType.Currency)]
        public float TotalPrice { get; set; }
    }
}