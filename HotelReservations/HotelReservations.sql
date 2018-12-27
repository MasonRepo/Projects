USE master
DROP DATABASE HotelReservations

USE master
GO

Create Database HotelReservations
GO

USE HotelReservations
GO

CREATE TABLE RoomType (
	RoomTypeID INT Identity(1,1) PRIMARY KEY,
    RoomType VarChar(100) NOT NULL
)

CREATE TABLE Amenity (
	AmenityID INT Identity(1,1) PRIMARY KEY,
    Amenity VarChar(100) NOT NULL,
)


CREATE TABLE [Floor] (
	FloorID INT Identity(1,1) PRIMARY KEY,
    [Floor] SmallINT NOT NULL
)


CREATE TABLE Room (
	RoomID INT Identity(1,1) PRIMARY KEY,
	RoomTypeID INT FOREIGN KEY REFERENCES RoomType(RoomTypeID) NOT NULL,
	FloorID INT FOREIGN KEY REFERENCES [Floor](FloorID) NOT NULL
)

CREATE TABLE RoomAmenity(
	RoomAmenityID INT Identity(1,1) PRIMARY KEY,
	Room INT FOREIGN KEY REFERENCES Room(RoomID) NOT NULL,
	AmenityID INT FOREIGN KEY REFERENCES Amenity(AmenityID) NULL
)


CREATE TABLE RoomRate (
	RoomID INT FOREIGN KEY REFERENCES Room(RoomID) PRIMARY KEY,
	StartDate DateTime2 NOT NULL,
	EndDate DateTime2 NOT NULL,
	RoomRate Decimal NOT NULL
)

CREATE TABLE Promotion(
	PromotionID INT Identity(1,1) PRIMARY KEY,
	Promotion nVARCHAR(30) NOT NULL,
	PromotionDiscount Decimal NOT NULL,
	PromotionStart DateTime2 NOT NULL,
	PromotionEnd DATETIME NOT NULL

)


CREATE TABLE Customer (
	CustomerID INT Identity(1,1) PRIMARY KEY,
    [Name] nVARCHAR(100) NOT NULL,
	Phone INT NOT NULL,
	Email nVARCHAR(30) NOT NULL
)

CREATE TABLE Reservations (
	ReservationsID INT Identity(1,1) PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID) NOT NULL,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL
)

CREATE TABLE Guests (
	GuestsID INT Identity(1,1) PRIMARY KEY,
	[Name]  nVARCHAR(100) NOT NULL,
	isAdult Bit NOT NULL,
	ReservationsID INT FOREIGN KEY REFERENCES Reservations(ReservationsID) NULL
)

-- THIS IS THE ONE THAT IS GOING TO CONTAIN ALL THE INFORMATION 
-- SO USE THIS ONE FOR ORDERS AND THE LIKE.

CREATE TABLE RoomReservations (
	RoomReservationsID INT Identity(1,1) PRIMARY KEY,
	ReservationsID INT FOREIGN KEY REFERENCES Reservations(ReservationsID) NOT NULL,
	RoomAmenity INT FOREIGN KEY REFERENCES RoomAmenity(RoomAmenityID) NOT NULL,
	PromotionID INT FOREIGN KEY REFERENCES Promotion(PromotionID) NULL

)

CREATE TABLE AddOns (
	AddOnsID INT Identity(1,1) PRIMARY KEY,
	Addon nVARCHAR(100) NOT NULL
)

CREATE TABLE AddonRates (
	AddonID INT FOREIGN KEY REFERENCES Addons(AddOnsID) PRIMARY KEY,
	StartDate DateTime2 NOT NULL,
	EndDate DateTime2 NOT NULL,
	AddonRate Decimal NOT NULL
)

CREATE TABLE OrderDetails (
	OrderDetailsID INT Identity(1,1) PRIMARY KEY,
	RoomReservationsID INT FOREIGN KEY REFERENCES RoomReservations(RoomReservationsID) NOT NULL,
	AddonRatesID INT FOREIGN KEY REFERENCES AddOnRates(AddonID)
)

CREATE TABLE Total (
	TotalID INT Identity(1,1) PRIMARY KEY,
	OrderDetailsID INT FOREIGN KEY REFERENCES OrderDetails(OrderDetailsID) NOT NULL,
	Discount Decimal NULL,
	Tax Decimal NOT NULL,
	Total Decimal NOT NULL
)



--INSERT INTO RoomType(RoomType)
--VALUES ('Single'),
--	('Double'),
--	('Queen'),
--	('King')

--INSERT INTO [Floor]([Floor])
--VALUES (1),
--	(2),
--	(3),
--	(4),
--	(5)

--INSERT INTO Amenity(Amenity)
--VALUES ('Pool Side'),
--	('Not Terrible'),
--	('Pretty Terrible'),
--	('Free Water'),
--	('A/C Broken')

--INSERT INTO Room(RoomTypeID,FloorID,AmenityID)
--VALUES (1,1,4),
--	(2,1,1),
--	(3,1,2),
--	(4,1,3),
--	(1,2,4),
--	(2,2,1),
--	(3,2,2),
--	(4,2,3),
--	(1,3,4),
--	(2,3,1),
--	(3,3,2),
--	(4,3,3),
--	(1,4,4),
--	(2,4,1)


--INSERT INTO RoomRate(RoomID,StartDate,EndDate,RoomRate)
--VALUES (1,'01/01/2019','04/01/2019',25.00),
--	(2,'04/02/2019','06/01/2019',55.00),
--	(3,'06/02/2019','09/01/2019',45.00),
--	(4,'09/02/2019','12/31/2019',37.00)

