USE MecaAgenda;
GO

-- Insert data into Branches table
INSERT INTO Branches (Name, Description, Phone, Address, Email) VALUES
('Central Branch', 'Main branch located downtown', '123-456-7890', '123 Central St, Cityville', 'central@mechaagenda.com'),
('North Branch', 'Branch in the northern part of the city', '123-456-7891', '456 North St, Cityville', 'north@mechaagenda.com'),
('South Branch', 'Branch in the southern part of the city', '123-456-7892', '789 South St, Cityville', 'south@mechaagenda.com'),
('East Branch', 'Branch in the eastern part of the city', '123-456-7893', '321 East St, Cityville', 'east@mechaagenda.com'),
('West Branch', 'Branch in the western part of the city', '123-456-7894', '654 West St, Cityville', 'west@mechaagenda.com'),
('Uptown Branch', 'Branch in the uptown area', '123-456-7895', '987 Uptown St, Cityville', 'uptown@mechaagenda.com'),
('Downtown Branch', 'Branch in the downtown area', '123-456-7896', '789 Downtown St, Cityville', 'downtown@mechaagenda.com'),
('Suburb Branch', 'Branch in the suburbs', '123-456-7897', '123 Suburb St, Cityville', 'suburb@mechaagenda.com');

-- Insert data into Services table
INSERT INTO Services (Name, Description, Price, EstimatedTime, ToolsRequired, MaterialsNeeded) VALUES
('Oil Change', 'Basic oil change service', 29.99, 30, 'Oil filter wrench, Funnel', 'Engine oil, Oil filter'),
('Tire Rotation', 'Rotation of tires for even wear', 25.99, 40, 'Torque wrench, Jack', 'N/A'),
('Brake Inspection', 'Inspection of brake system', 19.99, 45, 'Lug wrench, Jack', 'N/A'),
('Battery Replacement', 'Replacement of car battery', 49.99, 90, '', ''),
('Transmission Service', 'Full transmission service', 129.99, 120, '', ''),
('Wheel Alignment', 'Adjust the angles of the wheels', 99.99, 90, '', ''),
('AC Recharge', 'Air conditioning recharge service', 69.99, 60, '', ''),
('Engine Diagnostic', 'Full engine diagnostic', 199.99, 120, '', ''),
('Detailing', 'Full car detailing service', 199.99, 240, '', ''),
('Headlight Restoration', 'Restore clarity to headlights', 39.99, 60, '', '');

-- Insert data into Categories table
INSERT INTO Categories (Name) VALUES
('Engine Oil'),
('Tires'),
('Brakes'),
('Battery'),
('Transmission'),
('Alignment'),
('AC Services'),
('Diagnostics'),
('Cleaning'),
('Restoration');

-- Insert data into Users table
INSERT INTO Users (Name, Phone, Email, Address, BirthDate, PasswordHash, Role, BranchID) VALUES
('John Doe', '321-654-0987', 'john.doe@example.com', '456 Elm St, Cityville', '1985-07-15', 'passwordhash1', 'Client', NULL),
('Jane Smith', '321-654-0988', 'jane.smith@example.com', '789 Pine St, Cityville', '1990-11-25', 'passwordhash2', 'Manager', 1),
('Alice Johnson', '321-654-0989', 'alice.johnson@example.com', '123 Oak St, Cityville', '1980-03-10', 'passwordhash3', 'Admin', 2),
('Alice Jones', '', 'alice.jones@example.com', '', '', 'securepass1', 'Admin', 3),
('Bob Smith', '', 'bob.smith@example.com', '', '', 'securepass2', 'Manager', 4),
('Carol Doe', '', 'carol.doe@example.com', '', '', 'securepass3', 'client', NULL),
('Dave Wilson', '', 'dave.wilson@example.com', '', '', 'securepass4', 'client', NULL),
('Eve Taylor', '', 'eve.taylor@example.com', '', '', 'securepass5', 'client', NULL);

-- Insert data into Products table
INSERT INTO Products (Name, Description, CategoryID, Price, Brand, StockQuantity) VALUES
('Engine Oil', '', 1, 39.99, '', 50),
('Tire', '', 2, 59.99, '', 20),
('Brake Pads', '', 3, 79.99, '', 30),
('Car Battery', '', 4, 129.99, '', 15),
('Transmission Fluid', '', 5, 24.99, '', 40),
('Wheel Alignment Kit', '', 6, 34.99, '', 10),
('AC Refrigerant', '', 7, 9.99, '', 25),
('Diagnostic Tool', '', 8, 199.99, '', 5),
('Car Wash Soap', '', 9, 19.99, '', 100),
('Headlight Restoration Kit', '', 10, 59.99, '', 20);

