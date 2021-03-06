﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GenericFiltering.Test.Classes;
using QueryFiltering;
using QueryFiltering.Classes;

namespace GenericFiltering.Test
{
    [TestClass]
    public class NumberFilteringTests
    {

        [TestMethod]
        public void TestFilterEqualsSingleNumberEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1});
            domainList.Add(new TestDomain {ID = 2});
            domainList.Add(new TestDomain {ID = 3});
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterEqualsSingleNumberResultValidityEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.FirstOrDefault().ID);
        }


        [TestMethod]
        public void TestFilterGreaterMultipleResultEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Greater }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(4, rez.Count);
        }

        [TestMethod]
        public void TestFilterGreaterMultipleResultResultValidityEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Greater }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.IsTrue(rez.ElementAt(0).ID > 1, "The actual result was not greater than 1");
        }

        [TestMethod]
        public void TestFilterLessMultipleResultEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Less }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(0, rez.Count);
        }

        [TestMethod]
        public void TestFilterLessMultipleResultResultValidityEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 0 });
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Less }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.IsTrue(rez.ElementAt(0).ID < 1, "The actual result was not less than 1");
        }

        [TestMethod]
        public void TestFilterGreaterOrEqualMultipleResultEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.GreaterOrEqual }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(5, rez.Count);
        }

        [TestMethod]
        public void TestFilterGreaterOrEqualMultipleResultResultValidityEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.GreaterOrEqual }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.IsTrue(rez.ElementAt(0).ID >= 1, "The actual result was not greater or equal than 1");
        }

        [TestMethod]
        public void TestFilterLessOrEqualMultipleResultEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.LessOrEqual }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterLessOrEqualMultipleResultResultValidityEquals()
        {
            //arange
            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1 });
            domainList.Add(new TestDomain { ID = 2 });
            domainList.Add(new TestDomain { ID = 3 });
            domainList.Add(new TestDomain { ID = 4 });
            domainList.Add(new TestDomain { ID = 5 });

            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.LessOrEqual }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.IsTrue(rez.ElementAt(0).ID <= 1, "The actual result was not greater or equal than 1");
        }

        [TestMethod]
        public void TestFilterDecimal()
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
            filter.DecimalProp = 2;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(2, rez.Count);
        }

    }
}
