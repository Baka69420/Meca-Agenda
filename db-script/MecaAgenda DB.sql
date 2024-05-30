USE master;
GO

CREATE DATABASE MecaAgenda ON
(NAME = MecaAgenda_dat,
    FILENAME = 'C:\db\MecaAgenda\mecaagendadat.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5)
LOG ON
(NAME = MecaAgenda_log,
    FILENAME = 'C:\db\MecaAgenda\mecaagendalog.ldf',
    SIZE = 5 MB,
    MAXSIZE = 25 MB,
    FILEGROWTH = 5 MB);
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
    CONSTRAINT FK_Users_BranchID FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
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

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    CategoryID INT,
    Price DECIMAL(10, 2),
    Brand NVARCHAR(100),
    StockQuantity INT,
    CONSTRAINT FK_Products_CategoryID FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE BranchSchedules (
    ScheduleID INT PRIMARY KEY IDENTITY(1,1),
    BranchID INT,
    DayOfWeek TINYINT, -- 1 (Monday) to 7 (Sunday)
    OpenTime TIME,
    CloseTime TIME,
    CONSTRAINT FK_BranchSchedules_BranchID FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE ScheduleExceptions (
    ExceptionID INT PRIMARY KEY IDENTITY(1,1),
    BranchID INT,
    Date DATE,
    StartTime TIME,
    EndTime TIME,
    ServicesAffected NVARCHAR(255), -- List of service IDs affected
    CONSTRAINT FK_ScheduleExceptions_BranchID FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT,
    BranchID INT,
    ServiceID INT,
    AppointmentStart DATETIME,
    AppointmentEnd DATETIME,
    Status NVARCHAR(50),
    CONSTRAINT FK_Appointments_ClientID FOREIGN KEY (ClientID) REFERENCES Users(UserID),
    CONSTRAINT FK_Appointments_BranchID FOREIGN KEY (BranchID) REFERENCES Branches(BranchID),
    CONSTRAINT FK_Appointments_ServiceID FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
);

CREATE TABLE Bills (
    BillID INT PRIMARY KEY IDENTITY(1,1),
    AppointmentID INT,
    Date DATE,
    TotalAmount DECIMAL(10, 2),
    PaidAmount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    CONSTRAINT FK_Bills_AppointmentID FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID)
);

CREATE TABLE BillItems (
    BillItemID INT PRIMARY KEY IDENTITY(1,1),
    BillID INT,
    ItemType NVARCHAR(50) CHECK (ItemType IN ('Service', 'Product')),
    ItemID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    CONSTRAINT FK_BillItems_BillID FOREIGN KEY (BillID) REFERENCES Bills(BillID)
);
GO