---Day-17 HAnds-on
--problem-1

CREATE DATABASE AutoSalesPractice;

USE AutoSalesPractice;



/* ---------- Create Tables ---------- */

CREATE TABLE car_products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    price DECIMAL(10,2),
    stock_qty INT
);

CREATE TABLE sales_orders
(
    order_id INT PRIMARY KEY,
    order_date DATE,
    customer_name VARCHAR(50),
    order_status INT
);

CREATE TABLE sales_order_items
(
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY(order_id) REFERENCES sales_orders(order_id),
    FOREIGN KEY(product_id) REFERENCES car_products(product_id)
);


/* ---------- Insert Sample Data ---------- */

INSERT INTO car_products VALUES
(1,'Brake Pad',1200,20),
(2,'Engine Oil',850,30),
(3,'Head Light',2500,10),
(4,'Seat Cover',1500,15);


SELECT * FROM car_products;

-----------------------------------------------------
-- PROBLEM 1 : Trigger to Reduce Stock Automatically
-----------------------------------------------------

DROP TRIGGER IF EXISTS trg_reduce_stock;

USE AutoSalesPractice;



CREATE TRIGGER trg_reduce_stock
ON sales_order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if stock is sufficient
    IF EXISTS
    (
        SELECT 1
        FROM car_products p
        JOIN inserted i
        ON p.product_id = i.product_id
        WHERE p.stock_qty < i.quantity
    )
    BEGIN
        RAISERROR('Insufficient stock available',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock
    UPDATE p
    SET p.stock_qty = p.stock_qty - i.quantity
    FROM car_products p
    JOIN inserted i
    ON p.product_id = i.product_id;

END
GO

-----------------------------------------------------
-- Transaction for Placing Order
-----------------------------------------------------

BEGIN TRY

BEGIN TRANSACTION

-- Insert order
INSERT INTO sales_orders
VALUES (201,GETDATE(),'Rahul',1)

DECLARE @order_id INT
SET @order_id = 201

-- Insert order items
INSERT INTO sales_order_items
VALUES
(11,@order_id,1,2),
(12,@order_id,2,1)

COMMIT TRANSACTION

PRINT 'Order placed successfully'

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION
    PRINT 'Transaction Failed'

END CATCH

SELECT * FROM car_products;
SELECT * FROM sales_orders;
SELECT * FROM sales_order_items;

-----------------------------------------------------
-- PROBLEM 2 : Atomic Order Cancellation with SAVEPOINT
-----------------------------------------------------

DROP PROCEDURE IF EXISTS CancelOrder;
GO

CREATE PROCEDURE CancelOrder
@order_id INT
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION

-- Savepoint
SAVE TRANSACTION BeforeStockRestore

-- Restore stock
UPDATE p
SET p.stock_qty = p.stock_qty + oi.quantity
FROM car_products p
JOIN sales_order_items oi
ON p.product_id = oi.product_id
WHERE oi.order_id = @order_id

-- Update order status
UPDATE sales_orders
SET order_status = 3
WHERE order_id = @order_id

COMMIT TRANSACTION

PRINT 'Order cancelled successfully'

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION BeforeStockRestore

    PRINT 'Error occurred. Rolling back to savepoint.'

END CATCH

END
GO

-----------------------------------------------------
-- Execute Procedure
-----------------------------------------------------

EXEC CancelOrder 201;

-----------------------------------------------------
-- Check Data
-----------------------------------------------------

SELECT * FROM car_products;
SELECT * FROM sales_orders;
SELECT * FROM sales_order_items;