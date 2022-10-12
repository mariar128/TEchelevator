-- ORDERING RESULTS

-- Populations of all states from largest to smallest.
--SELECT * FROM state;
SELECT population, state_abbreviation FROM state ORDER BY population DESC; -- ORDER BY population value, sort in DESCending order
-- States sorted alphabetically (A-Z) within their census region. The census regions are sorted in reverse alphabetical (Z-A) order.
SELECT state_name, census_region FROM state ORDER BY census_region DESC, state_name;

-- The biggest park by area
--SELECT * FROM park;
SELECT TOP 1 area FROM park ORDER BY area DESC; 
SELECT * FROM park ORDER BY area DESC;
-- LIMITING RESULTS

-- The 10 largest cities by population
SELECT TOP 10 * FROM city ORDER BY population DESC;

-- The 20 oldest parks from oldest to youngest in years, sorted alphabetically by name.
SELECT TOP 20 park_name, (YEAR(GETDATE()) - YEAR(date_established)) AS age_in_years FROM park ORDER BY age_in_years DESC, park_name;



-- CONCATENATING OUTPUTS

-- All city names and their state abbreviation.
SELECT (city_name + ', ' + state_abbreviation) AS city_state_abbreviation FROM city;

-- All park names and area
SELECT ('Name: ' + park_name + ',Area '+ CAST(area as VARCHAR)) AS park_and_area FROM park;

-- The census region and state name of all states in the West & Midwest sorted in ascending order.
-- SELECT * FROM state
SELECT (census_region + ':' + state_name) AS census_region_state_name FROM state WHERE census_region IN ('West', 'Midwest') ORDER BY census_region_state_name;

-- AGGREGATE FUNCTIONS

-- Average population across all the states. Note the use of alias/label, common with aggregated values.
SELECT AVG(population) AS average_state_population FROM state;

-- Total population in the West and South census regions
SELECT SUM(population) AS west_and_south_population FROM state WHERE census_region IN ('West', 'South');

-- The number of cities with populations greater than 1 million
SELECT COUNT(*) AS big_cities_count FROM city WHERE population > 1000000;

-- The number of state nicknames.
SELECT COUNT(state_nickname) FROM state; -- null values are not counted
SELECT COUNT(*) FROM state WHERE state_nickname IS NULL; -- discount double-check on those null values for state nickname
-- The area of the smallest and largest parks.
SELECT MIN(area) AS smallest_park, MAX(area) AS largest_park FROM park;


-- GROUP BY

-- Count the number of cities in each state, ordered from most cities to least.
SELECT COUNT(city_name) AS city_count, state_abbreviation FROM city GROUP BY state_abbreviation ORDER BY city_count DESC;

-- Determine the average park area depending upon whether parks allow camping or not.
SELECT AVG(area) AS avg_park_area, has_camping FROM park GROUP BY has_camping 

-- Sum of the population of cities in each state ordered by state abbreviation.
SELECT SUM(population) AS cities_population, state_abbreviation FROM city GROUP BY state_abbreviation ORDER BY state_abbreviation;

-- The smallest city population in each state ordered by city population.
SELECT state_abbreviation, MIN(population) AS smallest_city_pop FROM state GROUP BY state_abbreviation ORDER BY smallest_city_pop;
/*
ORDER OF SQL OPERATIONS (different than the ordr we write clauses in) 
FROM: where is our data coming from? -> city table
WHERE: out of all the data in our city table... narrow it down to rows where the state_abbreviation is not null
GROUP BY: take the state abbreviation and organize the data based on the value of state_abbreviation .. and ..
SELECT: take the aggregate value (the smallest city) and the state abbreviation and put them into the result set
ORDER BY: the value of the smallest city population (ascending) 
-- Miscelleneous

-- While you can use TOP to limit the number of results returned by a query,
-- it's recommended to use OFFSET and FETCH if you want to get
-- "pages" of results.
-- For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)
*/


-- SUBQUERIES (optional)

-- Include state name rather than the state abbreviation while counting the number of cities in each state,
SELECT COUNT(city_name) AS number_of_cities,
(
SELECT state_name FROM state WHERE state_table.state_abbreviation = city_table.state_abbreviation
)
FROM city AS city_table
GROUP BY state_abbreviation 
ORDER BY number_of_cities DESC;
-- Include the names of the smallest and largest parks


-- List the capital cities for the states in the Northeast census region.
