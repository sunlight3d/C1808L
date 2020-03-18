create database HumanResourceManagement;


create table Department
(
	DeptID int primary key identity,
	DeptName nvarchar(50)

)

create table Employee
(
	EmpID int primary key identity,
	EmpName nvarchar(50),
	DeptID int not null references Department(DeptID),
	Address nvarchar(250),
	Email varchar(50),
	DOJ datetime,
	Gender bit,
	YearOfBirth int
)

insert into Department values ('Academic')
insert into Department values ('Marketing')
insert into Department values ('HR')
insert into Department values ('Counsellr')

insert into Employee values ('A',1,'Ha Noi','a@gmail.com',GETDATE(),1,1993)
insert into Employee values ('B',1,'Ha Giang','b@gmail.com',GETDATE(),0,1990)
insert into Employee values ('C',2,'Hoa Binh','c@gmail.com',GETDATE(),1,1992)
insert into Employee values ('D',2,'Thai Binh','d@gmail.com',GETDATE(),0,1992)
insert into Employee values ('E',3,'Ha Noi','e@gmail.com',GETDATE(),1,1995)
insert into Employee values ('F',4,'Ha Noi','f@gmail.com',GETDATE(),1,1992)
insert into Employee values ('G',3,'Nam Dinh','g@gmail.com',GETDATE(),0,1993)
insert into Employee values ('H',3,'Hai Duong','h@gmail.com',GETDATE(),1,1992)

select * from Department
select * from Employee
commit