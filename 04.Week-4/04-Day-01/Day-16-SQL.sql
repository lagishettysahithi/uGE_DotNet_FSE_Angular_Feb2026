--Day-16

CREATE DATABASE RetailReportDB;


USE RetailReportDB;


CREATE TABLE store_report (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50),
    city VARCHAR(50)
);

CREATE TABLE product_report (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    price DECIMAL(10,2)
);

CREATE TABLE orders_report (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES store_report(store_id)
);

CREATE TABLE order_items_report (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES orders_report(order_id),
    FOREIGN KEY (product_id) REFERENCES product_report(product_id)
);

-- Stores
INSERT INTO store_report VALUES
(11,'Chennai Store','Chennai'),
(12,'Bangalore Store','Bangalore'),
(13,'Delhi Store','Delhi');

-- Products
INSERT INTO product_report VALUES
(201,'Tablet',30000),
(202,'Smart Watch',8000),
(203,'Bluetooth Speaker',3500),
(204,'Gaming Mouse',1200),
(205,'USB Keyboard',900);

-- Orders
INSERT INTO orders_report VALUES
(21,11,'2024-04-05'),
(22,12,'2024-04-08'),
(23,13,'2024-04-10'),
(24,11,'2024-04-12'),
(25,12,'2024-04-15');

-- Order Items
INSERT INTO order_items_report VALUES
(31,21,201,1,2000),
(32,21,204,2,100),
(33,22,202,1,500),
(34,23,203,3,200),
(35,24,205,2,50),
(36,25,202,1,300);



   --- SCALAR FUNCTION
  --- Calculate Final Price After Discount

CREATE FUNCTION fn_FinalPrice
(
    @price DECIMAL(10,2),
    @discount DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN

IF @discount IS NULL
SET @discount = 0

RETURN (@price - @discount)

END
GO



   --STORED PROCEDURE
   --Total Sales Per Store

CREATE PROCEDURE sp_TotalSalesStore
AS
BEGIN

SELECT 
s.store_name,
SUM((p.price * oi.quantity) - oi.discount) AS total_sales

FROM store_report s
JOIN orders_report o
ON s.store_id = o.store_id

JOIN order_items_report oi
ON o.order_id = oi.order_id

JOIN product_report p
ON oi.product_id = p.product_id

GROUP BY s.store_name

END
GO



 --  STORED PROCEDURE
   --Orders By Date Range

CREATE PROCEDURE sp_OrdersByDate
(
@start_date DATE,
@end_date DATE
)
AS
BEGIN

SELECT 
o.order_id,
s.store_name,
o.order_date

FROM orders_report o
JOIN store_report s
ON o.store_id = s.store_id

WHERE o.order_date 
BETWEEN @start_date AND @end_date

END
GO



  -- TABLE VALUED FUNCTION
   --Top 5 Selling Products

CREATE FUNCTION fn_TopProducts()
RETURNS TABLE
AS
RETURN
(
SELECT TOP 5
p.product_name,
SUM(oi.quantity) AS total_sold

FROM product_report p
JOIN order_items_report oi
ON p.product_id = oi.product_id

GROUP BY p.product_name
ORDER BY total_sold DESC
);
GO



   -- EXECUTE STORED PROCEDURES

EXEC sp_TotalSalesStore;

EXEC sp_OrdersByDate 
'2024-04-01','2024-04-20';



   -- USING SCALAR FUNCTION

SELECT 
product_name,
dbo.fn_FinalPrice(price,1000) AS price_after_discount
FROM product_report;



   -- USING TABLE FUNCTION

SELECT * 
FROM fn_TopProducts();





--------------------------------------------------

--Problem-2

CREATE TABLE stocks_report
(
    product_id INT PRIMARY KEY,
    stock_quantity INT,
    FOREIGN KEY (product_id) REFERENCES product_report(product_id)
);


INSERT INTO stocks_report VALUES
(201,50),
(202,40),
(203,60),
(204,30),
(205,25);



   --CREATE AFTER INSERT TRIGGER

CREATE TRIGGER trg_AutoUpdateStock
ON order_items_report
AFTER INSERT
AS
BEGIN

BEGIN TRY

    -- Reduce stock when new order item inserted
    UPDATE s
    SET s.stock_quantity = s.stock_quantity - i.quantity
    FROM stocks_report s
    JOIN inserted i
    ON s.product_id = i.product_id;


    -- Check if stock becomes negative
    IF EXISTS
    (
        SELECT * 
        FROM stocks_report
        WHERE stock_quantity < 0
    )
    BEGIN

        ROLLBACK;

        THROW 50001, 'Insufficient stock. Order cannot be completed.', 1;

    END

END TRY


BEGIN CATCH

    DECLARE @msg NVARCHAR(4000)

    SET @msg = ERROR_MESSAGE()

    RAISERROR(@msg,16,1)

END CATCH

END
GO



  --  TEST THE TRIGGER

-- Valid order (stock will decrease)
INSERT INTO order_items_report
VALUES (40,21,201,2,100);


-- Invalid order (stock insufficient)
INSERT INTO order_items_report
VALUES (41,22,205,100,50);



  --  CHECK STOCK

SELECT * FROM stocks_report;

--------------------------------------------
--problem-3


/* =========================================
   1. ADD NEW COLUMNS TO EXISTING TABLE
   ========================================= */

ALTER TABLE orders_report
ADD order_status INT,
    shipped_date DATE;



/* =========================================
   2. CREATE AFTER UPDATE TRIGGER
   ========================================= */

CREATE TRIGGER trg_OrderStatusValidation
ON orders_report
AFTER UPDATE
AS
BEGIN

BEGIN TRY

    -- Check if status is updated to Completed (4)
    -- but shipped_date is NULL
    IF EXISTS
    (
        SELECT *
        FROM inserted
        WHERE order_status = 4
        AND shipped_date IS NULL
    )

    BEGIN

        ROLLBACK;

        THROW 50002,
        'Order cannot be marked as Completed without shipped date.',
        1;

    END

END TRY


BEGIN CATCH

    DECLARE @msg NVARCHAR(4000)

    SET @msg = ERROR_MESSAGE()

    RAISERROR(@msg,16,1)

END CATCH

END
GO



/* =========================================
   3. TEST THE TRIGGER
   ========================================= */

-- Invalid update (should fail)
UPDATE orders_report
SET order_status = 4
WHERE order_id = 21;



-- Valid update (should work)
UPDATE orders_report
SET order_status = 4,
    shipped_date = '2024-04-06'
WHERE order_id = 21;



   --CHECK RESULT

SELECT * FROM orders_report;
--------------------------------------------
--problem-4

BEGIN TRY

BEGIN TRANSACTION


/* =========================================
   1. TEMP TABLE TO STORE REVENUE
   ========================================= */

CREATE TABLE #OrderRevenue
(
    order_id INT,
    store_id INT,
    revenue DECIMAL(12,2)
);


/* =========================================
   2. DECLARE VARIABLES
   ========================================= */

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)


