// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Execution;

namespace NUnit.TestData
{
    /// <summary>
    /// To avoid changing the public API for now we aren't going to add a new attribute yet
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MyDependsOnAttribute : NUnitAttribute, IApplyToTest
    {
        public MyDependsOnAttribute(params string[] testNames)
        {
            TestNames = testNames;
        }

        public string[] TestNames { get; set; }

        public void ApplyToTest(Test test)
        {
            DependenciesInfo info;
            if (!test.Properties.ContainsKey(PropertyNames.DependencyInfo))
            {
                info = new DependenciesInfo();
                test.Properties.Set(PropertyNames.DependencyInfo, info);
            }
            else
            {
                info = (DependenciesInfo)test.Properties.Get(PropertyNames.DependencyInfo);
            }
            foreach (var testName in TestNames)
            {
                info.AddDependency(testName);
            }
        }
    }

    [TestFixture]
    public class TestCaseDependencyAttributeFixture
    {
        [Order(2)]
        [Test]
        [MyDependsOn(nameof(FirstTest))]
        public void SecondTest()
        {
            _hasRunSecondTest = true;
            Assert.That(_hasRunFirstTest, Is.True);
        }

        private bool _hasRunFirstTest = false;
        [Test]
        [Order(3)]
        public void FirstTest()
        {
            _hasRunFirstTest = true;
        }

        private bool _hasRunSecondTest = false;
        [Test]
        [Order(1)]
        [MyDependsOn(nameof(SecondTest))]
        public void ThirdTest()
        {
            Assert.That(_hasRunSecondTest, Is.True);
        }
    }

}
