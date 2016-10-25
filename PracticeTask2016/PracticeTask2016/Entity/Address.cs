using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask2016.Entity
{
    [Serializable]
    public class Address
    {
        public string street { get; set; }
        public ushort house { get; set; }
        public ushort apartment { get; set; }

        public override string ToString()
        {
            return street + ' ' + house + '/' + apartment;
        }
    }    
}
