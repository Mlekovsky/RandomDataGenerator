using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Thotelinfo
    {
        public int Id { get; set; }
        public int? ThotelId { get; set; }
        public string Description { get; set; }
        public int? TlanguageId { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        public virtual Thotel Thotel { get; set; }
        public virtual Tlanguage Tlanguage { get; set; }
    }
}
