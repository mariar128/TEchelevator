﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()

        [TestMethod]
        public void MakeAbbaTest()
        {

            //Arrange
            StringExercises stringExercises = new StringExercises();
            //Act
            string result = stringExercises.MakeAbba("Hi", "Bye");
            //Assert
            Assert.AreEqual("HiByeByeHi", result);

            //Arrange - already made an object

            //Act
            string resultTwo = stringExercises.MakeAbba("What", "Up");

            //Assert
            Assert.AreEqual("UpWhatWhatUp", resultTwo, "Please try again"); // this fails, but also gives a message in the test explorer
        }
        [TestMethod]

    }
}