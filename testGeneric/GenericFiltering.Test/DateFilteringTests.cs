using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GenericFiltering.Test
{
    [TestClass]
    public class DateFilteringTests
    {

        [TestMethod]
        public void TestFilterDateResultCount()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { DATUM_TEST = dateNow});
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });


            var filter = new FilterDTO();
            filter.DatumTest = dateNow;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        
    }
}
