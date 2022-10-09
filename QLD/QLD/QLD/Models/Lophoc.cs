using System;
using System.Collections.Generic;

#nullable disable

namespace QLD.Models
{
    public partial class Lophoc
    {
        public Lophoc()
        {
            Diems = new HashSet<Diem>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Class { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
    }
}
