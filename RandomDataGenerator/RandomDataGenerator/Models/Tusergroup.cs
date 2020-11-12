using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Tusergroup
    {
        public int Id { get; set; }
        public int TuserId { get; set; }
        public int TgroupId { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }

        public virtual Tgroup Tgroup { get; set; }
        public virtual Tuser Tuser { get; set; }
    }
}
