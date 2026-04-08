CREATE DATABASE ContactDb;
GO

USE ContactDb;

CREATE TABLE Company (
    CompanyId INT IDENTITY PRIMARY KEY,
    CompanyName NVARCHAR(100)
);

CREATE TABLE Department (
    DepartmentId INT IDENTITY PRIMARY KEY,
    DepartmentName NVARCHAR(100)
);

CREATE TABLE ContactInfo (
    ContactId INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    EmailId NVARCHAR(100),
    MobileNo BIGINT,
    Designation NVARCHAR(50),
    CompanyId INT,
    DepartmentId INT,
    FOREIGN KEY (CompanyId) REFERENCES Company(CompanyId),
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);

INSERT INTO Company VALUES ('CTS'), ('Infosys');
INSERT INTO Department VALUES ('HR'), ('IT');
----------------------------------

CREATE DATABASE CollegeDb;
GO
USE CollegeDb;

CREATE TABLE Course (
    CourseId INT IDENTITY PRIMARY KEY,
    CourseName NVARCHAR(100)
);

CREATE TABLE Student (
    StudentId INT IDENTITY PRIMARY KEY,
    StudentName NVARCHAR(100),
    CourseId INT,
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

INSERT INTO Course VALUES ('CSE'), ('ECE'), ('MECH');

INSERT INTO Student VALUES ('Sahithi',1), ('Anita',1), ('Sai',2);