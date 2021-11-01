using NUnit.Framework;
using System;
using TRIALTEST.Attributes;
using TRIALTEST.Helpers;

namespace TRIALTEST.Tests
{
    /*
     * a)	Create a separate DLL in which we can perform unit testing based on what we have learned during the semester. (2 points)
        b)	Create a class for the AttributeHelper class that tests the operation of the 
                GetPropertyDisplayName() method in three ways:
            a.	Create a test for a property that has the DisplayName attribute placed on it. (1.5 points)
            b.	Create a test for a property that does not have the DisplayName attribute placed on it. (1.5 points)
            c.	Create a test for a property that does not exist.
                    Treat any exceptions that may arise in a way that we learned during the semester (1.5 points)

     * */
    [TestFixture]
    public class AttributeHelperTests
    {
        
        [TestCase("Test1", "Teszt név")]
        [TestCase("Test2", "Test2")]
        public void GetDisplayNameSuccessfullyTest(string propName, string expectedName)
        {
            // Arrange

            // Act
            var dispName = AttributeHelper.GetPropertyDisplayName<TestClass>(propName);
            // Assert
            Assert.That(dispName, Is.EqualTo(expectedName));
        }

        [Test]
        public void GetDisplayNameOnNull()
        {
            // Arrange

            // Act - Assert
            var exception = Assert.Throws(typeof(ArgumentNullException), () => AttributeHelper.GetPropertyDisplayName<TestClass>(null));
        }
    }

    class TestClass //b
    {
        [DisplayName("Teszt név")]
        public int Test1 { get; set; }

        public string Test2 { get; set; }
    }
}
