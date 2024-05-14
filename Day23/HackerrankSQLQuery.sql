-- https://www.hackerrank.com/challenges/placements/problem?isFullScreen=true
with CTE(Id, name, salary) AS 
(select f.ID, s.Name, p.salary from students s join friends f on s.id = f.friend_ID join packages p on p.id = f.friend_ID)
select s.Name from students s join CTE on s.Id = CTE.Id join packages pa on pa.id = s.id where CTE.salary>pa.salary order by CTE.Salary;