-- Insert data into BranchSchedules table
INSERT INTO BranchSchedules (BranchID, DayOfWeek, OpenTime, CloseTime) VALUES
(1, 1, '08:00', '17:00'), (1, 2, '08:00', '17:00'), (1, 3, '08:00', '17:00'), (1, 4, '08:00', '17:00'), (1, 5, '08:00', '17:00'),
(2, 1, '08:00', '17:00'), (2, 2, '08:00', '17:00'), (2, 3, '08:00', '17:00'), (2, 4, '08:00', '17:00'), (2, 5, '08:00', '17:00'),
(3, 1, '08:00', '17:00'), (3, 2, '08:00', '17:00'), (3, 3, '08:00', '17:00'), (3, 4, '08:00', '17:00'), (3, 5, '08:00', '17:00'),
(4, 1, '08:00', '17:00'), (4, 2, '08:00', '17:00'), (4, 3, '08:00', '17:00'), (4, 4, '08:00', '17:00'), (4, 5, '08:00', '17:00'),
(5, 1, '08:00', '17:00'), (5, 2, '08:00', '17:00'), (5, 3, '08:00', '17:00'), (5, 4, '08:00', '17:00'), (5, 5, '08:00', '17:00'),
(6, 1, '08:00', '17:00'), (6, 2, '08:00', '17:00'), (6, 3, '08:00', '17:00'), (6, 4, '08:00', '17:00'), (6, 5, '08:00', '17:00'),
(7, 1, '08:00', '17:00'), (7, 2, '08:00', '17:00'), (7, 3, '08:00', '17:00'), (7, 4, '08:00', '17:00'), (7, 5, '08:00', '17:00'),
(8, 1, '08:00', '17:00'), (8, 2, '08:00', '17:00'), (8, 3, '08:00', '17:00'), (8, 4, '08:00', '17:00'), (8, 5, '08:00', '17:00');

-- Insert data into ScheduleExceptions table
INSERT INTO ScheduleExceptions (BranchID, Date, StartTime, EndTime, ServicesAffected) VALUES
(1, '2024-12-25', '00:00', '23:59', '1,2,3'),
(2, '2024-01-01', '00:00', '23:59', '1,3'),
(3, '2024-07-04', '00:00', '23:59', '2');

-- Insert data into Appointments table
INSERT INTO Appointments (ClientID, BranchID, ServiceID, Date, StartTime, EndTime, Status, Price, PaymentMethod, Paid) VALUES
(1, 1, 1,'2024-06-20', '10:00', '10:30', 'Scheduled', 29.99, 'Credit Card', 1),
(1, 1, 2,'2024-06-20', '11:00', '11:45', 'Scheduled', 19.99, 'Cash', 0),
(2, 2, 3,'2024-06-20', '09:00', '09:40', 'Completed', 25.99, 'Credit Card', 1),
(3, 3, 1, '2024-07-01', '10:00', '10:30', 'Scheduled', 29.99, 'Credit Card', 1),
(3, 3, 2, '2024-07-01', '11:00', '11:45', 'Scheduled', 19.99, 'Cash', 0),
(4, 4, 3, '2024-07-02', '09:00', '09:40', 'Completed', 25.99, 'Credit Card', 1),
(4, 4, 4, '2024-07-02', '10:00', '11:30', 'Completed', 49.99, 'Cash', 1),
(5, 5, 5, '2024-07-03', '14:00', '16:00', 'Scheduled', 59.99, 'Credit Card', 0),
(5, 5, 6, '2024-07-03', '16:30', '19:30', 'Scheduled', 129.99, 'Credit Card', 0),
(6, 6, 7, '2024-07-04', '09:00', '10:30', 'Completed', 99.99, 'Credit Card', 1),
(6, 6, 8, '2024-07-04', '11:00', '12:00', 'Completed', 69.99, 'Cash', 1),
(7, 7, 9, '2024-07-05', '13:00', '17:00', 'Scheduled', 199.99, 'Credit Card', 0),
(7, 7, 10, '2024-07-05', '18:00', '19:00', 'Scheduled', 39.99, 'Cash', 0);

-- Insert data into Bills table
INSERT INTO Bills (ClientID, BranchID, Date, TotalAmount, PaymentMethod, Paid) VALUES
(1, 1, '2024-06-20', 29.99, 'Credit Card', 1),
(1, 1, '2024-06-21', 19.99, 'Cash', 0),
(2, 2, '2024-06-22', 25.99, 'Credit Card', 1),
(3, 3, '2024-07-01', 49.98, 'Credit Card', 1),
(3, 3, '2024-07-02', 75.99, 'Cash', 1),
(4, 4, '2024-07-02', 79.98, 'Credit Card', 1),
(4, 4, '2024-07-03', 129.99, 'Cash', 1),
(5, 5, '2024-07-03', 189.98, 'Credit Card', 0),
(5, 5, '2024-07-04', 249.99, 'Credit Card', 0),
(6, 6, '2024-07-04', 99.99, 'Credit Card', 1),
(6, 6, '2024-07-05', 69.99, 'Cash', 1),
(7, 7, '2024-07-05', 239.98, 'Credit Card', 0),
(7, 7, '2024-07-06', 39.99, 'Cash', 0);

-- Insert data into BillItems table
INSERT INTO BillItems (BillID, ProductID, Quantity, ProductPrice, Price) VALUES
(1, 1, 1, 39.99, 39.99),
(2, 2, 2, 59.99, 119.98),
(3, 3, 4, 79.99, 319.96),
(4, 1, 2, 39.99, 79.98),
(5, 2, 1, 59.99, 59.99),
(6, 3, 2, 79.99, 159.98),
(7, 4, 3, 14.99, 44.97),
(8, 5, 1, 24.99, 24.99),
(9, 6, 4, 34.99, 139.96),
(10, 7, 1, 9.99, 9.99),
(11, 8, 2, 39.99, 79.98),
(12, 9, 3, 19.99, 59.97),
(13, 10, 1, 59.99, 59.99);

GO