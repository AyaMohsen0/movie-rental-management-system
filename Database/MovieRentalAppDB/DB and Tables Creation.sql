-- Create the database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'MovieRentalAppDB')
BEGIN
    CREATE DATABASE MovieRentalAppDB;
END
GO
USE MovieRentalAppDB;
GO

/*
ALTER TABLE Customer 
ALTER COLUMN UserName VARCHAR(100) NOT NULL;

CREATE UNIQUE INDEX IX_Customer_UserName ON Customer(UserName);
*/

-- Admin Table
CREATE TABLE Admin (
    AdminID VARCHAR(50) PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL
);
GO

-- Movie_Genre Table (represents genre)
CREATE TABLE Movie_Genre (
    GenreName VARCHAR(100) PRIMARY KEY,
    Description VARCHAR(255)
);
GO

-- Movie_Tape Table (represents movie)
CREATE TABLE Movie_Tape (
    MovieID INT PRIMARY KEY,
    Title VARCHAR(100),
    ReleaseYear INT,
    AddDate DATE,
    LeadActor VARCHAR(100),
    NoOfCopies INT,
    AvailabilityStatus BIT,
    Price_Per_Day DECIMAL(6,2) NOT NULL DEFAULT 0
);
GO

-- MovieGenre Table (associative table between Movie and Genre)
CREATE TABLE MovieGenre (
    MovieID INT,
    GenreName VARCHAR(100),
    PRIMARY KEY (MovieID, GenreName),
    FOREIGN KEY (MovieID) REFERENCES Movie_Tape(MovieID),
    FOREIGN KEY (GenreName) REFERENCES Movie_Genre(GenreName)
);
GO

-- AddsAndUpdates Table (Admin to Movie relationship)
CREATE TABLE AddsAndUpdates (
    AdminID VARCHAR(50),
    MovieID INT,
    PRIMARY KEY (AdminID, MovieID),
    FOREIGN KEY (AdminID) REFERENCES Admin(AdminID),
    FOREIGN KEY (MovieID) REFERENCES Movie_Tape(MovieID)
);
GO

-- Customer Table
CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Fname VARCHAR(100),
    Lname VARCHAR(100),
    UserName VARCHAR(100),
    Password VARCHAR(100),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    CreditCardNumber VARCHAR(30),
    BusinessAddress VARCHAR(255),
    ResidenceAddress VARCHAR(255)
);
GO

-- MemberShip Table
CREATE TABLE MemberShip (
    MemberShipID INT  IDENTITY(1,1) PRIMARY KEY,
    Price DECIMAL(6,2),
    StartDate DATE,
    EndDate DATE,
    Status VARCHAR(50),
    Type VARCHAR(50)
);
GO

