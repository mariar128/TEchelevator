-- 6. The genres of "The Wizard of Oz" sorted in alphabetical order (A-Z).
-- (3 rows)
SELECT genre_name
FROM genre
JOIN movie_genre ON movie_genre.genre_id = genre.genre_id
JOIN movie ON movie.movie_id = movie_genre.movie_id
WHERE title = 'The Wizard of Oz'
ORDER BY genre_name
