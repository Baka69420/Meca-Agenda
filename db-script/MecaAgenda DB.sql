USE master;
GO

CREATE DATABASE MecaAgenda;
GO

USE MecaAgenda;
GO

CREATE TABLE Branches (
    BranchID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    Phone NVARCHAR(20),
    Address NVARCHAR(200),
    Email NVARCHAR(100)
);

CREATE TABLE Services (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    Price DECIMAL(10, 2),
    EstimatedTime INT, -- in minutes
    ToolsRequired NVARCHAR(255),
    MaterialsNeeded NVARCHAR(255)
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100)
);

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Phone NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE,
    Address NVARCHAR(200),
    BirthDate DATE,
    PasswordHash NVARCHAR(256),
    Role NVARCHAR(20) CHECK (Role IN ('Client', 'Manager', 'Admin')),
    BranchID INT NULL,
    CONSTRAINT FK_Users_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    CategoryID INT,
    Price DECIMAL(10, 2),
    Brand NVARCHAR(100),
    StockQuantity INT,
    CONSTRAINT FK_Products_Category FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE BranchSchedules (
    ScheduleID INT PRIMARY KEY IDENTITY(1,1),
    BranchID INT,
    DayOfWeek TINYINT, -- 1 (Monday) to 7 (Sunday)
    OpenTime TIME,
    CloseTime TIME,
    CONSTRAINT FK_BranchSchedules_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE ScheduleExceptions (
    ExceptionID INT PRIMARY KEY IDENTITY(1,1),
    BranchID INT,
    Date DATE,
    StartTime TIME,
    EndTime TIME,
    ServicesAffected NVARCHAR(255), -- List of service IDs affected
    CONSTRAINT FK_ScheduleExceptions_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT,
    BranchID INT,
    ServiceID INT,
    Date DATE,
    StartTime TIME,
    EndTime TIME,
    Status NVARCHAR(50),
	Price DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    Paid BIT,
    CONSTRAINT FK_Appointments_Client FOREIGN KEY (ClientID) REFERENCES Users(UserID),
    CONSTRAINT FK_Appointments_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID),
    CONSTRAINT FK_Appointments_Service FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
);

CREATE TABLE Bills (
    BillID INT PRIMARY KEY IDENTITY(1,1),
	ClientID INT,
    BranchID INT,
    Date DATE,
    TotalAmount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    Paid BIT,
    CONSTRAINT FK_Bills_Client FOREIGN KEY (ClientID) REFERENCES Users(UserID),
    CONSTRAINT FK_Bills_Branch FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE BillItems (
    BillItemID INT PRIMARY KEY IDENTITY(1,1),
    BillID INT,
    ProductID INT,
    Quantity INT,
    ProductPrice DECIMAL(10, 2),
    Price DECIMAL(10, 2),
    CONSTRAINT FK_BillItems_Bill FOREIGN KEY (BillID) REFERENCES Bills(BillID),
    CONSTRAINT FK_BillItems_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO