/* CREATE DATABASE */
CREATE DATABASE AutoDb_1;


USE AutoDb_1;



/* CREATE CATEGORY TABLE */
CREATE TABLE categories
(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);


/* CREATE PRODUCTS TABLE */
CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);



/* INSERT CATEGORY DATA */
INSERT INTO categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes'),
(4,'Kids Bikes');



/* INSERT PRODUCT DATA */
INSERT INTO products VALUES
(1,'Trail Blazer',1,2017,1200),
(2,'Hill Master',1,2018,900),
(3,'Rock Rider',1,2019,1500),
(4,'Speed Racer',2,2017,1800),
(5,'Road King',2,2018,2200),
(6,'City Rider',2,2019,1600),
(7,'Volt Bike',3,2018,3000),
(8,'Power Ride',3,2019,3500),
(9,'Mini Rider',4,2017,400),
(10,'Kid Sprint',4,2018,450);



/* FINAL QUERY */
SELECT 
    p.product_name + ' (' + CAST(p.model_year AS VARCHAR) + ')' AS product_details,
    p.list_price,
    
    (SELECT AVG(list_price) 
     FROM products 
     WHERE category_id = p.category_id) AS category_avg_price,
     
    p.list_price -
    (SELECT AVG(list_price) 
     FROM products 
     WHERE category_id = p.category_id) AS price_difference

FROM products p

WHERE p.list_price >
(
    SELECT AVG(list_price)
    FROM products
    WHERE category_id = p.category_id
);


---------------------------------------
--problem-2

/* USE DATABASE */
USE AutoDb_1;



/* CREATE CUSTOMERS TABLE */
CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);


/* CREATE ORDERS TABLE */
CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_value DECIMAL(10,2),
    order_date DATE,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);



/* INSERT CUSTOMERS */
INSERT INTO customers VALUES
(1,'Rahul','Sharma'),
(2,'Anita','Verma'),
(3,'Vikram','Reddy'),
(4,'Priya','Singh'),
(5,'Karan','Patel');



/* INSERT ORDERS */
INSERT INTO orders VALUES
(101,1,4000,'2024-01-10'),
(102,1,7000,'2024-02-15'),
(103,2,3000,'2024-03-01'),
(104,3,6000,'2024-03-05'),
(105,3,5000,'2024-03-20');



/* FINAL QUERY */

/* CUSTOMERS WHO HAVE ORDERS */
SELECT 
    c.first_name + ' ' + c.last_name AS full_name,

    (SELECT SUM(o.order_value)
     FROM orders o
     WHERE o.customer_id = c.customer_id) AS total_order_value,

    CASE
        WHEN (SELECT SUM(o.order_value)
              FROM orders o
              WHERE o.customer_id = c.customer_id) > 10000 
             THEN 'Premium'

        WHEN (SELECT SUM(o.order_value)
              FROM orders o
              WHERE o.customer_id = c.customer_id) BETWEEN 5000 AND 10000 
             THEN 'Regular'

        ELSE 'Basic'
    END AS customer_category

FROM customers c
WHERE c.customer_id IN (SELECT customer_id FROM orders)



UNION



/* CUSTOMERS WITH NO ORDERS */
SELECT
    c.first_name + ' ' + c.last_name AS full_name,
    0 AS total_order_value,
    'No Orders' AS customer_category

FROM customers c
WHERE c.customer_id NOT IN
(
    SELECT customer_id FROM orders
);


--------------------------------------
--problem-3

USE AutoDb;



/* STORES TABLE */
CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);


/* PRODUCTS TABLE */
CREATE TABLE products2
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);


/* ORDERS TABLE */
CREATE TABLE orders2
(
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);


/* ORDER ITEMS TABLE */
CREATE TABLE order_items
(
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES orders2(order_id),
    FOREIGN KEY (product_id) REFERENCES products2(product_id)
);


/* STOCK TABLE */
CREATE TABLE stocks
(
    store_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products2(product_id)
);



/* INSERT STORES */
INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Mumbai Store'),
(3,'Delhi Store');



/* INSERT PRODUCTS */
INSERT INTO products2 VALUES
(1,'Mountain Bike',1200),
(2,'Road Bike',1800),
(3,'Electric Bike',3000),
(4,'Kids Bike',400);



/* INSERT ORDERS */
INSERT INTO orders2 VALUES
(101,1,'2024-01-10'),
(102,1,'2024-02-12'),
(103,2,'2024-02-15'),
(104,3,'2024-03-01');



/* INSERT ORDER ITEMS */
INSERT INTO order_items VALUES
(101,1,2,50),
(101,2,1,30),
(102,3,1,100),
(103,1,3,60),
(104,4,2,20);



/* INSERT STOCK DATA */
INSERT INTO stocks VALUES
(1,1,10),
(1,2,5),
(1,3,0),
(2,1,0),
(3,4,6);



/* PRODUCTS SOLD IN STORES */
SELECT store_id, product_id
FROM orders2 o
JOIN order_items oi
ON o.order_id = oi.order_id;



/* PRODUCTS CURRENTLY IN STOCK */
SELECT store_id, product_id
FROM stocks
WHERE quantity > 0;



/* INTERSECT → PRODUCTS SOLD AND STILL IN STOCK */
SELECT store_id, product_id
FROM
(
    SELECT o.store_id, oi.product_id
    FROM orders2 o
    JOIN order_items oi
    ON o.order_id = oi.order_id
) sold_products

INTERSECT

SELECT store_id, product_id
FROM stocks
WHERE quantity > 0;



/* EXCEPT → PRODUCTS SOLD BUT NOW OUT OF STOCK */
SELECT store_id, product_id
FROM
(
    SELECT o.store_id, oi.product_id
    FROM orders2 o
    JOIN order_items oi
    ON o.order_id = oi.order_id
) sold_products

EXCEPT

SELECT store_id, product_id
FROM stocks
WHERE quantity > 0;



/* FINAL REPORT */
SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * p.list_price) - oi.discount) AS total_revenue

FROM order_items oi
JOIN orders2 o
ON oi.order_id = o.order_id

JOIN stores s
ON o.store_id = s.store_id

JOIN products2 p
ON oi.product_id = p.product_id

GROUP BY s.store_name, p.product_name;



/* UPDATE STOCK FOR DISCONTINUED PRODUCTS (SIMULATION) */
UPDATE stocks
SET quantity = 0
WHERE product_id = 3;


---------------------problem-4


USE AutoDb;


/* CUSTOMERS TABLE */
CREATE TABLE customers2
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);


/* ORDERS TABLE */
CREATE TABLE orders3
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT, 
    -- 1 = Pending
    -- 2 = Completed
    -- 3 = Rejected
    FOREIGN KEY (customer_id) REFERENCES customers2(customer_id)
);


/* ARCHIVED ORDERS TABLE */
CREATE TABLE archived_orders
(
    order_id INT,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT
);



/* INSERT CUSTOMERS */
INSERT INTO customers2 VALUES
(1,'Rahul','Sharma'),
(2,'Anita','Verma'),
(3,'Vikram','Reddy'),
(4,'Priya','Singh');



/* INSERT ORDERS */
INSERT INTO orders3 VALUES
(101,1,'2023-01-10','2023-01-20','2023-01-18',2),
(102,1,'2022-02-15','2022-02-25','2022-02-28',3),
(103,2,'2024-03-01','2024-03-10','2024-03-09',2),
(104,3,'2023-05-05','2023-05-15','2023-05-20',2),
(105,4,'2022-01-10','2022-01-20',NULL,3);



/* 1️⃣ ARCHIVE OLD REJECTED ORDERS */
INSERT INTO archived_orders
SELECT *
FROM orders3
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());



/* 2️⃣ DELETE OLD REJECTED ORDERS */
DELETE FROM orders3
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());



/* 3️⃣ CUSTOMERS WHOSE ALL ORDERS ARE COMPLETED */
SELECT c.customer_id,
       c.first_name + ' ' + c.last_name AS full_name
FROM customers2 c
WHERE NOT EXISTS
(
    SELECT *
    FROM orders3 o
    WHERE o.customer_id = c.customer_id
    AND o.order_status <> 2
);



/* 4️⃣ ORDER PROCESSING DELAY */
SELECT 
order_id,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay_days
FROM orders3;



/* 5️⃣ MARK ORDERS AS DELAYED OR ON TIME */
SELECT 
order_id,
order_date,
required_date,
shipped_date,

CASE
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS delivery_status

FROM orders3;
