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
    public class ExoticTypesTests
    {

        [TestMethod]
        public void TestFilterFloat()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { FLOAT_PROP = 1.1F });
            domainList.Add(new ExoticTestDomain { FLOAT_PROP = 2.2f });
            domainList.Add(new ExoticTestDomain { FLOAT_PROP = 3.3F });

            //filter
            filter.FloatProp = 1.1f;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterFloatNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { FLOAT_PROP_NULLABLE = 1.1F });
            domainList.Add(new ExoticTestDomain { FLOAT_PROP_NULLABLE = 2.2f });
            domainList.Add(new ExoticTestDomain { FLOAT_PROP_NULLABLE = 3.3F });

            //filter
            filter.FLOAT_PROP_NULLABLE = 1.1f;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }


        [TestMethod]
        public void TestFilterDouble()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { DOUBLE_PROP = 1.1 });
            domainList.Add(new ExoticTestDomain { DOUBLE_PROP = 2.2 });
            domainList.Add(new ExoticTestDomain { DOUBLE_PROP = 3.3 });

            //filter
            filter.DOUBLE_PROP = 1.1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterDoubleNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { DOUBLE_PROP_NULLABLE = 1.1 });
            domainList.Add(new ExoticTestDomain { DOUBLE_PROP_NULLABLE = 2.2 });
            domainList.Add(new ExoticTestDomain { DOUBLE_PROP_NULLABLE = 3.3 });

            //filter
            filter.DOUBLE_PROP_NULLABLE = 1.1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterShort()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { SHORT_PROP = 1 });
            domainList.Add(new ExoticTestDomain { SHORT_PROP = 2 });
            domainList.Add(new ExoticTestDomain { SHORT_PROP = 3 });

            //filter
            filter.SHORT_PROP = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterShortNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { SHORT_PROP_NULLABLE = 1 });
            domainList.Add(new ExoticTestDomain { SHORT_PROP_NULLABLE = 2 });
            domainList.Add(new ExoticTestDomain { SHORT_PROP_NULLABLE = 3 });

            //filter
            filter.SHORT_PROP_NULLABLE = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterLong()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { LONG_PROP = 1 });
            domainList.Add(new ExoticTestDomain { LONG_PROP = 2 });
            domainList.Add(new ExoticTestDomain { LONG_PROP = 3 });

            //filter
            filter.LONG_PROP = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterLongNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { LONG_PROP_NULLABLE = 1 });
            domainList.Add(new ExoticTestDomain { LONG_PROP_NULLABLE = 2 });
            domainList.Add(new ExoticTestDomain { LONG_PROP_NULLABLE = 3 });

            //filter
            filter.LONG_PROP_NULLABLE = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterByte()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { BYTE_PROP = 1 });
            domainList.Add(new ExoticTestDomain { BYTE_PROP = 2 });
            domainList.Add(new ExoticTestDomain { BYTE_PROP = 3 });

            //filter
            filter.BYTE_PROP = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterByteNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { BYTE_PROP_NULLABLE = 1 });
            domainList.Add(new ExoticTestDomain { BYTE_PROP_NULLABLE = 2 });
            domainList.Add(new ExoticTestDomain { BYTE_PROP_NULLABLE = 3 });

            //filter
            filter.BYTE_PROP_NULLABLE = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterSByte()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { SBYTE_PROP = 1 });
            domainList.Add(new ExoticTestDomain { SBYTE_PROP = 2 });
            domainList.Add(new ExoticTestDomain { SBYTE_PROP = 3 });

            //filter
            filter.SBYTE_PROP = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterSByteNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { SBYTE_PROP_NULLABLE = 1 });
            domainList.Add(new ExoticTestDomain { SBYTE_PROP_NULLABLE = 2 });
            domainList.Add(new ExoticTestDomain { SBYTE_PROP_NULLABLE = 3 });

            //filter
            filter.SBYTE_PROP_NULLABLE = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterUint()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { UINT_PROP = 1 });
            domainList.Add(new ExoticTestDomain { UINT_PROP = 2 });
            domainList.Add(new ExoticTestDomain { UINT_PROP = 3 });

            //filter
            filter.UINT_PROP = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterUintNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { UINT_PROP_NULLABLE = 1 });
            domainList.Add(new ExoticTestDomain { UINT_PROP_NULLABLE = 2 });
            domainList.Add(new ExoticTestDomain { UINT_PROP_NULLABLE = 3 });

            //filter
            filter.UINT_PROP_NULLABLE = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterUlong()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { ULONG_PROP = 1 });
            domainList.Add(new ExoticTestDomain { ULONG_PROP = 2 });
            domainList.Add(new ExoticTestDomain { ULONG_PROP = 3 });

            //filter
            filter.ULONG_PROP = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterUlongNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { ULONG_PROP_NULLABLE = 1 });
            domainList.Add(new ExoticTestDomain { ULONG_PROP_NULLABLE = 2 });
            domainList.Add(new ExoticTestDomain { ULONG_PROP_NULLABLE = 3 });

            //filter
            filter.ULONG_PROP_NULLABLE = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterUshort()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { USHORT_PROP = 1 });
            domainList.Add(new ExoticTestDomain { USHORT_PROP = 2 });
            domainList.Add(new ExoticTestDomain { USHORT_PROP = 3 });

            //filter
            filter.USHORT_PROP = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterUshortNullable()
        {
            //arange
            var domainList = new List<ExoticTestDomain>();
            var filter = new ExoticFilterDTO();
            IQueryable<ExoticTestDomain> query = domainList.AsQueryable();

            //data
            domainList.Add(new ExoticTestDomain { USHORT_PROP_NULLABLE = 1 });
            domainList.Add(new ExoticTestDomain { USHORT_PROP_NULLABLE = 2 });
            domainList.Add(new ExoticTestDomain { USHORT_PROP_NULLABLE = 3 });

            //filter
            filter.USHORT_PROP_NULLABLE = 1;


            //act
            query = FilterQuery.SetFilters<ExoticTestDomain, ExoticFilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

    }
}
