CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        SELECT TOP(1) ISNULL(cte.salary, NULL) AS SecondHighestSalary
        FROM (VALUES(NULL)) AS tb(col)
        LEFT JOIN (SELECT salary, DENSE_RANK() over(ORDER BY salary DESC) as salaryid FROM Employee) as cte
            ON cte.salaryid = @N
    );
END
