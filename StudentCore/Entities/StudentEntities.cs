using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCore.Entities
{
    public class StudentEntities
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DatOfBirth { get; set; }
        public string Email { get; set; }
    }
}
