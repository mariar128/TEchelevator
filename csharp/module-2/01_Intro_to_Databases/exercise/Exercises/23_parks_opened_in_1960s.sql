-- 23. The name and date established of parks opened in the 1960s (6 rows)
SELECT park_name, date_established FROM park WHERE date_established IN ('1968-10-02', '1961-07-01', '1962-12-09', '1966-10-15','1964-09-12');