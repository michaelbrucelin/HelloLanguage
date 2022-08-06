SELECT a.FirstName as firstName, a.LastName as lastName, b.City as city, b.State as state
FROM Person as a
LEFT JOIN Address as b on b.PersonId = a.PersonId
