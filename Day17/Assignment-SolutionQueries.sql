use pubs 

-- 1. Print the storeid and number of orders for the store
select st.stor_id, count(*) as "Number of Orders" from stores st join sales sl on st.stor_id = sl.stor_id group by st.stor_id 

-- 2. Print the number of orders for every title
select s.title_id, t.title, count(*) as "Number of Orders" from titles t join sales s on s.title_id = t.title_id group by s.title_id, t.title 

-- 3. print the publisher name and book name
select p.pub_name as "Publisher name", t.title as "Book name" from titles t join publishers p on t.pub_id = p.pub_id

-- 4. Print the author full name for all the authors
select concat(au_fname, ' ', au_lname) "Author Full name" from authors order by au_fname 

-- 5. Print the price of every book with tax (price+price*12.36/100)
select title, price "Price before Tax", (price + (price * (12.36/100))) as "Price with Tax" from titles 

-- 6. Print the author name, title name
select title, concat(au_fname, ' ', au_lname) "Author name" from authors a 
join titleauthor ta on a.au_id = ta.au_id 
join titles t on t.title_id = ta.title_id

-- 7. print the author name, title name and the publisher name
select concat(au_fname, ' ', au_lname) "Author name", t.title, p.pub_name from authors a 
join titleauthor ta on a.au_id = ta.au_id 
join titles t on t.title_id = ta.title_id 
join publishers p on p.pub_id = t.pub_id

-- 8. Print the average price of books pulished by every publicher
select p.pub_name, avg(t.price) as "Average price of Books published" from publishers p 
join titles t on t.pub_id = p.pub_id group by pub_name 

-- 9. Print the books published by 'Marjorie'
select t.title, concat(a.au_fname, ' ', a.au_lname) "Author name" from authors a 
join titleauthor ta on ta.au_id = a.au_id 
join titles t on t.title_id = ta.title_id 
where concat(a.au_fname, ' ', a.au_lname) like ('%Marjorie%')

-- 10. Print the order numbers of books published by 'New Moon Books'
select s.ord_num, t.title, p.pub_name from titles t 
join publishers p on t.pub_id = p.pub_id 
join sales s on s.title_id = t.title_id 
where p.pub_name = 'New Moon Books'

-- 11. Print the number of orders for every publisher
select t.pub_id, p.pub_name, count(*) "Number of orders" from titles t 
join publishers p on t.pub_id = p.pub_id 
join sales s on s.title_id = t.title_id 
group by t.pub_id, p.pub_name

-- 12. print the order number , book name, quantity, price and the total price for all orders
select s.ord_num, t.title, s.qty, t.price, (t.price*s.qty) as "Total price" from sales s 
join titles t on s.title_id = t.title_id order by ord_num 

-- 13. print the total order quantity for every book
select s.title_id, t.title, sum(qty) as "Total order quantity" from sales s 
join titles t on s.title_id = t.title_id group by s.title_id, t.title

-- 14. print the total order value for every book
select s.title_id, t.title, sum(t.price * s.qty) "Total order value" from sales s 
join titles t on s.title_id = t.title_id group by s.title_id, t.title

-- 15. print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.ord_num from employee e join titles t on t.pub_id = e.pub_id 
join sales s on s.title_id = t.title_id 
where Concat(e.fname, ' ', e.minit, ' ', e.lname) like ('%Paolo%')

select * from stores 
select * from sales order by title_id  
select * from titles order by pub_id
select * from publishers
select * from authors 
select * from titleauthor
select * from employee 