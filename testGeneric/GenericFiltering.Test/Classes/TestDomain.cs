using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFiltering.Test.Classes
{
    public class TestDomain
    {
        public long? ID { get; set; }
        public string NAME { get; set; }
        public DateTime? DATUM_TEST { get; set; }
        public int INT_PROP { get; set; }
        public decimal DECIMAL_PROP { get; set; }
        public char CHAR_PROP { get; set; }
        public bool BOOL_PROP { get; set; }
        public double DOUBLE_PROP { get; set; }
    }
}
