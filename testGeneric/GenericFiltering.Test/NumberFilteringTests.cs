using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.Greater));

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, null, customList);
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

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.Greater));

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, null, customList);
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

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.Less));

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, null, customList);
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

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.Less));

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, null, customList);
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

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.GreaterOrEqual));

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, null, customList);
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

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.GreaterOrEqual));

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, null, customList);
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

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.LessOrEqual));

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, null, customList);
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

            var customList = new List<KeyValuePair<string, PropertyComparison>>();
            customList.Add(new KeyValuePair<string, PropertyComparison>("Id", PropertyComparison.LessOrEqual));

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, null, customList);
            var rez = query.ToList();

            //assert
            Assert.IsTrue(rez.ElementAt(0).ID <= 1, "The actual result was not greater or equal than 1");
        }

    }
}
