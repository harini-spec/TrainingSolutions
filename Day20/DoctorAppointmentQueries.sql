create database DoctorAppointment

use DoctorAppointment 

create table Patients
(Id int identity(1,1) constraint pk_PatientID primary key , 
name varchar(20),
Age int,
Gender varchar(10))

create table Doctors
(Id int identity(1,1) constraint pk_DoctorID primary key,
name varchar(20),
Age int,
Specialization varchar(20),
Qualification varchar(20),
Experience int)

create table Appointments
(Id int identity(1,1) constraint pk_AppointmentID primary key,
Doctor int constraint fk_DoctorID foreign key references Doctors(Id),
Patient int constraint fk_PatientID foreign key references Patients(Id),
AppointmentDate DateTime,
status varchar(10))

select * from Appointments
select * from Doctors 
select * from Patients

drop table Doctors 
drop table Appointments

delete from Doctors 
delete from Appointments 


insert into Doctors (name, Age, Specialization, Qualification, Experience) values ('Sara', 30, 'GS', 'MBBS', 5)
insert into Doctors (name, Age, Specialization, Qualification, Experience) values ('Chen', 30, 'Neuro', 'MBBS', 5)

insert into Patients (name, Age, Gender) values ('Sam', 34, 'Female')
insert into Appointments (Doctor, Patient, AppointmentDate, status) values (9, 1, '2024-05-08', 'Pending')