using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()] //signifies that this class contains automated tests
    public class LoopsAndArrayExercisesTests
    {
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquilavent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquilavent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object

        [TestMethod]
        public void MiddleWayTest()
        {
                        /*
            Given 2 int arrays, a and b, each length 3, return a new array length 2 containing their middle
            elements.
            middleWay([1, 2, 3], [4, 5, 6]) → [2, 5]
            middleWay([7, 7, 7], [3, 8, 0]) → [7, 8]
            middleWay([5, 2, 9], [1, 4, 5]) → [2, 4]
            */

            //Arrange - set up what we need for the test
            LoopsAndArrayExercises loopsAndArrayExercises = new LoopsAndArrayExercises();

            int[] firstInput = { 1, 2, 3 };
            int[] secondInput = { 4, 5, 6 };

            //Act - run the code that we are testing to get the result
            int[] actualResult = loopsAndArrayExercises.MiddleWay(firstInput, secondInput);

            //Assert - make sure that our expectations and reality line up 
            int[] expectedResult = { 2, 5 };
            CollectionAssert.AreEqual(expectedResult, actualResult);

            //Let's do one more in this TestMethod... 

            //Arrange
            //I'm gonna keep using the LoopsAndArrayExercises object from earlier

            int[] thirdInput = { 7, 7, 7 };
            int[] fourthInput = { 3, 8, 0 };

            //Act
            int[] secondActualResult = loopsAndArrayExercises.MiddleWay(thirdInput, fourthInput);

            //Assert
            int[] secondExpectedResult = { 7, 8 };
            CollectionAssert.AreEqual(secondExpectedResult, secondActualResult); //this passes
            //CollectionAssert.AreNotEqual(secondExpectedResult, secondActualResult); //this fails

            CollectionAssert.AllItemsAreNotNull(secondActualResult); //test if the result is not null (pass)

        }

    }
}