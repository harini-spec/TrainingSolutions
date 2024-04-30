create database Company

use Company

-- create table EMP
create table EMP
(empno int identity(1,1) constraint pk_emp_id primary key,
empname varchar(20),
salary float,
deptname varchar(20),
bossno int)

sp_help EMP

-- create table DEPARTMENT
create table DEPARTMENT
(dept_Name varchar(20) constraint pk_dept_name primary key,
dept_Floor int,
dept_Phone varchar(10),
mgrid int constraint fk_emp_no foreign key references EMP(empno) not null)

sp_help DEPARTMENT

-- Alter references in EMP table
Alter table EMP 
add constraint fk_dept_name foreign key (deptname) references DEPARTMENT(dept_Name)

sp_help EMP

Alter table EMP
add constraint fk_boss_no foreign key (bossno) references EMP(empno)

-- create table SALES
create table SALES
(salesno int identity(100, 1) constraint pk_sales_no primary key,
salesqty int,
itemname varchar(30) not null,
deptname varchar(20) constraint fk_dept_name_in_sales foreign key references DEPARTMENT(dept_Name) not null)

sp_help SALES

-- create table ITEM
create table ITEM
(itemname varchar(30) constraint pk_item_name primary key,
itemtype varchar(5), 
itemcolor varchar(20))

sp_help ITEM

-- Alter references in SALES table
Alter table SALES
add constraint fk_item_name_in_sales foreign key (itemname) references ITEM(itemname)

sp_help SALES

-- insert data into EMP table 
insert into EMP (empname, salary) values ('Alice', 75000)
insert into EMP (empname, salary) values ('Ned', 45000)
insert into EMP (empname, salary) values ('Andrew', 25000)
insert into EMP (empname, salary) values ('Clare', 22000)
insert into EMP (empname, salary) values ('Todd', 38000)
insert into EMP (empname, salary) values ('Nancy', 22000)
insert into EMP (empname, salary) values ('Brier', 43000)
insert into EMP (empname, salary) values ('Sarah', 56000)
insert into EMP (empname, salary) values ('Sophile', 35000)
insert into EMP (empname, salary) values ('Sanjay', 15000)
insert into EMP (empname, salary) values ('Rita', 15000)
insert into EMP (empname, salary) values ('Gigi', 16000)
insert into EMP (empname, salary) values ('Maggie', 11000)
insert into EMP (empname, salary) values ('Paul', 15000)
insert into EMP (empname, salary) values ('James', 15000)
insert into EMP (empname, salary) values ('Pat', 15000)
insert into EMP (empname, salary) values ('Mark', 15000)

select * from EMP

-- insert data into DEPT table
insert into DEPARTMENT values ('Management', 5, 34, 1)
insert into DEPARTMENT values ('Marketing', 5, 38, 2), ('Accounting', 5, 35, 5), ('Purchasing', 5, 36, 7), ('Personnel', 5, 37, 9), ('Navigation', 1, 41, 3), ('Books', 1, 81, 4), ('Clothes', 2, 24, 4), ('Equipment', 3, 57, 3), ('Furniture', 4, 14, 3), ('Recreation', 2, 29, 4)

select * from DEPARTMENT

update EMP set deptname = 'Management' where empno = 1
update EMP set deptname = 'Marketing', bossno = 1 where empno = 2
update EMP set deptname = 'Marketing', bossno = 2 where empno = 3
update EMP set deptname = 'Marketing', bossno = 2 where empno = 4
update EMP set deptname = 'Accounting', bossno = 1 where empno = 5
update EMP set deptname = 'Accounting', bossno = 5 where empno = 6
update EMP set deptname = 'Purchasing', bossno = 1 where empno = 7
update EMP set deptname = 'Purchasing', bossno = 7 where empno = 8
update EMP set deptname = 'Personnel', bossno = 1 where empno = 9
update EMP set deptname = 'Navigation', bossno = 3 where empno = 10
update EMP set deptname = 'Books', bossno = 4 where empno = 11
update EMP set deptname = 'Clothes', bossno = 4 where empno = 12
update EMP set deptname = 'Clothes', bossno = 4 where empno = 13
update EMP set deptname = 'Equipment', bossno = 3 where empno = 14
update EMP set deptname = 'Equipment', bossno = 3 where empno = 15
update EMP set deptname = 'Furniture', bossno = 3 where empno = 16
update EMP set deptname = 'Recreation', bossno = 3 where empno = 17

select * from EMP 

-- insert data into item table
insert into ITEM values ('Pocket Knife-Nile', 'E', 'Brown'), ('Pocket Knife-Avon', 'E', 'Brown'), ('Compass', 'N', null), ('Geo positioning system', 'N', null), ('Elephant Polo stick', 'R', 'Bamboo')
select * from ITEM

-- insert data into sales table
insert into SALES values(2, 'Pocket Knife-Nile', 'Clothes'), (3, 'Pocket Knife-Nile', 'Recreation'), (2, 'Geo positioning system', 'Navigation'), (1, 'Compass', 'Navigation'), (1, 'Elephant Polo stick', 'Recreation')
select * from SALES