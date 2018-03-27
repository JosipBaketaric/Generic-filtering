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
    public class CombinedFiltering
    {

        [TestMethod]
        public void TestFilterStringNumber()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Name = "da";
            filter.Id = 2;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterStringBool()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Name = "da";
            filter.BoolProp = false;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterStringDecimal()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Name = "da";
            filter.DecimalProp = 3;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterNumberNumber()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Id = 1;
            filter.DecimalProp = 3;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterNumberBool()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Id = 2;
            filter.BoolProp = true;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterNumberChar()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Id = 1;
            filter.CharProp = 'b';

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(2, rez.Count);
        }

        [TestMethod]
        public void TestFilterNumberCharDate()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Id = 1;
            filter.CharProp = 'b';
            filter.DatumTest = dateNow;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterNumberCharDateBoolDecimalString()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Id = 1;
            filter.CharProp = 'b';
            filter.DatumTest = dateNow;
            filter.BoolProp = false;
            filter.DecimalProp = 1;
            filter.Name = "da";

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterNumberCharDateBoolDecimalStringGreaterThan()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });




            var filter = new FilterDTO();
            filter.Id = 1;
            filter.CharProp = 'b';
            filter.DatumTest = dateNow;
            filter.BoolProp = false;
            filter.DecimalProp = 1;
            filter.Name = "da";
            filter.IntProp = 2;

            FilterSettings settings = new FilterSettings();
            settings.FilterName = "IntProp";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Greater;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterNumberCharDateBoolDecimalStringGreaterOrEqualThan()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });




            var filter = new FilterDTO();
            filter.Id = 1;
            filter.CharProp = 'b';
            filter.DatumTest = dateNow;
            filter.BoolProp = false;
            filter.DecimalProp = 1;
            filter.Name = "da";
            filter.IntProp = 2;

            FilterSettings settings = new FilterSettings();
            settings.FilterName = "IntProp";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.GreaterOrEqual;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(2, rez.Count);
        }


        [TestMethod]
        public void TestFilterNumberCharDateBoolDecimalStringContainsWithNumber()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Id = 1;
            filter.CharProp = 'b';
            filter.DatumTest = dateNow;
            filter.BoolProp = false;
            filter.DecimalProp = 1;
            filter.Name = "123";
            filter.IntProp = 2;

            FilterSettings settings = new FilterSettings();
            settings.FilterName = "Name";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Contains;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterNumberCharDateBoolDecimalStringContains()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Id = 1;
            filter.CharProp = 'b';
            filter.DatumTest = dateNow;
            filter.BoolProp = false;
            filter.DecimalProp = 1;
            //filter.Name = "123";
            filter.IntProp = 2;

            FilterSettings settings = new FilterSettings();
            settings.FilterName = "IntProp";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Contains;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterWithMultipleNullValues()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });




            var filter = new FilterDTO();
            filter.Id = null;
            filter.CharProp = 'b';
            filter.DatumTest = null;
            filter.BoolProp = false;
            filter.DecimalProp = null;
            filter.Name = "123";
            filter.IntProp = null;

            FilterSettings settings = new FilterSettings();
            settings.FilterName = "Name";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Contains;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterWithDoubleNumbers()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });




            var filter = new FilterDTO();
            filter.DoubleProp = 3.14;

            FilterSettings settings = new FilterSettings();
            settings.FilterName = "DoubleProp";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Greater;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterWithDoubleNumbersGreater()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });




            var filter = new FilterDTO();
            filter.DoubleProp = 3.14;


            FilterSettings settings = new FilterSettings();
            settings.FilterName = "DoubleProp";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Greater;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(2, rez.Count);
        }

        [TestMethod]
        public void TestFilterWithDoubleNumbersGreaterOrEqual()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });




            var filter = new FilterDTO();
            filter.DoubleProp = 3.14;


            FilterSettings settings = new FilterSettings();
            settings.FilterName = "DoubleProp";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.GreaterOrEqual;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterWithDoubleNumbersLess()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });




            var filter = new FilterDTO();
            filter.DoubleProp = 3.14;


            FilterSettings settings = new FilterSettings();
            settings.FilterName = "DoubleProp";
            settings.PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Less;

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settings.ToList());
            var rez = query.ToList();

            //assert
            Assert.AreEqual(10, rez.Count);
        }

        [TestMethod]
        public void TestFilterWithDoubleNumbersLessAndGreater()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });




            var filter = new FilterDTO();
            filter.DoubleProp = 3.14;
            filter.Id = 1;


            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "DoubleProp", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Less },
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.Greater },
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }

        [TestMethod]
        public void TestFilterNotEqualInt()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });




            var filter = new FilterDTO();
            filter.Id = 1;


            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.NotEqual }
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }


        [TestMethod]
        public void TestFilterNotEqualDate()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });

            var filter = new FilterDTO();
            filter.DatumTest = dateNow;


            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "DatumTest", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.NotEqual }
            };

            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(2, rez.Count);
        }

        [TestMethod]
        public void TestFilterNotEqualChar()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });




            var filter = new FilterDTO();
            filter.CharProp = 'b';

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "CharProp", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.NotEqual }
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestFilterNotEqualBool()
        {
            //arange
            var domainList = new List<TestDomain>();
            var dateNow = DateTime.Now;

            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'a', DECIMAL_PROP = 3, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 2, NAME = "da", DATUM_TEST = dateNow.AddDays(2), BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", DATUM_TEST = dateNow, BOOL_PROP = true, CHAR_PROP = 'a', DECIMAL_PROP = 1, INT_PROP = 1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow.AddDays(1), BOOL_PROP = true, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 2, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 3 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 1.1 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.14 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.15 });
            domainList.Add(new TestDomain { ID = 1, NAME = "da123", DATUM_TEST = dateNow, BOOL_PROP = false, CHAR_PROP = 'b', DECIMAL_PROP = 1, INT_PROP = 2, DOUBLE_PROP = 3.79 });




            var filter = new FilterDTO();
            filter.BoolProp = false;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "BoolProp", PropertyComparison = QueryFiltering.Enums.PropertyComparisonTypeEnum.NotEqual }
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

    }
}
