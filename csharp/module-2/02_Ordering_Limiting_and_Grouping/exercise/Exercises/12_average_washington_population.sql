-- 12. The average population of all cities in Washington (WA). Name the column 'average_washington_population'.
-- Expected answer is around 202,000
-- (1 row)
SELECT avg(population) AS average_washington_population FROM city WHERE state_abbreviation IN ('WA');
