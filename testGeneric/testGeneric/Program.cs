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

            var filter = new filterDTO();
            filter.Name = "Da";
            filter.Id = 1;

            var list = new List<TestDTO>();
            list.Add(new TestDTO {Name="da" });
            list.Add(new TestDTO {Name = "da" });
            list.Add(new TestDTO {Name = "ne" });

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da", ID = 1 });
            domainList.Add(new TestDomain { NAME = "da", ID = 2 });
            domainList.Add(new TestDomain { NAME = "ne", ID = 1 });


            IQueryable<TestDomain> query = domainList.AsQueryable();


            query = FilterMapper.SetFilters<TestDomain, filterDTO>(query, filter);
            var rez = query.ToList();

        }
    }
}
