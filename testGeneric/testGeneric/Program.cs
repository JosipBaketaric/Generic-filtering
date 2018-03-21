using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateNow = DateTime.Now;

            var filter = new FilterDTO();
            filter.DatumTest = dateNow;
            filter.Id = 1;
            filter.Name = "da";

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da", ID = 1, DATUM_TEST = dateNow });
            domainList.Add(new TestDomain { NAME = "da", ID = 2, DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { NAME = "ne", ID = 3 , DATUM_TEST = dateNow.AddDays(2) });


            IQueryable<TestDomain> query = domainList.AsQueryable();

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.Greater));

            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, new List<string> { "DatumTest" }, customList);
            var rez = query.ToList();

        }
    }
}
