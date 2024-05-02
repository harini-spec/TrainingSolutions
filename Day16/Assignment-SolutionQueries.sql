use pubs 

------------------------------------------------------------------------------------------------------------

select * from titles 

-- 1. Print all the titles names
select title from titles 

-- 2. Print all the titles that have been published by 1389
select title, pub_id from titles where pub_id = 1389

-- 3. Print the books that have price in range of 10 to 15
select title, price from titles where price between 10 and 15

-- 4. Print those books that have no price
select title, price from titles where price is Null

-- 5. Print the book names that start with 'The'
select title from titles where title like 'The%'

-- 6. Print the book names that do not have 'v' in their name
select title from titles where title not like '%v%'

-- 7. print the books sorted by the royalty
select title, royalty from titles order by royalty			-- sorted in ascending order 
select title, royalty from titles order by royalty desc		-- sorten in descending order 

-- 8. print the books sorted by publisher in descending then by types in asending then by price in descending
select * from titles order by pub_id desc, type, price desc

-- 9. Print the average price of books in every type
select type, avg(price) as 'Average Price' from titles group by type

-- 10. print all the types in uniques
select distinct(type) from titles  
-- (or)
select type from titles group by type 

-- 11. Print the first 2 costliest books 
select Top 2 * from titles order by price desc 
-- (or)
select * from (select *, Rank() over (order by price desc) as 'Book_Rank' from titles) as New_Table where Book_Rank<=2

-- 12. Print books that are of type business and have price less than 20 which also have advance greater than 7000
select * from titles where type = 'business' and price < 20 and advance > 7000

-- 13. Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. 
-- Print only those which have count greater than 2. Also sort the result in ascending order of count
select pub_id, count(title_id) as 'Books_count' from titles where 
price between 15 and 25 
and title like '%It%' 
group by pub_id 
having count(title_id) > 2 
order by count(title_id)

------------------------------------------------------------------------------------------------------------

select * from authors

-- 14. Print the Authors who are from 'CA'
select * from authors where state = 'CA'

-- 15. Print the count of authors from every state
select state, count(au_id) as 'Author_Count' from authors group by state 

