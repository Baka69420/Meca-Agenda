USE master;
GO

CREATE DATABASE MecaAgenda;
GO

USE MecaAgenda;
GO

CREATE TABLE Branches (
	BranchID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	Description NVARCHAR(255) NOT NULL,
	Phone NVARCHAR(20) UNIQUE NOT NULL,
	Address NVARCHAR(200) UNIQUE NOT NULL,
	Email NVARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Services (
	ServiceID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	Description NVARCHAR(255) NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
	EstimatedTime INT NOT NULL, -- in minutes
	ToolsRequired NVARCHAR(255) NULL,
	MaterialsNeeded NVARCHAR(255) NULL
);

CREATE TABLE Categories (
	CategoryID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Users (
	UserID INT PRIMARY KEY IDENTITY(1,1),
	BranchID INT NULL,
	Name NVARCHAR(100) NOT NULL,
	Phone NVARCHAR(20) NOT NULL,
	Email NVARCHAR(100) UNIQUE NOT NULL,
	Address NVARCHAR(200) NOT NULL,
	BirthDate DATE NOT NULL,
	PasswordHash NVARCHAR(256) NOT NULL,
	Role NVARCHAR(20) CHECK (Role IN ('Client', 'Manager', 'Admin')) NOT NULL,
	CONSTRAINT FK_Users_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE Products (
	ProductID INT PRIMARY KEY IDENTITY(1,1),
	CategoryID INT NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Description NVARCHAR(255) NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
	Brand NVARCHAR(100) NOT NULL,
	StockQuantity INT NOT NULL,
	CONSTRAINT FK_Products_Category FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE BranchSchedules (
	ScheduleID INT PRIMARY KEY IDENTITY(1,1),
	BranchID INT NOT NULL,
	DayOfWeek TINYINT NOT NULL,
	OpenTime TIME NOT NULL,
	CloseTime TIME NOT NULL,
	CONSTRAINT FK_BranchSchedules_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE ScheduleExceptions (
	ExceptionID INT PRIMARY KEY IDENTITY(1,1),
	BranchID INT NOT NULL,
	Reason NVARCHAR(255) NOT NULL,
	Date DATE NOT NULL,
	StartTime TIME NOT NULL,
	EndTime TIME NOT NULL,
	ServicesAffected NVARCHAR(255) NOT NULL, -- List of service IDs affected
	CONSTRAINT FK_ScheduleExceptions_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE Bills (
	BillID INT PRIMARY KEY IDENTITY(1,1),
	ClientID INT NOT NULL,
	BranchID INT NOT NULL,
	Date DATE NOT NULL,
	TotalAmount DECIMAL(10, 2) NOT NULL,
	PaymentMethod NVARCHAR(50) NOT NULL,
	Paid BIT NOT NULL,
	CONSTRAINT FK_Bills_Client FOREIGN KEY (ClientID) REFERENCES Users(UserID),
	CONSTRAINT FK_Bills_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE Appointments (
	AppointmentID INT PRIMARY KEY IDENTITY(1,1),
	BillID INT NULL,
	ClientID INT NOT NULL,
	BranchID INT NOT NULL,
	ServiceID INT NOT NULL,
	Date DATE NOT NULL,
	StartTime TIME NOT NULL,
	EndTime TIME NOT NULL,
	Status NVARCHAR(50) NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
	CONSTRAINT FK_Appointments_Bill FOREIGN KEY (BillID) REFERENCES Bills(BillID),
	CONSTRAINT FK_Appointments_Client FOREIGN KEY (ClientID) REFERENCES Users(UserID),
	CONSTRAINT FK_Appointments_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID),
	CONSTRAINT FK_Appointments_Service FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
);

CREATE TABLE BillItems (
	BillItemID INT PRIMARY KEY IDENTITY(1,1),
	BillID INT NOT NULL,
	ProductID INT NOT NULL,
	Quantity INT NOT NULL,
	ProductPrice DECIMAL(10, 2) NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
	CONSTRAINT FK_BillItems_Bill FOREIGN KEY (BillID) REFERENCES Bills(BillID),
	CONSTRAINT FK_BillItems_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

GO

CREATE TRIGGER trg_DeleteBranch
ON Branches
FOR DELETE
AS
BEGIN
	DELETE FROM Users WHERE BranchID IN (SELECT BranchID FROM DELETED);
	DELETE FROM BranchSchedules WHERE BranchID IN (SELECT BranchID FROM DELETED);
	DELETE FROM ScheduleExceptions WHERE BranchID IN (SELECT BranchID FROM DELETED);
	DELETE FROM Bills WHERE BranchID IN (SELECT BranchID FROM DELETED);
	DELETE FROM Appointments WHERE BranchID IN (SELECT BranchID FROM DELETED);
END;
GO

CREATE TRIGGER trg_DeleteService
ON Services
FOR DELETE
AS
BEGIN
	DELETE FROM Appointments WHERE ServiceID IN (SELECT ServiceID FROM DELETED);
END;
GO

CREATE TRIGGER trg_DeleteCategory
ON Categories
FOR DELETE
AS
BEGIN
	DELETE FROM Products WHERE CategoryID IN (SELECT CategoryID FROM DELETED);
END;
GO

CREATE TRIGGER trg_DeleteUser
ON Users
FOR DELETE
AS
BEGIN
	DELETE FROM Bills WHERE ClientID IN (SELECT UserID FROM DELETED);
	DELETE FROM Appointments WHERE ClientID IN (SELECT UserID FROM DELETED);
END;
GO

CREATE TRIGGER trg_DeleteProduct
ON Products
FOR DELETE
AS
BEGIN
	DELETE FROM BillItems WHERE ProductID IN (SELECT ProductID FROM DELETED);
END;
GO

CREATE TRIGGER trg_DeleteBill
ON Bills
FOR DELETE
AS
BEGIN
	DELETE FROM Appointments WHERE BillID IN (SELECT BillID FROM DELETED);
	DELETE FROM BillItems WHERE BillID IN (SELECT BillID FROM DELETED);
END;
GO