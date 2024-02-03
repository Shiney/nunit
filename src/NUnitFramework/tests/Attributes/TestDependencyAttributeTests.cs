// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Execution;
using NUnit.TestData;
using NUnit.Framework.Tests.TestUtilities;

namespace NUnit.Framework.Tests.Attributes
{
    [TestFixture]
    public class TestDependencyAttributeTests
    {
        [Test]
        public void CheckOrderIsCorrect()
        {
            var work = (CompositeWorkItem)TestBuilder.CreateWorkItem(typeof(TestCaseDependencyAttributeFixture));

            // This triggers sorting
            TestBuilder.ExecuteWorkItem(work);

            Assert.That(work.Children, Has.Count.EqualTo(3));
            Assert.Multiple(() =>
            {
                foreach (var child in work.Children)
                {
                    child.Result.AssertPassed();
                }
            });
        }

    }
}
