use pubs 

-- 1. Create a stored procedure that will take the author firstname and print all the books pulished by him with the publisher's name
create proc AuthorBookDetails_proc(@aname varchar(20))
as
begin
	select a.au_fname as "Author Name", t.title as "Book Title", p.pub_name as "Publisher Name" from authors a join titleauthor ta on a.au_id = ta.au_id join titles t on t.title_id = ta.title_id join publishers p on p.pub_id = t.pub_id where a.au_fname = @aname
end

exec AuthorBookDetails_proc "Stearns"

drop proc AuthorBookDetails_proc

-- 2. Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
create proc EmployeeSoldBookDetails_proc(@ename varchar(20))
as
begin
	select e.fname "Employee Name", t.title "Book Title", t.price "Unit Price", s.qty "Quantity", (t.price * s.qty) "Total Cost" 
	from employee e join titles t on t.pub_id = e.pub_id 
	join sales s on s.title_id = t.title_id 
	where e.fname = @ename  
end

exec EmployeeSoldBookDetails_proc "Paolo"

drop proc EmployeeSoldBookDetails_proc

-- 3. Create a query that will print all names from authors and employees
select concat(fname, ' ', minit, ' ', lname) as Name from employee
union 
select concat(au_fname, ' ', au_lname) from authors

-- 4. Create a  query that will float the data from sales, titles, publisher and authors table to print 
-- title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
-- print first 5 orders after sorting them based on the price of order

-- using CTE
with OrderDetailsCTE(Title, Publiser_Name, Author_Name, Quantity, Unit_Price, Total_Cost)
as
(select t.title, p.pub_name, concat(a.au_fname, ' ', a.au_lname), s.qty, t.price, (t.price * s.qty) 
from titles t 
join publishers p on t.pub_id = p.pub_id 
join titleauthor ta on ta.title_id = t.title_id 
join authors a on a.au_id = ta.au_id
join sales s on s.title_id = t.title_id)

select top 5 * from OrderDetailsCTE order by Total_Cost desc

-- using view
create view vwOrderDetails
as
(select t.title "Book Title", p.pub_name "Publisher Name", concat(a.au_fname, ' ', a.au_lname) "Author Name", s.qty "Quantity", t.price "Unit Price", (t.price * s.qty) "Total Cost"
from titles t 
join publishers p on t.pub_id = p.pub_id 
join titleauthor ta on ta.title_id = t.title_id 
join authors a on a.au_id = ta.au_id
join sales s on s.title_id = t.title_id)

select top 5 * from vwOrderDetails order by [Total Cost] desc

drop view vwOrderDetails

-- using temp table
select top 5 t.title "Book Title", p.pub_name "Publisher Name", concat(a.au_fname, ' ', a.au_lname) "Author Name", s.qty "Quantity", t.price "Unit Price", (t.price * s.qty) "Total Cost"
from titles t 
join publishers p on t.pub_id = p.pub_id 
join titleauthor ta on ta.title_id = t.title_id		
join authors a on a.au_id = ta.au_id
join sales s on s.title_id = t.title_id order by [Total Cost] desc

------------------------------------------------------------------------------------------//

select * from authors 
select * from titles
select * from titleauthor
select * from publishers 
select * from sales  
select * from employee order by fname 