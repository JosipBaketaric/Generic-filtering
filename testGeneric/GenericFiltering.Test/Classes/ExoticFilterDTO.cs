using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFiltering.Test.Classes
{
    public class ExoticFilterDTO
    {
        public float FloatProp { get; set; }

        [Description("FLOAT_PROP_NULLABLE")]
        public float? FLOAT_PROP_NULLABLE { get; set; }

        [Description("DOUBLE_PROP")]
        public double DOUBLE_PROP { get; set; }

        [Description("DOUBLE_PROP_NULLABLE")]
        public double? DOUBLE_PROP_NULLABLE { get; set; }

        [Description("SHORT_PROP")]
        public short SHORT_PROP { get; set; }

        [Description("SHORT_PROP_NULLABLE")]
        public short? SHORT_PROP_NULLABLE { get; set; }

        [Description("LONG_PROP")]
        public long LONG_PROP { get; set; }

        [Description("LONG_PROP_NULLABLE")]
        public long? LONG_PROP_NULLABLE { get; set; }

        [Description("BYTE_PROP")]
        public byte BYTE_PROP { get; set; }

        [Description("BYTE_PROP_NULLABLE")]
        public byte? BYTE_PROP_NULLABLE { get; set; }

        [Description("SBYTE_PROP")]
        public sbyte SBYTE_PROP { get; set; }

        [Description("SBYTE_PROP_NULLABLE")]
        public sbyte? SBYTE_PROP_NULLABLE { get; set; }

        [Description("UINT_PROP")]
        public uint UINT_PROP { get; set; }

        [Description("UINT_PROP_NULLABLE")]
        public uint? UINT_PROP_NULLABLE { get; set; }

        [Description("ULONG_PROP")]
        public ulong ULONG_PROP { get; set; }

        [Description("ULONG_PROP_NULLABLE")]
        public ulong? ULONG_PROP_NULLABLE { get; set; }

        [Description("USHORT_PROP")]
        public ushort USHORT_PROP { get; set; }

        [Description("USHORT_PROP_NULLABLE")]
        public ushort? USHORT_PROP_NULLABLE { get; set; }
    }
}
