using Equity.Positions.Web.API.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Test.API.Utility
{
    public class DisplayHelperTest
    {
        [Test]
        public void FormatQuantity_PositiveValue()
        {
            //Arrange
            int quantity = 10;

            //Act
            string displayValue = DisplayHelper.FormatQuantity(quantity);

            //Assert
            Assert.AreEqual("+10", displayValue);
        }

        [Test]
        public void FormatQuantity_NegativeValue()
        {
            //Arrange
            int quantity = -15;

            //Act
            string displayValue = DisplayHelper.FormatQuantity(quantity);

            //Assert
            Assert.AreEqual("-15", displayValue);
        }

        [Test]
        public void FormatQuantity_ZeroValue()
        {
            //Arrange
            int quantity = 0;

            //Act
            string displayValue = DisplayHelper.FormatQuantity(quantity);

            //Assert
            Assert.AreEqual("0", displayValue);
        }
    }
}
