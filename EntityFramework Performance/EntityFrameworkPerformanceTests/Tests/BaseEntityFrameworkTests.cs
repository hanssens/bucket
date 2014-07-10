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
    public abstract class BaseEntityFrameworkTests
    {
        protected void StopAndPrint(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            var message = String.Format("Method took {0}ms to complete", stopwatch.ElapsedMilliseconds);
            Console.WriteLine(message);
            Debug.WriteLine(message);
        }
    }
}
