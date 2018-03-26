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

        [Description("INT_PROP")]
        public int? IntProp { get; set; }

        [Description("DECIMAL_PROP")]
        public decimal? DecimalProp { get; set; }

        [Description("CHAR_PROP")]
        public char CharProp { get; set; }

        [Description("BOOL_PROP")]
        public bool? BoolProp { get; set; }

    }
}
