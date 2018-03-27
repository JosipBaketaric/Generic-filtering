using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using QueryFiltering;
using GenericFiltering.Test.Classes;
using QueryFiltering.Classes;

namespace GenericFiltering.Test
{
    [TestClass]
    public class DateFilteringTests
    {

        [TestMethod]
        public void TestFilterDateResultOneCount()
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
        [TestMethod]
        public void TestFilterDateResultTwoCount()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { DATUM_TEST = dateNow });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });


            var filter = new FilterDTO();
            filter.DatumTest = dateNow.AddDays(1);

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(2, rez.Count);
        }

        [TestMethod]
        public void TestFilterDateResultGreaterCount()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { DATUM_TEST = dateNow });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });


            var filter = new FilterDTO();
            filter.DatumTest = dateNow;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "DatumTest", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Greater }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(4, rez.Count);
        }

        [TestMethod]
        public void TestFilterDateResultLessCount()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { DATUM_TEST = dateNow });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });


            var filter = new FilterDTO();
            filter.DatumTest = dateNow.AddDays(2);

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "DatumTest", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Less }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterDateResultGreaterOrEqualCount()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { DATUM_TEST = dateNow });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });


            var filter = new FilterDTO();
            filter.DatumTest = dateNow;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "DatumTest", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.GreaterOrEqual }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(5, rez.Count);
        }

        [TestMethod]
        public void TestFilterDateResultLessOrEqualCount()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { DATUM_TEST = dateNow });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(1) });
            domainList.Add(new TestDomain { DATUM_TEST = dateNow.AddDays(2) });


            var filter = new FilterDTO();
            filter.DatumTest = dateNow;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "DatumTest", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.LessOrEqual }
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }
    }
}
