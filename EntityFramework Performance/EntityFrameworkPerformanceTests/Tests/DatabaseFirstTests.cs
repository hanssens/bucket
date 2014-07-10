using EntityFrameworkPerformanceTests.DatabaseFirst.DataModel;
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
    public class DatabaseFirstTests : BaseEntityFrameworkTests
    {
        [Test]
        public void DatabaseFirst_Constructor_Test()
        {
            // arrange
            var stopwatch = Stopwatch.StartNew();

            // act
            var target = new DatabaseFirstDataContext();
            
            // assert
            StopAndPrint(stopwatch);
        }

        [Test]
        public void DatabaseFirst_IDisposable_Constructor_Test()
        {
            var stopwatch = Stopwatch.StartNew();
            using (var target = new DatabaseFirstDataContext())
            {
                // do nothing
            }

            StopAndPrint(stopwatch);
        }
        
        [Test]
        public void DatabaseFirst_FetchSingleRecord()
        {
            // arrange
            var customerId = 1;
            var stopwatch = Stopwatch.StartNew();

            // act
            var context = new DatabaseFirstDataContext();
            var target = context.Customers.SingleOrDefault(c => c.CustomerID == customerId);
            
            // assert
            target.Should().NotBeNull();
            target.CustomerID.Should().Be(customerId);

            StopAndPrint(stopwatch);
        }

        [Test]
        public void DatabaseFirst_FetchFirstRecord()
        {
            // arrange
            var stopwatch = Stopwatch.StartNew();

            // act
            var context = new DatabaseFirstDataContext();
            var target = context.Customers.FirstOrDefault();

            // assert
            target.Should().NotBeNull();
            target.CustomerID.Should().BeGreaterOrEqualTo(1);

            StopAndPrint(stopwatch);
        }

    }
}
