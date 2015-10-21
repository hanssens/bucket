using EntityFrameworkPerformanceTests.PlainOldSql.DataModel;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPerformanceTests.Tests
{
    [TestFixture]
    public class PlainOldSqlTests : BaseEntityFrameworkTests
    {
        [Test]
        public void PlainOldSql_Constructor_Test()
        {
            // arrange
            var stopwatch = Stopwatch.StartNew();

            // act
            var target = new PlainOldSqlDataContext();
            
            // assert
            StopAndPrint(stopwatch);
        }

        [Test]
        public void PlainOldSql_IDisposable_Constructor_Test()
        {
            var stopwatch = Stopwatch.StartNew();
            using (var target = new PlainOldSqlDataContext())
            {
                // do nothing
            }

            StopAndPrint(stopwatch);
        }
        
        [Test]
        public void PlainOldSql_FetchSingleRecord()
        {
            // arrange
            var customerId = 1;
            var stopwatch = Stopwatch.StartNew();

            // act
            var context = new PlainOldSqlDataContext();
            //var target = context.Customers.SingleOrDefault(c => c.CustomerID == customerId);
            var target = context.Query("select * from Sales.Customer as c where c.CustomerId = " + customerId);

            // assert
            target.Should().NotBeNull();
            //target.CustomerID.Should().Be(customerId);

            StopAndPrint(stopwatch);
        }

        [Test]
        public void PlainOldSql_FetchFirstRecord()
        {
            // arrange
            var stopwatch = Stopwatch.StartNew();

            // act
            var context = new PlainOldSqlDataContext();
            //var target = context.Customers.FirstOrDefault();
            var target = context.Query("select top 1 * from Sales.Customer;");

            // assert
            target.Should().NotBeNull();
            //target.CustomerID.Should().BeGreaterOrEqualTo(1);

            StopAndPrint(stopwatch);
        }


    }
}
