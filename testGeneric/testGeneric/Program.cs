using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateNow = DateTime.Now;

            var filter = new filterDTO();
            filter.DatumTest = dateNow;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da", ID = 1, DATUM_TEST = dateNow });
            domainList.Add(new TestDomain { NAME = "da", ID = 2, DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { NAME = "ne", ID = 3 , DATUM_TEST = dateNow.AddDays(2) });


            IQueryable<TestDomain> query = domainList.AsQueryable();


            query = FilterMapper.SetFilters<TestDomain, filterDTO>(query, filter);
            var rez = query.ToList();

        }
    }
}
