CREATE DATABASE Task_2DB;
USE Task_2DB;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL
);

INSERT INTO customers (customer_id, first_name, last_name)
VALUES
(1, 'Sahihti', 'Shetti'),
(2, 'Anita', 'Reddy'),
(3, 'Kiran', 'Kumar'),
(4, 'Sneha', 'Patel');

select * from customers;


CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) 
        REFERENCES customers(customer_id)
);

INSERT INTO orders (order_id, customer_id, order_date, order_status)
VALUES
(101, 1, '2026-03-01', 1),   
(102, 2, '2026-03-02', 4),   
(103, 3, '2026-02-28', 1),   
(104, 1, '2026-03-03', 4),   
(105, 4, '2026-03-04', 1);   

select * from orders;

UPDATE orders
SET order_status = 2
WHERE order_id = 103;


SELECT 
    customers.customer_id,
    customers.first_name,
    customers.last_name,
    orders.order_id,
    orders.order_date,
    orders.order_status
FROM customers
INNER JOIN orders
    ON customers.customer_id = orders.customer_id
 WHERE orders.order_status = 1
   OR orders.order_status = 4
   ORDER BY orders.order_date DESC ;
   --??(orders)

   ----------------------------------------------------
   --problem-2

   CREATE DATABASE TaskDB;
USE TaskDB;

 CREATE TABLE brands (
    brand_id INT PRIMARY KEY,        
    brand_name VARCHAR(50) NOT NULL  
);

INSERT INTO brands (brand_id, brand_name)
VALUES
(1, 'Nike'),
(2, 'Adidas'),
(3, 'Puma');

SELECT * FROM brands;

CREATE TABLE categories_1 (
    category_id INT PRIMARY KEY,        
    category_name VARCHAR(50) NOT NULL  
);

INSERT INTO categories_1 (category_id, category_name)
VALUES
(1, 'Shoes'),
(2, 'Cloths'),
(3, 'Items');

SELECT * FROM categories_1;

CREATE TABLE products (
    product_id INT PRIMARY KEY,     
    product_name VARCHAR(100) NOT NULL,
    brand_id INT,                 
    category_id INT,              
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories_1(category_id)
);

INSERT INTO products (product_id, product_name, brand_id, category_id, model_year, list_price)
VALUES
(101, 'Max', 1, 1, 2023, 800),
(102, 'Dress', 2, 1, 2022, 750),
(103, 'Chains', 1, 2, 2023, 450),  
(104, 'Sweatpants', 3, 2, 2022, 600),
(105, 'Cap', 2, 3, 2023, 550);


SELECT *FROM products;

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b
    ON p.brand_id = b.brand_id
INNER JOIN categories_1 c
    ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ;

----------------------------------------------------------------

--problem-3



 CREATE DATABASE SalesDb;
USE SalesDb;

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(30)
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items
(
    item_id INT PRIMARY KEY,
    order_id INT,
    product_name VARCHAR(30),
    quantity INT,
    list_price INT,
    discount DECIMAL(5,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

INSERT INTO stores VALUES
(1,'Central Store'),
(2,'Market Store'),
(3,'City Store');

INSERT INTO orders VALUES
(101,1,4),
(102,1,2),
(103,2,4),
(104,3,4),
(105,2,3);

INSERT INTO order_items VALUES
(1,101,'Bike',2,50000,0.10),
(2,101,'Helmet',1,2000,0.05),
(3,103,'Scooter',1,40000,0.08),
(4,104,'Car',1,500000,0.15),
(5,105,'Bike',1,50000,0.10);

SELECT 
s.store_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;


-----------------------------------------
---problem-4

CREATE DATABASE StoreInventory;
USE StoreInventory;

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(30)
);

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(30)
);

CREATE TABLE stocks
(
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items
(
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO products VALUES
(1,'Bike'),
(2,'Scooter'),
(3,'Car'),
(4,'Helmet');


INSERT INTO stores VALUES
(1,'Central Store'),
(2,'City Store');

INSERT INTO stocks VALUES
(1,1,10),
(1,2,5),
(1,3,2),
(1,4,20),
(2,1,8),
(2,2,3),
(2,3,1),
(2,4,15);

INSERT INTO orders VALUES
(101,1),
(102,1),
(103,2);

INSERT INTO order_items VALUES
(1,101,1,2),
(2,101,4,1),
(3,102,2,1),
(4,103,1,3);

SELECT 
p.product_name,
s.store_name,
st.quantity AS available_stock,
SUM(oi.quantity) AS total_quantity_sold
FROM stocks st

INNER JOIN products p
ON st.product_id = p.product_id

INNER JOIN stores s
ON st.store_id = s.store_id

LEFT JOIN order_items oi
ON st.product_id = oi.product_id

GROUP BY 
p.product_name,
s.store_name,
st.quantity

ORDER BY p.product_name;