/* =========================================
   3. DECLARE CURSOR
   ========================================= */

DECLARE order_cursor CURSOR FOR

SELECT order_id, store_id
FROM orders_report
WHERE order_status = 4


/* =========================================
   4. OPEN CURSOR
   ========================================= */

OPEN order_cursor


/* =========================================
   5. FETCH FIRST RECORD
   ========================================= */

FETCH NEXT FROM order_cursor
INTO @order_id, @store_id


/* =========================================
   6. LOOP THROUGH ORDERS
   ========================================= */

WHILE @@FETCH_STATUS = 0
BEGIN

    /* Calculate revenue for each order */

    SELECT @revenue =
    SUM((p.price * oi.quantity) - oi.discount)

    FROM order_items_report oi
    JOIN product_report p
    ON oi.product_id = p.product_id

    WHERE oi.order_id = @order_id


    /* Insert revenue into temp table */

    INSERT INTO #OrderRevenue
    VALUES (@order_id, @store_id, @revenue)


    /* Fetch next record */

    FETCH NEXT FROM order_cursor
    INTO @order_id, @store_id

END


/* =========================================
   7. CLOSE AND DEALLOCATE CURSOR
   ========================================= */

CLOSE order_cursor
DEALLOCATE order_cursor


/* =========================================
   8. DISPLAY STORE WISE REVENUE
   ========================================= */

SELECT
s.store_name,
SUM(r.revenue) AS total_store_revenue

FROM #OrderRevenue r
JOIN store_report s
ON r.store_id = s.store_id

GROUP BY s.store_name


COMMIT TRANSACTION

END TRY



BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Error occurred during revenue calculation.'

END CATCH

