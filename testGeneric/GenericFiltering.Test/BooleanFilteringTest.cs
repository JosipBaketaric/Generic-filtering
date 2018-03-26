using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GenericFiltering.Test
{
    [TestClass]
    public class BooleanFilteringTest
    {




        [TestMethod]
        public void TestFilterBool()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });


            var filter = new FilterDTO();
            filter.BoolProp = true;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterBoolDefault()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });


            var filter = new FilterDTO();
            filter.BoolProp = false;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(2, rez.Count);
        }






    }
}
