using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GenericFiltering.Test.Classes;
using QueryFiltering;
using QueryFiltering.Classes;

namespace GenericFiltering.Test
{
    [TestClass]
    public class TextWithToLowerTests
    {

        [TestMethod]
        public void TestFilterTextEqualsWithToLower()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da"});
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "Da" });
            domainList.Add(new TestDomain { NAME = "Ne" });
            domainList.Add(new TestDomain { NAME = "dA" });
            domainList.Add(new TestDomain { NAME = "Ne" });


            var filter = new FilterDTO();
            filter.Name = "da";

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(4, rez.Count);
        }

        [TestMethod]
        public void TestFilterTextEqualsWithToLowerWithNullValue()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "Da" });
            domainList.Add(new TestDomain { NAME = "Ne" });
            domainList.Add(new TestDomain { NAME = "dA" });
            domainList.Add(new TestDomain { NAME = "Ne" });
            domainList.Add(new TestDomain { NAME = null });



            var filter = new FilterDTO();
            filter.Name = "da";

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(4, rez.Count);
        }

        [TestMethod]
        public void TestFilterTextEqualsWithToLowerWithNullValueSecond()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "Da" });
            domainList.Add(new TestDomain { NAME = null });
            domainList.Add(new TestDomain { NAME = "dA" });
            domainList.Add(new TestDomain { NAME = "Ne" });
            domainList.Add(new TestDomain { NAME = null });



            var filter = new FilterDTO();
            filter.Name = "Ne";

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterContainsWithToLower()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "Da" });
            domainList.Add(new TestDomain { NAME = "Ne" });
            domainList.Add(new TestDomain { NAME = "dA" });
            domainList.Add(new TestDomain { NAME = "Ne" });


            var filter = new FilterDTO();
            filter.Name = "d";

            IQueryable<TestDomain> query = domainList.AsQueryable();
            FilterSettings setting = new FilterSettings { FilterName="Name", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Contains };

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, setting.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(4, rez.Count);
        }

        [TestMethod]
        public void TestFilterContainsWithToLowerWithNull()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "Da" });
            domainList.Add(new TestDomain { NAME = "Ne" });
            domainList.Add(new TestDomain { NAME = "dA" });
            domainList.Add(new TestDomain { NAME = null });


            var filter = new FilterDTO();
            filter.Name = "d";

            IQueryable<TestDomain> query = domainList.AsQueryable();
            FilterSettings setting = new FilterSettings { FilterName = "Name", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Contains };

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, setting.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(4, rez.Count);
        }

    }
}
