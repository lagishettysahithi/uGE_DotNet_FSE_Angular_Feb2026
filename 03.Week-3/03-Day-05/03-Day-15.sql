--Day-15
-- Create Database
CREATE DATABASE AutoStoreDB;
USE AutoStoreDB;

-- Create Category Table
CREATE TABLE bike_categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

-- Create Brand Table
CREATE TABLE bike_brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);

-- Create Product Table
CREATE TABLE bike_products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES bike_brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES bike_categories(category_id)
);

-- Create Customer Table
CREATE TABLE bike_customers (
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(100),
    city VARCHAR(50)
);

-- Create Store Table
CREATE TABLE bike_shops (
    shop_id INT PRIMARY KEY,
    shop_name VARCHAR(100),
    city VARCHAR(50)
);

-- Insert Categories
INSERT INTO bike_categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes'),
(4,'Kids Bikes'),
(5,'Hybrid Bikes');

-- Insert Brands
INSERT INTO bike_brands VALUES
(1,'SpeedRide'),
(2,'UrbanCycle'),
(3,'PowerWheel'),
(4,'ZoomBike'),
(5,'RoadMaster');

-- Insert Products
INSERT INTO bike_products VALUES
(101,'SpeedRide X1',1,1,2023,45000),
(102,'UrbanCycle Road Pro',2,2,2024,52000),
(103,'PowerWheel Electric',3,3,2023,75000),
(104,'ZoomBike Junior',4,4,2022,15000),
(105,'RoadMaster Hybrid',5,5,2024,40000);

-- Insert Customers
INSERT INTO bike_customers VALUES
(1,'Rahul','Hyderabad'),
(2,'Anita','Mumbai'),
(3,'Kiran','Hyderabad'),
(4,'Sneha','Delhi'),
(5,'Arjun','Chennai');

-- Insert Stores
INSERT INTO bike_shops VALUES
(11,'City Bike Hub','Hyderabad'),
(12,'Speed Cycle Store','Mumbai'),
(13,'Urban Ride Center','Bangalore'),
(14,'Power Bike Shop','Delhi'),
(15,'Cycle World','Chennai');

-- Retrieve products with brand and category
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.price
FROM bike_products p
JOIN bike_brands b
ON p.brand_id = b.brand_id
JOIN bike_categories c
ON p.category_id = c.category_id;

-- Customers from specific city
SELECT *
FROM bike_customers
WHERE city = 'Hyderabad';

-- Total products in each category
SELECT 
    c.category_name,
    COUNT(p.product_id) AS total_products
FROM bike_categories c
LEFT JOIN bike_products p
ON c.category_id = p.category_id
GROUP BY c.category_name;

------------------------------------------------------
--problem-2

-- View for product details
CREATE VIEW view_product_details AS
SELECT
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.price
FROM bike_products p
JOIN bike_brands b
ON p.brand_id = b.brand_id
JOIN bike_categories c
ON p.category_id = c.category_id;

-- Check the view
SELECT * FROM view_product_details;


-- Create Staff Table
CREATE TABLE bike_staff (
    staff_id INT PRIMARY KEY,
    staff_name VARCHAR(100)
);

-- Create Orders Table
CREATE TABLE bike_orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    shop_id INT,
    staff_id INT,
    order_date DATE,
    FOREIGN KEY (customer_id) REFERENCES bike_customers(customer_id),
    FOREIGN KEY (shop_id) REFERENCES bike_shops(shop_id),
    FOREIGN KEY (staff_id) REFERENCES bike_staff(staff_id)
);

-- Insert Staff
INSERT INTO bike_staff VALUES
(1,'Ramesh'),
(2,'Sita'),
(3,'David');

-- Insert Orders
INSERT INTO bike_orders VALUES
(201,1,11,1,'2024-02-10'),
(202,2,12,2,'2024-02-11'),
(203,3,11,3,'2024-02-12');

-- View for order summary
CREATE VIEW view_order_summary AS
SELECT
    o.order_id,
    c.customer_name,
    s.shop_name,
    st.staff_name,
    o.order_date
FROM bike_orders o
JOIN bike_customers c
ON o.customer_id = c.customer_id
JOIN bike_shops s
ON o.shop_id = s.shop_id
JOIN bike_staff st
ON o.staff_id = st.staff_id;

-- Check the view
SELECT * FROM view_order_summary;


-- Create Indexes for performance
CREATE INDEX idx_product_brand
ON bike_products(brand_id);

CREATE INDEX idx_product_category
ON bike_products(category_id);

CREATE INDEX idx_order_customer
ON bike_orders(customer_id);

CREATE INDEX idx_order_shop
ON bike_orders(shop_id);

CREATE INDEX idx_order_staff
ON bike_orders(staff_id);