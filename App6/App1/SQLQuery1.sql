SELECT *
FROM Employees
WHERE CompanyId NOT IN (SELECT CompanyId FROM Companies)