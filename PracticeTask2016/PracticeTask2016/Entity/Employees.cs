using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask2016.Entity
{
    public class Employees
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime birthday { get; set; }
        public string phoneNumber { get; set; }
        public Adress adress { get; set; }
    }
}
