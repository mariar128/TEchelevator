/*
multi-line comment
single quotes in SQL for strings
*/



-- SELECT
-- Use a SELECT statement to return a literal string
SELECT 'Hello World';

-- Use a SELECT statement to add two numbers together (and label the result "sum")
SELECT 2 + 2 AS sum; -- we chose the name 'sum' for our label


-- SELECT ... FROM
-- Write queries to retrieve...

-- The state names from all the records (rows of data) in the state table
-- SELECT * FROM state; -- selects ALL the rows & columns from the state table
SELECT state_name FROM state;

-- The names and populations of all cities
-- SELECT * FROM CITY
SELECT city_name, population FROM city; -- seperate column names with commas to select multiple columns

-- All columns from the park table
SELECT * FROM park;


-- SELECT __ FROM __ WHERE
-- Write queries to retrieve...

-- The names of cities in California (CA)
-- SELECT * FROM city;
SELECT city_name FROM city WHERE state_abbreviation = 'CA';

-- The names and state abbreviations of cities NOT in California
SELECT city_name, state_abbreviation FROM city WHERE state_abbreviation != 'CA'; -- we can use != in Microsoft T-SQL <> is the same thing but in standard SQL

-- The names and areas of cities smaller than 25 square kilometers 
SELECT city_name,area FROM city WHERE area < 25;

-- The state names from all records in the state table that have no assigned census region
SELECT * FROM state;
SELECT state_name FROM state WHERE census_region IS NULL; -- note the NULL keyword, with IS instead of =. Things cant = null 
-- The names and census regions from all records in the state table that have an assigned census region
SELECT state_name, census_region FROM state WHERE census_region IS NOT NULL; -- note the NULL keyword, with IS NOT instead of !=


-- WHERE with AND/OR
-- Write queries to retrieve...

-- The names, areas, and populations of cities smaller than 25 sq. km. with more than 100,000 people
-- SELECT * FROM city;
SELECT city_name, area, population FROM city WHERE area < 25 AND population > 100000;
-- The names and census regions of all states (and territories and districts) not in the Midwest region (including those that don't have any census region)
 SELECT state_name,census_region FROM state WHERE census_region != 'Midwest' OR census_region IS NULL;

-- The names, areas, and populations of cities in California (CA) or Florida (FL)
SELECT city_name, area, population FROM city WHERE state_abbreviation = 'CA' OR state_abbreviation = 'FL';

-- The names, areas, and populations of cities in New England -- Connecticut (CT), Maine (ME), Massachusetts (MA), New Hampshire (NH), Rhode Island (RI) and Vermont (VT)
SELECT city_name, area, population FROM city WHERE state_abbreviation IN ('CT', 'ME', 'MA', 'RI', 'VT'); -- you can use these IN a collection so you dont have to write state abbrievation over and over again.



-- SELECT statements involving math
-- Write a query to retrieve the names and areas of all parks in square METERS
-- (the values in the database are stored in square kilometers)
-- Label the second column "area_in_square_meters"
-- how do i turn square km into square m? --> multiply by 1000000 (a million)
-- SELECT * FROM park;
SELECT park_name, (area * 1000000) AS area_in_square_meters FROM park;

-- All values vs. distinct values

-- Write a query to retrieve the names of all cities ...and notice repeats (like Springfield and Columbus)
SELECT city_name FROM city; 

-- Do it again, but without the repeats (note the difference in row count)
SELECT DISTINCT city_name FROM city; -- DISTINCT only returns the first matched values



-- LIKE
-- Write queries to retrieve...

-- The names of all cities that begin with the letter "A"
SELECT city_name FROM city WHERE city_name LIKE 'A%'; -- LIKE + a string to match, % is the wildcard/match all character

-- The names of all cities that end with "Falls"
SELECT city_name FROM city WHERE city_name LIKE '%Falls';

-- The names of all cities that contain a space
SELECT city_name FROM city WHERE city_name LIKE '% %';


-- BETWEEN
-- Write a query to retrieve the names and areas of parks of at least 100 sq. kilometers but no more than 200 sq. kilometers
SELECT * FROM park;
SELECT park_name, area FROM park WHERE area BETWEEN 100 AND 200; -- you can also use area >= 100 AND area <= 200;


-- DATES
-- Write a query to retrieve the names and dates established of parks established before 1900
SELECT park_name, date_established FROM park WHERE date_established < '1/1/1900'
