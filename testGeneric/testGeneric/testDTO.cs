using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGeneric
{
    public class TestDTO
    {
        [Description("ID")]
        public long? Id { get; set; }
        [Description("NAME")]
        public string Name { get; set; }
    }
}
