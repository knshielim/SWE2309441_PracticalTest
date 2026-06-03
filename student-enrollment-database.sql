-- Create Database
CREATE DATABASE StudentEnrollmentDB;
GO

USE StudentEnrollmentDB;
GO

-- Create Students Table
CREATE TABLE Students
(
Id INT IDENTITY(1,1) PRIMARY KEY,
StudentName NVARCHAR(100) NOT NULL,
Programme NVARCHAR(100) NOT NULL,
EnrollmentStatus NVARCHAR(50) NOT NULL
);
GO

-- Seed Sample Data
INSERT INTO Students (StudentName, Programme, EnrollmentStatus)
VALUES
('John Tan', 'Software Engineering', 'Active'),
('Nur Aisyah', 'Data Science', 'Pending'),
('Lim Wei Jian', 'Information Systems', 'Active');
GO

-- Verify Data
SELECT * FROM Students;
GO
