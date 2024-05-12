use dbCFRequestTracker
use master 

sp_help Employees
sp_help Requests
sp_help Solutions

select * from Employees
select * from Requests
select * from Solutions
select * from SolutionFeedbacks

delete from solutions where requestSolutionId = 4

select * into dbCFRequestTracker.TempSolutions from Solutions