-- SubscribesTo Table (relationship between Customer and Membership)
CREATE TABLE SubscribesTo (
    CustomerID INT,
    MemberShipID INT,
    PRIMARY KEY (CustomerID, MemberShipID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (MemberShipID) REFERENCES MemberShip(MemberShipID)
);
GO

-- Supplier Table
CREATE TABLE Supplier (
    SupplierName VARCHAR(100) PRIMARY KEY,
    SupplierEmail VARCHAR(100),
    SupplierPhone VARCHAR(20)
);
GO

-- MovieSupply Table
CREATE TABLE MovieSupply (
    MovieID INT,
    SupplierName VARCHAR(100),
    SupplyDate DATE,
    PRIMARY KEY (MovieID, SupplierName, SupplyDate),
    FOREIGN KEY (MovieID) REFERENCES Movie_Tape(MovieID),
    FOREIGN KEY (SupplierName) REFERENCES Supplier(SupplierName)
);
GO

-- Rental Table
CREATE TABLE Rental (
    RentalID INT PRIMARY KEY IDENTITY(1,1),
    MemberShipID INT,
    MovieID INT,
    RentalDate DATE,
    ReturnDate DATE,
    RentalDuration INT,
    Quantity INT,
    RentalCharge DECIMAL(6,2),
    FOREIGN KEY (MemberShipID) REFERENCES MemberShip(MemberShipID),
    FOREIGN KEY (MovieID) REFERENCES Movie_Tape(MovieID)
);
GO


-- Admin
INSERT INTO Admin (AdminID, Email, Password)
VALUES 
('a1', 'admin1@example.com', 'pass123'),
('a2', 'admin2@example.com', 'admin456');
GO

-- Movie_Genre
INSERT INTO Movie_Genre (GenreName, Description)
VALUES 
('Action', 'High energy and lots of stunts'),
('Comedy', 'Light-hearted and humorous content'),
('Drama', 'Serious, character-driven stories');
GO

-- Movie_Tape
INSERT INTO Movie_Tape (MovieID, Title, ReleaseYear, AddDate, LeadActor, NoOfCopies, AvailabilityStatus, Price_Per_Day)
VALUES
(101, 'Fast Fury', 2020, '2024-01-01', 'Vin Speed', 5, 1, 3.99),
(102, 'Laugh Riot', 2019, '2024-01-03', 'Amy Funny', 3, 1, 2.99),
(103, 'Tears of Steel', 2021, '2024-02-10', 'John Sadman', 4, 1, 4.50);
GO

-- MovieGenre
INSERT INTO MovieGenre (MovieID, GenreName)
VALUES 
(101, 'Action'),
(102, 'Comedy'),
(103, 'Drama');
GO

-- AddsAndUpdates
INSERT INTO AddsAndUpdates (AdminID, MovieID)
VALUES 
('a1', 101),
('a1', 102),
('a2', 103);
GO

-- Customer
INSERT INTO Customer (Fname, Lname, UserName, Password, Email, PhoneNumber, CreditCardNumber, BusinessAddress, ResidenceAddress)
VALUES
('Alice', 'Smith', 'asmith', 'alicepass', 'alice@example.com', '1234567890', '4111111111111111', '123 Biz St', '456 Home St'),
('Bob', 'Johnson', 'bjohnson', 'bobpass', 'bob@example.com', '9876543210', '5500000000000004', '789 Biz Ave', '321 Home Ave');
GO

-- MemberShip
INSERT INTO MemberShip (Price, StartDate, EndDate, Status, Type)
VALUES
(29.99, '2024-01-01', '2024-12-31', 'Active', 'Premium'),
(9.99, '2024-03-01', '2024-08-31', 'Active', 'Basic');
GO

-- SubscribesTo
INSERT INTO SubscribesTo (CustomerID, MemberShipID)
VALUES
(1, 1),
(2, 2);
GO

-- Supplier
INSERT INTO Supplier (SupplierName, SupplierEmail, SupplierPhone)
VALUES
('MegaMovies', 'contact@megamovies.com', '1231231234'),
('FilmSource', 'sales@filmsource.com', '4564564567');
GO

-- MovieSupply
INSERT INTO MovieSupply (MovieID, SupplierName, SupplyDate)
VALUES
(101, 'MegaMovies', '2024-01-05'),
(102, 'FilmSource', '2024-01-10'),
(103, 'MegaMovies', '2024-02-15');
GO

-- Rental
INSERT INTO Rental (MemberShipID, MovieID, RentalDate, ReturnDate, RentalDuration, Quantity, RentalCharge)
VALUES
(1, 101, '2024-04-01', '2024-04-03', 2, 1, 7.98),
(2, 102, '2024-04-05', '2024-04-06', 1, 1, 2.99),
(1, 103, '2024-04-07', '2024-04-10', 3, 2, 27.00);
GO

-------------------------------------------------------------------------
/*--Cleaning Script
-- Ensure you're in the correct database
USE MovieRentalAppDB;
GO

-- Disable and Drop Triggers (if they exist)
IF OBJECT_ID('trg_CalculateRentalCharge', 'TR') IS NOT NULL
    DROP TRIGGER trg_CalculateRentalCharge;
IF OBJECT_ID('trg_UpdateAvailabilityAfterRental', 'TR') IS NOT NULL
    DROP TRIGGER trg_UpdateAvailabilityAfterRental;
IF OBJECT_ID('trg_UpdateAvailabilityAfterReturn', 'TR') IS NOT NULL
    DROP TRIGGER trg_UpdateAvailabilityAfterReturn;
GO

-- Drop Foreign Key Constraints
IF OBJECT_ID('Rental', 'U') IS NOT NULL
BEGIN
    ALTER TABLE Rental DROP CONSTRAINT IF EXISTS FK_Rental_Movie;
    ALTER TABLE Rental DROP CONSTRAINT IF EXISTS FK_Rental_Membership;
END

IF OBJECT_ID('MovieGenre', 'U') IS NOT NULL
BEGIN
    ALTER TABLE MovieGenre DROP CONSTRAINT IF EXISTS FK_MovieGenre_Movie;
    ALTER TABLE MovieGenre DROP CONSTRAINT IF EXISTS FK_MovieGenre_Genre;
END

IF OBJECT_ID('MovieSupply', 'U') IS NOT NULL
BEGIN
    ALTER TABLE MovieSupply DROP CONSTRAINT IF EXISTS FK_MovieSupply_Supplier;
    ALTER TABLE MovieSupply DROP CONSTRAINT IF EXISTS FK_MovieSupply_Movie;
END

IF OBJECT_ID('SubscribesTo', 'U') IS NOT NULL
BEGIN
    ALTER TABLE SubscribesTo DROP CONSTRAINT IF EXISTS FK_SubscribesTo_Customer;
    ALTER TABLE SubscribesTo DROP CONSTRAINT IF EXISTS FK_SubscribesTo_Membership;
END

IF OBJECT_ID('AddsAndUpdates', 'U') IS NOT NULL
BEGIN
    ALTER TABLE AddsAndUpdates DROP CONSTRAINT IF EXISTS FK_AddsAndUpdates_Admin;
    ALTER TABLE AddsAndUpdates DROP CONSTRAINT IF EXISTS FK_AddsAndUpdates_Movie;
END

-- Drop Tables in Order (child to parent)
DROP TABLE IF EXISTS Rental;
DROP TABLE IF EXISTS MovieGenre;
DROP TABLE IF EXISTS MovieSupply;
DROP TABLE IF EXISTS SubscribesTo;
DROP TABLE IF EXISTS AddsAndUpdates;
DROP TABLE IF EXISTS Movie_Tape;
DROP TABLE IF EXISTS Movie_Genre;
DROP TABLE IF EXISTS Membership;
DROP TABLE IF EXISTS Supplier;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Admin;
GO
*/