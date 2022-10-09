using System;
using System.Collections.Generic;

#nullable disable

namespace QLD.Models
{
    public partial class Hocsinh
    {
        public Hocsinh()
        {
            Diems = new HashSet<Diem>();
        }

        public int Id { get; set; }
        public string Mssv { get; set; }
        public string Fullname { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
    }
}
