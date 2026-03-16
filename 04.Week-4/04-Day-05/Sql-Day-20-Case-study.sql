-- =============================================
-- BOOKMART ONLINE BOOKSTORE CASE STUDY
-- =============================================

-- Drop tables if they already exist (for testing)
IF OBJECT_ID('Orders', 'U') IS NOT NULL
DROP TABLE Orders;

IF OBJECT_ID('Books', 'U') IS NOT NULL
DROP TABLE Books;

-- =============================================
-- Create Tables
-- =============================================

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0),
    Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    OrderDate DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- =============================================
-- Task 1 : Stored Procedure to Add New Book
-- =============================================

IF OBJECT_ID('sp_AddNewBook', 'P') IS NOT NULL
DROP PROCEDURE sp_AddNewBook;

GO

CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY

        INSERT INTO Books (Title, Stock, Price)
        VALUES (@Title, @Stock, @Price);

        PRINT 'Book added successfully.';

    END TRY

    BEGIN CATCH

        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE();

    END CATCH
END;

GO

-- =============================================
-- Task 2 : Stored Procedure to Place Order
-- =============================================

IF OBJECT_ID('sp_PlaceOrder', 'P') IS NOT NULL
DROP PROCEDURE sp_PlaceOrder;

GO

CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN

    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        -- Check book existence and stock
        IF NOT EXISTS (
            SELECT 1 FROM Books
            WHERE BookID = @BookID
            AND Stock >= @Quantity
        )
        BEGIN
            RAISERROR('Not enough stock or book not found.',16,1);
        END

        -- Reduce stock
        UPDATE Books
        SET Stock = Stock - @Quantity
        WHERE BookID = @BookID;

        -- Insert order
        INSERT INTO Orders (BookID, Quantity)
        VALUES (@BookID, @Quantity);

        COMMIT TRANSACTION;

        PRINT 'Order placed successfully.';

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE();

    END CATCH

END;

GO

-- =============================================
-- Task 3 : Insert Sample Books
-- =============================================

EXEC sp_AddNewBook 'SQL Server Basics', 10, 500;
EXEC sp_AddNewBook 'C# Programming', 5, 650;
EXEC sp_AddNewBook 'Data Structures', 8, 700;
EXEC sp_AddNewBook 'Web Development', 3, 550;

-- View Books
SELECT * FROM Books;

-- =============================================
-- TEST CASE 1 : Successful Order
-- =============================================

EXEC sp_PlaceOrder 1,2;

SELECT * FROM Books;
SELECT * FROM Orders;

-- =============================================
-- TEST CASE 2 : Insufficient Stock
-- =============================================

EXEC sp_PlaceOrder 4,10;

SELECT * FROM Books;
SELECT * FROM Orders;

-- =============================================
-- TEST CASE 3 : Invalid BookID
-- =============================================

EXEC sp_PlaceOrder 99,1;

SELECT * FROM Books;
SELECT * FROM Orders;

-- =============================================
-- END OF CASE STUDY
-- =============================================