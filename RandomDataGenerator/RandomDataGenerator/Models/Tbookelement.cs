using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Tbookelement
    {
        public int Id { get; set; }
        public int? TbookingId { get; set; }
        public int? TbookeltypeId { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? ThotelId { get; set; }
        public int? TflightId { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        public virtual Tbooking Tbooking { get; set; }
        public virtual Tflight Tflight { get; set; }
        public virtual Thotel Thotel { get; set; }
    }
}
