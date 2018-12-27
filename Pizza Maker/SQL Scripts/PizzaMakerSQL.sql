USE MASTER
go

--Drop Database PizzaMaker
--Go

--Create Database PizzaMaker
--Go

Use PizzaMaker
Go

Create Table Player(

	PlayerID int identity(1,1) primary key not null,
	LoginID NVARCHAR(128) foreign key references AspNetUsers(Id) NOT NULL,
	PizzaAmount decimal NOT NULL,
	DateCreated DateTime2 NOT NULL
)


Create Table Upgrades(

	UpgradesID int identity(1,1) primary key not null,
	UpgradesName NVARCHAR(80) NOT NULL,
	PercentIncrease decimal NOT NULL
)
Select * From Upgrades

Create Table PlayerUpgrades(

	PlayerUpgradesID int identity(1,1) primary key NOT NULL,
	PlayerID int foreign key references Player(PlayerID) not null,
	UpgradeID int foreign key references Upgrades(UpgradesID) not null,
	Price decimal NOT NULL,
	-- true or false to indicate if it has been purchased.
	IsPurchased bit NOT NULL
)


Create Table Buildings(

	BuildingID int identity(1,1) primary key not null,
	BuildingName NVARCHAR(80) NOT NULL,
	PizzaIncrease decimal NOT NULL,
	BaseCost decimal NOT NULL

)

Create Table PlayerBuildings(

	PlayerID int foreign key references Player(PlayerID) not null,
	BuildingID int foreign key references Buildings(BuildingID) not null,
	Price decimal NOT NULL,
	-- how many buildings they have.
	AmountPlayerHas decimal NOT NULL
)

--These are going to be test values for the web page to get it up and running....
-- hopefully..

Insert into Buildings(BuildingName, PizzaIncrease, BaseCost)
Values ('Brick Oven', 1.2, 10),
	('Super Oven', 10, 600),
	('MEGA Oven', 35, 2100),
	('Space Oven', 66, 4356),
	('Quantum Oven', 105, 6300),
	('THE Oven', 315, 18900) 

Insert Into Upgrades (UpgradesName, PercentIncrease)
Values ('Super Cheese', 5),
('Super Veggies', 5),
('Super Meats', 5),
('MEGA DOUGH', 10),
('SUN BAKED', 15)

--Insert into Player(FirstName,LastName,PizzaAmount,DateCreated)
--Values('Mason','Berge', 10, '01/08/1995')

INSERT INTO AspNetRoles(Id, [Name])
Values(1,'Admin'),
	(2,'User')


	
--Select *
--from Buildings, PlayerBuildings
--Where Buildings.BuildingID = PlayerBuildings.BuildingID 
--Go

Select * 
From Buildings
