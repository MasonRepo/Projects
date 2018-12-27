USE master
GO
drop database GameShow
go

USE MASTER
go
CREATE DATABASE GameShow
GO

use GameShow
go



CREATE TABLE Rounds(
	RoundID INT IDENTITY(1,1) PRIMARY KEY,
	BankerPercentage Decimal NOT NULL
) 


CREATE TABLE Player(

	PlayerID INT IDENTITY(1,1) PRIMARY KEY,
	FullName NVARCHAR(30) NOT NULL,
	BackStory NVARCHAR(60) NULL,
	EndingSum Decimal NULL
)

CREATE TABLE Briefcases (
	BriefcaseID INT Identity(1,1) PRIMARY KEY,
	PlayerID INT FOREIGN KEY REFERENCES Player(PlayerID) NOT NULL,
    Amount Decimal NOT NULL
)


--Yeah IDK if I am going to need this one I might just make the game state the one that I use......
--CREATE TABLE RoundBriefcases(

--	RoundID INT IDENTITY(1,1) PRIMARY KEY,
--	BankerPercentage Decimal NOT NULL
--) 

CREATE TABLE GameState(

	GameStateID INT IDENTITY(1,1) Primary Key,
	PlayerID INT FOREIGN KEY REFERENCES Player(PlayerID) NOT NULL,
	RoundID INT FOREIGN KEY REFERENCES Rounds(RoundID) NOT NULL,
	RoundNumber Decimal NOT NULL,
	AmountChosen DECIMAL NOT NUll,
)



--select *
--from Players


--select * 
--from Briefcases

--delete from Briefcases WHERE BriefCaseId=3
--DBCC CHECKIDENT('Briefcases',RESEED,0)

--insert into Briefcases(Amount)
--VALUES (100)




--insert into Rounds(BankerPercentage)
--values (0.1)

--select * 
--from Rounds
