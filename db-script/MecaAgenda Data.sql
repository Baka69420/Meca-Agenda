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
('Tire Rotation', 'Rotation of tires for even wear', 25.99, 40, 'Torque wrench, Jack', 'N/A'),
('Brake Inspection', 'Inspection of brake system', 19.99, 45, 'Lug wrench, Jack', 'N/A');

-- Insert data into Categories table
INSERT INTO Categories (Name) VALUES
('Engine Oil'),
('Tires'),
('Brakes');

-- Insert data into Users table
INSERT INTO Users (BranchID, Name, Phone, Email, Address, BirthDate, PasswordHash, Role) VALUES
(1, 'John Doe', '321-654-0001', 'john.doe@example.com', '123 Address 1', '1985-07-15', 'pass', 'Admin'),
(2, 'Jane Smith', '321-654-0002', 'jane.smith@example.com', '123 Address 2', '1990-11-25', 'pass', 'Admin'),
(3, 'Alice Johnson', '321-654-0003', 'alice.johnson@example.com', '123 Address 3', '1980-03-10', 'pass', 'Admin'),
(1, 'Alice Jones', '321-654-0004', 'alice.jones@example.com', '123 Address 4', '1983-02-15', 'pass', 'Manager'),
(2, 'Bob Smith', '321-654-0005', 'bob.smith@example.com', '123 Address 5', '1976-06-21', 'pass', 'Manager'),
(3, 'Carol Doe', '321-654-0006', 'carol.doe@example.com', '123 Address 6', '1964-10-03', 'pass', 'Manager'),
(NULL, 'Dave Wilson', '321-654-0007', 'dave.wilson@example.com', '123 Address 7', '1997-09-30', 'pass', 'client'),
(NULL, 'Eve Taylor', '321-654-0008', 'eve.taylor@example.com', '123 Address 8', '1999-07-14', 'pass', 'client'),
(NULL, 'Juan Perez', '321-654-0009', 'juan.perez@example.com', '123 Address 9', '1989-09-10', 'pass', 'client');

-- Insert data into Products table
INSERT INTO Products (CategoryID, Name, Description, Price, Brand, StockQuantity) VALUES
(1, '5w30 Oil', 'Engine Oil with 5w30 viscocity', 39.99, 'Valvoline', 50),
(1, '10w40 Oil', 'Engine Oil with 10w40 viscocity', 39.99, 'Valvoline', 40),
(1, '20w50 Oil', 'Engine Oil with 20w50 viscocity', 39.99, 'Valvoline', 30),
(2, '195/65R15 Tire', 'Commonly found on compact and mid-sized sedans', 79.99, 'Bridgestone', 23),
(2, '205/55R16 Tire', 'Popular on many compact and mid-sized cars', 89.99, 'Bridgestone', 43),
(2, '225/45R17 Tire', 'Often used on sportier sedans and coupes', 119.99, 'Bridgestone', 8),
(3, 'Ceramic Brake Pads', 'Known for their durability, quiet operation, and low dust production', 59.99, 'Bosch', 52),
(3, 'Semi-Metallic Brake Pads', 'Excellent braking performance and heat dissipation, ideal for high-performance and heavy-duty applications', 29.99, 'KMX Friction', 37),
(3, 'Organic Brake Pads (NAO)', 'Organic brake pads are quieter and produce less dust than semi-metallic pads, but they tend to wear faster and may not perform as well under extreme conditions', 19.99, 'Bosch', 28);

-- Insert data into BranchSchedules table
INSERT INTO BranchSchedules (BranchID, DayOfWeek, OpenTime, CloseTime) VALUES
(1, 1, '08:00', '17:00'), (1, 2, '08:00', '17:00'), (1, 3, '08:00', '17:00'), (1, 4, '08:00', '17:00'), (1, 5, '08:00', '17:00'),
(2, 1, '08:00', '17:00'), (2, 2, '08:00', '17:00'), (2, 3, '08:00', '17:00'), (2, 4, '08:00', '17:00'), (2, 5, '08:00', '17:00'),
(3, 1, '08:00', '17:00'), (3, 2, '08:00', '17:00'), (3, 3, '08:00', '17:00'), (3, 4, '08:00', '17:00'), (3, 5, '08:00', '17:00');

