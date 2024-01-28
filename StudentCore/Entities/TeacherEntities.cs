using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCore.Entities
{
    public class TeacherEntities
    {
        public int T_id { get; set; }
        public string teacherName { get; set; }
        public string teacherLastName { get; set; }
        public string teacherEmail { get; set; }
    }
}
