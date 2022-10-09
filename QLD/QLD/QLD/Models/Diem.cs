using System;
using System.Collections.Generic;

#nullable disable

namespace QLD.Models
{
    public partial class Diem
    {
        public int Id { get; set; }
        public int Teacher { get; set; }
        public int? Class { get; set; }
        public int? Subject { get; set; }
        public int? Student { get; set; }
        public int? Q1 { get; set; }
        public int? Q2 { get; set; }
        public int? Q3 { get; set; }

        public virtual Lophoc ClassNavigation { get; set; }
        public virtual Hocsinh StudentNavigation { get; set; }
        public virtual Monhoc SubjectNavigation { get; set; }
        public virtual Account TeacherNavigation { get; set; }
    }
}
