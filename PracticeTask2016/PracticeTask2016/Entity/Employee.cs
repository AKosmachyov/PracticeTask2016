using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask2016.Entity
{
    [Serializable]
    public class Employee
    {
        public Employee()
        {
            address = new Address();
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime birthday { get; set; }
        public string phoneNumber { get; set; }
        public Address address { get; set; }
        [NonSerialized]
        public DateTime createDate = DateTime.Now;
    }
}
