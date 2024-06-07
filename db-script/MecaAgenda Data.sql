USE MecaAgenda;
GO

-- Insert data into Branches table
INSERT INTO Branches (Name, Description, Phone, Address, Email) VALUES
('Central Branch', 'Main branch located downtown', '123-456-7890', '123 Central St, Cityville', 'central@mechaagenda.com'),
('North Branch', 'Branch in the northern part of the city', '123-456-7891', '456 North St, Cityville', 'north@mechaagenda.com'),
('South Branch', 'Branch in the southern part of the city', '123-456-7892', '789 South St, Cityville', 'south@mechaagenda.com');

-- Insert data into Services table
INSERT INTO Services (Name, Description, Price, EstimatedTime, ToolsRequired, MaterialsNeeded) VALUES
('Oil Change', 'Basic oil change service', 29.99, 30, 'Oil filter wrench, Funnel', 'Engine oil, Oil filter'),
('Brake Inspection', 'Inspection of brake system', 19.99, 45, 'Lug wrench, Jack', 'N/A'),
('Tire Rotation', 'Rotation of tires for even wear', 25.99, 40, 'Torque wrench, Jack', 'N/A');

-- Insert data into Categories table
INSERT INTO Categories (Name) VALUES
('Engine Parts'),
('Brake Parts'),
('Tires');

-- Insert data into Users table
INSERT INTO Users (Name, Phone, Email, Address, BirthDate, PasswordHash, Role, BranchID) VALUES
('John Doe', '321-654-0987', 'john.doe@example.com', '456 Elm St, Cityville', '1985-07-15', 'passwordhash1', 'Client', NULL),
('Jane Smith', '321-654-0988', 'jane.smith@example.com', '789 Pine St, Cityville', '1990-11-25', 'passwordhash2', 'Manager', 1),
('Alice Johnson', '321-654-0989', 'alice.johnson@example.com', '123 Oak St, Cityville', '1980-03-10', 'passwordhash3', 'Admin', 2);

-- Insert data into Products table
INSERT INTO Products (Name, Description, CategoryID, Price, Brand, StockQuantity) VALUES
('Engine Oil', 'Synthetic engine oil', 1, 39.99, 'BrandA', 50),
('Brake Pads', 'High-performance brake pads', 2, 59.99, 'BrandB', 30),
('All-Season Tires', 'Durable all-season tires', 3, 79.99, 'BrandC', 20);

-- Insert data into BranchSchedules table
INSERT INTO BranchSchedules (BranchID, DayOfWeek, OpenTime, CloseTime) VALUES
(1, 1, '08:00', '17:00'),
(1, 2, '08:00', '17:00'),
(1, 3, '08:00', '17:00');

-- Insert data into ScheduleExceptions table
INSERT INTO ScheduleExceptions (BranchID, Date, StartTime, EndTime, ServicesAffected) VALUES
(1, '2024-12-25', '00:00', '23:59', '1,2,3'),
(2, '2024-01-01', '00:00', '23:59', '1,3'),
(3, '2024-07-04', '00:00', '23:59', '2');

-- Insert data into Appointments table
INSERT INTO Appointments (ClientID, BranchID, ServiceID, Date, StartTime, EndTime, Status, Price, PaymentMethod, Paid) VALUES
(1, 1, 1,'2024-06-20', '10:00', '10:30', 'Scheduled', 29.99, 'Credit Card', 1),
(1, 1, 2,'2024-06-20', '11:00', '11:45', 'Scheduled', 19.99, 'Cash', 0),
(2, 2, 3,'2024-06-20', '09:00', '09:40', 'Completed', 25.99, 'Credit Card', 1);

-- Insert data into Bills table
INSERT INTO Bills (ClientID, BranchID, Date, TotalAmount, PaymentMethod, Paid) VALUES
(1, 1, '2024-06-20', 29.99, 'Credit Card', 1),
(1, 1, '2024-06-21', 19.99, 'Cash', 0),
(2, 2, '2024-06-22', 25.99, 'Credit Card', 1);

-- Insert data into BillItems table
INSERT INTO BillItems (BillID, ProductID, Quantity, ProductPrice, Price) VALUES
(1, 1, 1, 39.99, 39.99),
(2, 2, 2, 59.99, 119.98),
(3, 3, 4, 79.99, 319.96);

GO