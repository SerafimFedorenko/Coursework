use master
create database recycling_point;
go
use recycling_point
go
create table Positions (
	Id int not null identity(1,1) primary key,
	Name varchar(40)
);
create table Employees (
	Id int not null identity(1,1) primary key,
	Name varchar(30),
	SurName varchar(30),
	Patronymic varchar(30),
	Experience int,
	PositionId int not null,

	foreign key (PositionId)
	references Positions(Id)
	on delete cascade
	on update cascade
);

create table StorageTypes (
	Id int not null identity(1,1) primary key,
	Name varchar(30),
	Temperature int,
	Humidity int,
	Requirement varchar(100),
	Equipment varchar(100)
);
create table Storages (
	Id int not null identity(1,1) primary key,
	Name varchar(30),
	Number int,
	Square int,
	Capacity int,
	Percentage int,
	Depreciation int,
	CheckDate Date,
	StorageTypeId int not null,
	
	foreign key (StorageTypeId)
	references StorageTypes(Id)
	on delete cascade
	on update cascade
);

create table RecyclableTypes (
	Id int not null identity(1,1) primary key,
	Name varchar(30),
	Price decimal(18,3),
	Description varchar(100),
	AcceptanceCondition varchar(20),
	StorageCondition varchar(20)
);

create table AcceptedRecyclables (
	Id int not null identity(1,1) primary key,
	EmployeeId int not null,
	StorageId int not null,
	RecyclableTypeId int not null,
	Quantity int,
	Date date,

	foreign key (StorageId)
	references Storages(Id)
	on delete cascade
	on update cascade,

	foreign key (RecyclableTypeId)
	references RecyclableTypes(Id)
	on delete cascade
	on update cascade,

	foreign key (EmployeeId)
	references Employees(Id)
	on delete cascade
	on update cascade
);