-- Insert data into ScheduleExceptions table
INSERT INTO ScheduleExceptions (BranchID, Date, StartTime, EndTime, ServicesAffected) VALUES
(1, '2024-12-25', '00:00', '23:59', '1,2,3'), (1, '2024-01-01', '00:00', '23:59', '1,3'), (1, '2024-07-04', '00:00', '23:59', '2'),
(2, '2024-12-25', '00:00', '23:59', '1,2,3'), (2, '2024-01-01', '00:00', '23:59', '1,3'), (2, '2024-07-04', '00:00', '23:59', '2'),
(3, '2024-12-25', '00:00', '23:59', '1,2,3'), (3, '2024-01-01', '00:00', '23:59', '1,3'), (3, '2024-07-04', '00:00', '23:59', '2');

-- Insert data into Bills table
INSERT INTO Bills (ClientID, BranchID, Date, TotalAmount, PaymentMethod, Paid) VALUES
(7, 1, '2024-06-20', 149.96, 'Credit Card', 1),
(8, 1, '2024-06-21', 25.99, 'Cash', 1),
(9, 1, '2024-06-22', 79.98, 'Credit Card', 1),
(7, 2, '2024-07-01', 149.96, 'Credit Card', 1),
(8, 2, '2024-07-02', 25.99, 'Cash', 1),
(9, 2, '2024-07-02', 49.98, 'Credit Card', 1),
(7, 3, '2024-07-03', 149.96, 'Cash', 1),
(8, 3, '2024-07-03', 25.99, 'Credit Card', 1),
(9, 3, '2024-07-04', 39.98, 'Credit Card', 1),
(7, 1, '2024-07-12', 89.99, 'Cash', 1),
(8, 2, '2024-07-13', 79.98, 'Cash', 1),
(9, 3, '2024-07-14', 479.96, 'Credit Card', 1);

-- Insert data into Appointments table
INSERT INTO Appointments (BillID, ClientID, BranchID, ServiceID, Date, StartTime, EndTime, Status, Price) VALUES
(1, 7, 1, 1, '2024-06-20', '10:00', '10:30', 'Completed', 29.99),
(2, 8, 1, 2, '2024-06-21', '11:00', '11:45', 'Completed', 25.99),
(3, 9, 1, 3, '2024-06-22', '09:00', '09:40', 'Completed', 19.99),
(4, 7, 2, 1, '2024-07-01', '10:00', '10:30', 'Completed', 29.99),
(5, 8, 2, 2, '2024-07-02', '11:00', '11:45', 'Completed', 25.99),
(6, 9, 2, 3, '2024-07-02', '09:00', '09:40', 'Completed', 19.99),
(7, 7, 3, 1, '2024-07-03', '10:00', '11:30', 'Completed', 29.99),
(8, 8, 3, 2, '2024-07-03', '14:00', '16:00', 'Completed', 25.99),
(9, 9, 3, 3, '2024-07-04', '16:30', '19:30', 'Completed', 19.99),
(NULL, 7, 1, 1, '2024-08-14', '10:00', '11:30', 'Scheduled', 29.99),
(NULL, 8, 2, 2, '2024-08-15', '14:00', '16:00', 'Scheduled', 25.99),
(NULL, 9, 3, 3, '2024-08-16', '16:30', '19:30', 'Scheduled', 19.99);

-- Insert data into BillItems table
INSERT INTO BillItems (BillID, ProductID, Quantity, ProductPrice, Price) VALUES
(1, 1, 3, 39.99, 119.97),
(3, 7, 1, 59.99, 59.99),
(4, 2, 3, 39.99, 119.97),
(6, 8, 1, 29.99, 29.99),
(7, 3, 3, 39.99, 119.97),
(9, 9, 1, 19.99, 19.99),
(10, 7, 1, 89.99, 89.99),
(11, 2, 2, 39.99, 79.98),
(12, 6, 4, 119.99, 479.96);

GO