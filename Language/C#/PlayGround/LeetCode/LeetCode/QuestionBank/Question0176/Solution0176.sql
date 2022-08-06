;WITH cte AS(
    SELECT salary, DENSE_RANK() over(ORDER BY salary DESC) as salaryid FROM Employee
)
SELECT TOP(1) ISNULL(cte.salary, NULL) AS SecondHighestSalary
FROM (VALUES(NULL)) AS tb(col) 
LEFT JOIN cte ON cte.salaryid = 2
