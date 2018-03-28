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
    public class TextFilteringTests
    {

        [TestMethod]
        public void TestFilterTextResultCount()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da"});
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "NE" });


            var filter = new FilterDTO();
            filter.Name = "da";

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterTextResultValidity()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "NE" });


            var filter = new FilterDTO();
            filter.Name = "da";

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual("da", rez.ElementAt(0).NAME);
        }

        [TestMethod]
        public void TestFilterTextContains()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "d" });
            domainList.Add(new TestDomain { NAME = "n" });


            var filter = new FilterDTO();
            filter.Name = "d";

            FilterSettings settings = new FilterSettings();
            settings.FilterName = "Name";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Contains;
            settings.ToLower = false;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterTextEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "d" });
            domainList.Add(new TestDomain { NAME = "n" });


            var filter = new FilterDTO();
            filter.Name = "d";

            FilterSettings settings = new FilterSettings();
            settings.FilterName = "Name";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Equals;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),"Parameter filter is null")]
        public void TestNoFilter()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "d" });
            domainList.Add(new TestDomain { NAME = "n" });

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, null);
            var rez = query.ToList();

        }

        [TestMethod]
        public void TestFilterNullTextEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "d" });
            domainList.Add(new TestDomain { NAME = "n" });


            var filter = new FilterDTO();

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(domainList.Count, rez.Count);
        }

        [TestMethod]
        public void TestTextFilterEmptyTextEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "da" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "ne" });
            domainList.Add(new TestDomain { NAME = "DA" });
            domainList.Add(new TestDomain { NAME = "NE" });
            domainList.Add(new TestDomain { NAME = "d" });
            domainList.Add(new TestDomain { NAME = "n" });


            var filter = new FilterDTO();
            filter.Name = "";

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(8, rez.Count);
        }

        [TestMethod]
        public void TestFilterChar()
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
            filter.CharProp = 'a';

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }
    }
}
