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
    public class ExpressionCombinationTypeTest
    {




        [TestMethod]
        public void TestCombinationAndOneProperty()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne",});


            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", ExpressionCombination = QueryFiltering.Enums.ExpressionCombinationTypeEnum.And }
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestCombinationAndTwoProperties()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });


            var filter = new FilterDTO();
            filter.Id = 1;
            filter.Name = "ne";

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", ExpressionCombination = QueryFiltering.Enums.ExpressionCombinationTypeEnum.And },
                new FilterSettings { FilterName= "Name", ExpressionCombination = QueryFiltering.Enums.ExpressionCombinationTypeEnum.And }
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(1, rez.Count);
        }


        [TestMethod]
        public void TestCombinationOrOneProperty()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });


            var filter = new FilterDTO();
            filter.Id = 1;

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", ExpressionCombination = QueryFiltering.Enums.ExpressionCombinationTypeEnum.Or },
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(3, rez.Count);
        }

        [TestMethod]
        public void TestCombinationOrTwoProperty()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });


            var filter = new FilterDTO();
            filter.Id = 1;
            filter.Name = "ne";

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Id", ExpressionCombination = QueryFiltering.Enums.ExpressionCombinationTypeEnum.Or },
            };


            IQueryable<TestDomain> query = domainList.AsQueryable();

            //act
            query = FilterQuery.SetFilters<TestDomain, FilterDTO>(query, filter, settingsList);
            var rez = query.ToList();

            //assert
            Assert.AreEqual(5, rez.Count);
        }

        [TestMethod]
        public void TestCombinationOrTwoPropertySecondTest()
        {
            //arange
            var dateNow = DateTime.Now;

            var domainList = new List<TestDomain>();
            domainList.Add(new TestDomain { ID = 2, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "da", });
            domainList.Add(new TestDomain { ID = 1, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });
            domainList.Add(new TestDomain { ID = 2, NAME = "ne", });


            var filter = new FilterDTO();
            filter.Id = 4;
            filter.Name = "ne";

            List<FilterSettings> settingsList = new List<FilterSettings> {
                new FilterSettings { FilterName= "Name", ExpressionCombination = QueryFiltering.Enums.ExpressionCombinationTypeEnum.Or },
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
