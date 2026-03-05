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


 