--INSERT INTO Promotion(Promotion,PromotionStart,PromotionEnd,PromotionDiscount)
--VALUES ('Half Off','01/01/2019','04/01/2019',50.00),
--	('Spring Special','04/02/2019','06/01/2019',25.00),
--	('Summer Special','06/02/2019','09/01/2019',25.00),
--	('Fall/Winter Special','09/02/2019','12/31/2019',25.00)

--INSERT INTO Guests([Name], isAdult)
--VALUES ('Mason',1),
--	('Steve',0),
--	('Richard',1),
--	('Danny',1)



--INSERT INTO Customer([Name],Phone,Email,PromotionID)
--VALUES ('Corbin',12345678,'Corbin@aol.com',1),
--	('Jim',12325678,'Jim@aol.com',2),
--	('Kyle',12345678,'Anon@aol.com',3),
--	('Eric',12345678,'Anon@aol.com',1),
--	('Bill',12345678,'Anon@aol.com',1),
--	('Steeve',12345678,'Anon@aol.com',1),
--	('Super Steve',12325678,'Anon@aol.com',NULL),
--	('James',12345678,'Anon@aol.com',NULL),
--	('Aaron',12345678,'Anon@aol.com',NULL),
--	('Tom',12345678,'Anon@aol.com',NULL)






--INSERT INTO Occupants(CustomerID,GuestsID)
--VALUES (1,1),
--	(2,1),
--	(3,2),
--	(4,3),
--	(5,1),
--	(6,1),
--	(7,2),
--	(8,3),
--	(9,1),
--	(10,1),
--	(1,2),
--	(3,3)


--INSERT INTO Reservations(OccupantsID,StartDate,EndDate)
--VALUES (1,'02/04/2014','03/01/2014'),
--	(2,'06/04/2014','06/21/2014'),
--	(3,'07/04/2014','08/01/2014'),
--	(4,'02/04/2014','03/01/2014'),
--	(5,'06/04/2014','06/21/2014'),
--	(6,'07/04/2014','08/01/2014'),
--	(7,'02/04/2014','03/01/2014'),
--	(8,'06/04/2014','06/21/2014'),
--	(9,'07/04/2014','08/01/2014'),
--	(10,'07/04/2014','08/01/2014')


--INSERT INTO Reservations(OccupantsID,StartDate,EndDate)
--VALUES (3,GETDATE(),DATEADD(day,1, GETDATE())),
--	(2,'10/7/2018',DATEADD(day,1, GETDATE()))


--INSERT INTO RoomReservations(ReservationsID,RoomID)
--VALUES (1,3),
--	(2,2),
--	(3,1),
--	(4,4),
--	(5,3),
--	(6,2),
--	(7,1),
--	(8,4),
--	(9,3),
--	(10,2)

--INSERT INTO AddOns(Addon, Price)
--VALUES ('Movies', 15.00),
--	('Beverage Bar', 5.00),
--	('Room Service', 7.00),
--	('Internet', 25.00)


--INSERT INTO OrderDetails(RoomReservationsID,AddOnsID)
--VALUES (1,1),
--	(1,2),
--	(2,1),
--	(3,4)
	
---- These values would be something that the program itself would handle
---- such as calculation discounts vs the total and generating tax based on region.
---- so for now I'm going to put in dummy values.

--INSERT INTO Total(OrderDetailsID,Discount,Tax,Total)
--VALUES (1,null,0.20, 384.13),
--	(2, .10,0.20, 431.20),
--	(3,null,0.20, 341.23),
--	(4, .50,0.20, 120.00)



----Reservations that end tomorrow
---- for whatever reason this isn't working....

--Select *
--From Reservations
--Where CONVERT(DATETIME,Reservations.EndDate) = GETDATE() + 1


----All rooms reserved for a particular customer

--Select RoomType.RoomType, Customer.Name
--From RoomReservations
--Join Reservations on RoomReservations.ReservationsID = Reservations.ReservationsID
--Join Occupants on Reservations.OccupantsID = Occupants.OccupantsID
--Join Customer on Occupants.CustomerID = Customer.CustomerID
--Join Room on RoomReservations.RoomID = Room.RoomID
--Join RoomType on Room.RoomTypeID = RoomType.RoomTypeID
---- THIS IS WHERE YOU WOULD PICK WHICH CUSTOMER YOU WOULD LIKE TO SEE.
--Where Customer.CustomerID = 2


----Promotion codes, and the number of times used.

--SELECT *
--From Customer
--Where Customer.PromotionID IS not NULL



----The 3 most expensive bills upcoming in the next month

--SELECT TOP 3 Total.OrderDetailsID,Total, Reservations.EndDate
--From Total
--Join OrderDetails on OrderDetails.OrderDetailsID = Total.OrderDetailsID
--Join RoomReservations on OrderDetails.RoomReservationsID = RoomReservations.RoomReservationsID
--Join Reservations on RoomReservations.ReservationsID = Reservations.ReservationsID
--Where Reservations.EndDate = DATEADD(month, 1, GETDATE())



----Rooms that do not contain a specific amenity
--Select *
--From Room
--Where Room.AmenityID IS NOT NULL



----All rooms available for a date range
--Select *
--FROM RoomReservations
--JOIN Room on RoomReservations.RoomID = Room.RoomID
--JOIN Reservations on RoomReservations.ReservationsID = Reservations.ReservationsID
---- Where Reservations.EndDate NOT BETWEEN  DATE RANGE HERE?

