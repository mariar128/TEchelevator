/*
1. **sumDouble** Given two int values, return their sum. Unless the two values are the 
    same, then return double their sum.

	
		sumDouble(1, 2) → 3
		sumDouble(3, 2) → 5
		sumDouble(2, 2) → 8
*/
		function sumDouble(x, y) {
			if(x === y) 
			{
				return (x + y) * 2;
			}
			return x + y;
        }


/*







2. **hasTeen** We'll say that a number is "teen" if it is in the range 13..19 inclusive. 
    Given 3 int values, return true if 1 or more of them are teen.

		hasTeen(13, 20, 10) → true
		hasTeen(20, 19, 10) → true
		hasTeen(20, 10, 13) → true
*/

// hasTeen 
// between 13-19 
// 3 parameters 
// return true
function hasTeen(x, y, z) {
	if(x >= 13 && x <= 19)
	{
		return true;
	}
	if(y >= 13 && y <= 19)
	{
		return true;
	}
	if(z >= 13 && z <= 19)
	{
		return true;
	}
	return false;
}



/* 
3. **lastDigit** Given two non-negative int values, return true if they have the same 
    last digit, such as with 27 and 57.

		lastDigit(7, 17) → true
		lastDigit(6, 17) → false
		lastDigit(3, 113) → true
*/
// lastDigit
// two parameters
// return true if they have the same last digit. compare last digits
function lastDigit(x, y) {
if(x % 10 === y % 10)
{
	return true;
}
return false; 
}




/*
4. **seeColor** Given a string, if the string begins with "red" or "blue" return that color 
    string, otherwise return the empty string.

		seeColor("redxx") → "red"
		seeColor("xxred") → ""
        seeColor("blueTimes") → "blue"

		seeColor
		
		return color string
*/
	function seeColor(color) {
 	let red = 'red';
 	let blue = 'blue';
 
	 if(color.substr(0, 3) === red)
	 {
		 return red;
	 }
	 if(color.substr(0, 4) === blue)
	 {
		 return blue;
	 }
	 return '';
	}


















/*
5. **oddOnly** Write a function that given an array of integer of any length, removes
    the even numbers, and returns a new array of just the the odd numbers.

		oddOnly([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]) → [1, 3, 5, 7, 9, 11];
		oddOnly([2, 4, 8, 32, 256]); → []
*/
// parameter is an array
// take out the even numbers (keep odd #'s)
// moves odd numbers into a new array
function oddOnly(array) {
	let newArray = [];
	for(let i = 0; i < array.length; i++)
	{
		if(array[i] % 2 !== 0)
		{
			newArray.push(array[i]);
		}	
	}
	return newArray;
}




/*
6. **frontAgain** Given a string, return true if the first 2 chars in the string also appear 
    at the end of the string, such as with "edited".

		frontAgain("edited") → true
		frontAgain("edit") → false
		frontAgain("ed") → true
*/

// string parameter
// substring for the first 2 chars
// another substring for the last 2 chars
// length - 2
function frontAgain(string) {
	let firstString = string.substr(0, 2);
	let lastString = string.substr(string.length - 2, 2);
	if(firstString === lastString)
	{
		return true;
	}
	return false;
}







/*
7. **cigarParty** When squirrels get together for a party, they like to have cigars. 
A squirrel party is successful when the number of cigars is between 40 and 60, inclusive. 
Unless it is the weekend, in which case there is no upper bound on the number of cigars. 
Write a squirrel party function that return true if the party with the given values is successful, 
or false otherwise.

		cigarParty(30, false) → false
		cigarParty(50, false) → true
		cigarParty(70, true) → true
*/

// successful when cigars is between 40-60

// 2 parameters, a number of cigars and a bool (is it the weekend or not)
// first figure out if its the weekend, then the cigar range
function cigarParty(x, isWeekend) {
	if(isWeekend)
	{
		if(x >= 40)
		{
		return true;
		}
	}
	if(!isWeekend)
	{
		if(x >= 40 && x <= 60)
		{
		return true;
		}
	}
	return false;
}




/*
8. **fizzBuzz** Given a number, return a value according to the following rules:
If the number is multiple of 3, return "Fizz."
If the number is a multiple of 5, return "Buzz." 
If the number is a multiple of both 3 and 5, return "FizzBuzz."
In all other cases return the original number. 

	fizzBuzz(3) → "Fizz"
	fizzBuzz(1) → 1
	fizzBuzz(10) → "Buzz"
	fizzBuzz(15) → "FizzBuzz"
	fizzBuzz(8) → 8
*/

// one parameter
function fizzBuzz(x) {

	if(x % 3 == 0 && x % 5 == 0)
	{
		return 'FizzBuzz';
	}
	else if(x % 5 == 0)
	{
	return 'Buzz';
	}
	else if(x % 3 == 0)
	{
		return 'Fizz';
	}
	else 
	{
		return x;
	}
}


/*
9. **filterEvens** Write a function that filters an array to only include even numbers.

	filterEvens([]) → []
	filterEvens([1, 3, 5]) → []
	filterEvens([2, 4, 6]) → [2, 4, 6]
	filterEvens([100, 8, 21, 24, 62, 9, 7]) → [100, 8, 24, 62]
*/
function filterEvens(myArray) {

let evensArray = [];
	for(let i = 0; i < myArray.length; i++)
	{
		if(myArray[i] % 2 == 0)
		{
			evensArray.push(myArray[i])
		}
	}
	return evensArray;
}



/*
10. **filterBigNumbers** Write a function that filters numbers greater than or equal to 100.

	filterBigNumbers([7, 10, 121, 100, 24, 162, 200]) → [121, 100, 162, 200]
	filterBigNumbers([3, 2, 7, 1, -100, -120]) → []
	filterBigNumbers([]) → []
*/

function filterBigNumbers(x) {
let bigNumbers = [];
for(let i = 0; i < x.length; i++)
{
	if(x[i] >= 100)
	{
		bigNumbers.push(x[i])
	}
}
return bigNumbers;



}


/*
11. **filterMultiplesOfX** Write a function to filter numbers that are a multiple of a 
parameter, `x` passed in.

	filterMultiplesOfX([3, 5, 1, 9, 18, 21, 42, 67], 3) → [3, 9, 18, 21, 42]
	filterMultiplesOfX([3, 5, 10, 20, 18, 21, 42, 67], 5) → [5, 10, 20]
*/
function filterMultiplesOfX(x, y) {
let newArray = [];
for(let i = 0; i < x.length; i++)
{
	if(x[i] % y === 0)
	{
		newArray.push(x[i])
	}

}
return newArray;




}


/*
12. **createObject** Write a function that creates an object with a property called 
firstName, lastName, and age. Populate the properties with your values.

	createObject() →

	{
		firstName,
		lastName,
		age
	}
*/
function createObject()

	{
		const person = {
		firstName: "Maria",
		lastName: "Rivera",
		age: 22
		}
		return person;
	}