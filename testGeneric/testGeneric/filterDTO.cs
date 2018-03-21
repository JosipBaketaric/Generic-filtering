using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFiltering
{
    public class FilterDTO
    {
        [Description("NAME")]
        public string Name { get; set; }

        [Description("ID")]
        public long? Id { get; set; }
        
        [Description("DATUM_TEST")]
        public DateTime? DatumTest { get; set; }

    }
}
