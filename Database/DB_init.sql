-----------------------
-- Creating database --
-----------------------
USE master;
CREATE DATABASE NoNameCoffeeBar COLLATE Croatian_CI_AS_KS_WS;
GO
USE NoNameCoffeeBar;

CREATE TABLE UserType(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(20) NOT NULL,
	UNIQUE(Name)
);

CREATE TABLE UserData(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	UserName VARCHAR(20) NOT NULL,
	Password VARCHAR(20) NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	UserTypeId INT REFERENCES UserType(Id) NOT NULL,
	UNIQUE(UserName)
);

CREATE TABLE Category(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(20) NOT NULL,
	UNIQUE(Name)
);

CREATE TABLE Product(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	AvailableQuantity INT NOT NULL,
	Price FLOAT NOT NULL,
	CategoryId INT REFERENCES Category(Id) NOT NULL,
	UNIQUE(Name)
);

CREATE TABLE Bill(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	"Number" VARCHAR(15) NOT NULL,
	UNIQUE("Number")
);

CREATE TABLE BillContent(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	ProductPrice FLOAT NOT NULL,
	ProductQuantity INT NOT NULL,
	ProductId INT REFERENCES Product(Id) NOT NULL,
	BillId INT REFERENCES Bill(Id) NOT NULL
);

CREATE TABLE BillStatus(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(10) NOT NULL,
	StatusTimestamp DATETIME NOT NULL,
	BillId INT REFERENCES Bill(Id) NOT NULL
);

CREATE TABLE FileData(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	FileTimestamp DATETIME NOT NULL,
	ContentType VARCHAR(20) NOT NULL,
	"Data" TEXT NOT NULL,
	UNIQUE(Name)
);

CREATE TABLE BillReport(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	"Year" INT NOT NULL,
	"Month" INT NOT NULL,
	"Day" INT NOT NULL,
	FileDataId INT REFERENCES FileData(Id) NOT NULL
);

CREATE TABLE SupplyReport(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	"Year" INT NOT NULL,
	"Month" INT NOT NULL,
	"Day" INT NOT NULL,
	FileDataId INT REFERENCES FileData(Id) NOT NULL
);

----------------------------
-- Example initialization --
----------------------------
INSERT INTO UserType VALUES ('Admin');
INSERT INTO UserType VALUES ('Waiter');

INSERT INTO UserData VALUES ('milan', 'milan', 'Milan Siklic', 1);
INSERT INTO UserData VALUES ('pero', 'pero', 'Pero Peric', 2);

INSERT INTO Category VALUES ('Topli');
INSERT INTO Category VALUES ('Pivo');
INSERT INTO Category VALUES ('Gazirani');
INSERT INTO Category VALUES ('Zestoka');
INSERT INTO Category VALUES ('Vocni');

INSERT INTO Product VALUES ('Kava', 10, 8, 1);
INSERT INTO Product VALUES ('Cappucino', 10, 12, 1);
INSERT INTO Product VALUES ('Caj', 10, 10, 1);
INSERT INTO Product VALUES ('Ozujsko', 10, 12, 2);
INSERT INTO Product VALUES ('Karlovacko', 10, 14, 2);
INSERT INTO Product VALUES ('Corona', 10, 15, 2);
INSERT INTO Product VALUES ('Jamnica Sensation', 10, 10, 3);
INSERT INTO Product VALUES ('Coca-Cola', 10, 15, 3);
INSERT INTO Product VALUES ('Sprite', 10, 15, 3);
INSERT INTO Product VALUES ('Rakija', 10, 15, 4);
INSERT INTO Product VALUES ('Jack Daniels', 10, 10, 4);
INSERT INTO Product VALUES ('Pago', 10, 12, 5);
INSERT INTO Product VALUES ('Cappy', 10, 13, 5);

INSERT INTO Bill VALUES ('2020-06-24-0001');
INSERT INTO Bill VALUES ('2020-06-24-0002');
INSERT INTO Bill VALUES ('2020-06-24-0003');
INSERT INTO Bill VALUES ('2020-06-24-0004');

INSERT INTO BillContent VALUES (2,  8, 1, 1);
INSERT INTO BillContent VALUES (15, 2, 6, 1);
INSERT INTO BillContent VALUES (12, 3, 12, 2);
INSERT INTO BillContent VALUES (15, 4, 8, 2);
INSERT INTO BillContent VALUES (10, 5, 7, 2);
INSERT INTO BillContent VALUES (10, 6, 10, 3);
INSERT INTO BillContent VALUES (12, 7, 2, 4);
INSERT INTO BillContent VALUES (10, 8, 3, 4);

INSERT INTO BillStatus VALUES ('CREATED', '2020-06-24 16:27:05', 1);
INSERT INTO BillStatus VALUES ('APPROVED', '2020-06-24 16:28:20', 1);
INSERT INTO BillStatus VALUES ('PAYED', '2020-06-24 17:00:00', 1);
INSERT INTO BillStatus VALUES ('CREATED', '2020-06-24 15:00:00', 2);
INSERT INTO BillStatus VALUES ('CREATED', '2020-06-24 16:00:00', 3);
INSERT INTO BillStatus VALUES ('APPROVED', '2020-06-24 16:01:12', 3);
INSERT INTO BillStatus VALUES ('CREATED', '2020-06-24 08:15:00', 4);
INSERT INTO BillStatus VALUES ('REJECTED', '2020-06-24 08:15:00', 4);

INSERT INTO FileData VALUES ('BillReport_A.txt', '2020-06-24 12:00:00', 'text/plain', 'Ovo je bill-izvjestaj A.');
INSERT INTO FileData VALUES ('BillReport_B.txt', '2020-06-25 00:00:00', 'text/plain', 'Ovo je bill-izvjestaj B.');
INSERT INTO FileData VALUES ('SupplyReport_A.txt', '2020-06-23 00:00:00', 'text/plain', 'Ovo je supply-izvjestaj A.');
INSERT INTO FileData VALUES ('SupplyReport_B.txt', '2020-06-24 00:00:00', 'text/plain', 'Ovo je supply-izvjestaj B.');

INSERT INTO BillReport VALUES (2020, 6, 24, 1);
INSERT INTO BillReport VALUES (2020, 6, 25, 2);

INSERT INTO SupplyReport VALUES (2020, 6, 23, 3);
INSERT INTO SupplyReport VALUES (2020, 6, 24, 4);
