CREATE DATABASE EmploeesDb;
USE EmploeesDb;

---Automatic creates
CREATE TABLE Depts (
    DeptId INT IDENTITY(1,1) PRIMARY KEY,
    Dname NVARCHAR(100),
    Location NVARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    Ename NVARCHAR(100),
    Job NVARCHAR(100),
    Salary FLOAT,
    DeptId INT,
    CONSTRAINT FK_Employees_Depts
        FOREIGN KEY (DeptId) REFERENCES Depts(DeptId)
);
-------------------------------------

INSERT INTO Depts (Dname, Location)
VALUES ('HR', 'Hyderabad'),
       ('IT', 'Bangalore');


INSERT INTO Employees (Ename, Job, Salary, DeptId)
VALUES ('sahithi', 'Manager', 50000, 1),
       ('Shetti', 'Developer', 40000, 2);




---------------------------
-- Create Database
CREATE DATABASE StudentCourseDb;
GO

-- Use Database
USE StudentCourseDb;
GO

-- Insert Courses
INSERT INTO Courses (CourseName)
VALUES 
('CSE'),
('ECE'),
('EEE');

-- Insert Students
INSERT INTO Students (StudentName, CourseId)
VALUES 
('Sahithi', 1),
('Ravi', 2),
('Anil', 1),
('Priya', 3);

DROP DATABASE StudentCourseDb;

