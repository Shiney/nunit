﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.TestData;
using NUnit.TestData.TestCaseSourceAttributeFixture;
using NUnit.TestUtilities;

namespace NUnit.Framework.Tests.Attributes
{
    [TestFixture]
    class TestOrderAttributeTests
    {
        [Test]
        public void CheckOrderIsCorrect()
        {
            var testFixt = TestBuilder.MakeFixture(typeof (TestCaseOrderAttributeFixture));
            testFixt.Sort();// need to manually call this method to mimic real world conditions
            Assert.AreEqual(testFixt.Tests.Count, 5);
            Assert.AreEqual(testFixt.Tests[0].Name, "A_NoOrderTestLowLetter");
            Assert.AreEqual(testFixt.Tests[1].Name, "D_NoOrderTest");
            Assert.AreEqual(testFixt.Tests[2].Name, "Y_FirstTest");
            Assert.AreEqual(testFixt.Tests[3].Name, "Y_SecondTest");
            Assert.AreEqual(testFixt.Tests[4].Name, "Z_ThirdTestWithSameOrderAsSecond");
            
        }
    }
}
