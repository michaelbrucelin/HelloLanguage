SELECT a.name as Employee
FROM Employee as a
INNER JOIN Employee as b on b.id = a.managerId
WHERE a.salary > b.salary
