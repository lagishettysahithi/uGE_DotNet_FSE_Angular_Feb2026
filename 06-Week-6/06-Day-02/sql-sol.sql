use AutoDb;
select *from products;
SELECT Count(*) FROM products


---sp

CREATE PROCEDURE sp_InsertProduct
    @product_name VARCHAR(100),
    @model_year INT,
    @list_price DECIMAL(10,2),
    @category_id INT
AS
BEGIN
    INSERT INTO Products(product_name, model_year, list_price, category_id)
    VALUES(@product_name, @model_year, @list_price, @category_id)
END
GO


---view

CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products
END
GO


---update


CREATE PROCEDURE sp_UpdateProduct
    @product_id INT,
    @product_name VARCHAR(100),
    @model_year INT,
    @list_price DECIMAL(10,2),
    @category_id INT
AS
BEGIN
    UPDATE Products
    SET product_name = @product_name,
        model_year = @model_year,
        list_price = @list_price,
        category_id = @category_id
    WHERE product_id = @product_id
END
GO


---delete
CREATE PROCEDURE sp_DeleteProduct
    @product_id INT
AS
BEGIN
    DELETE FROM Products WHERE product_id = @product_id
END
GO


sp_help Products;


-- Create new table with IDENTITY
CREATE TABLE Products_New
(
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_name VARCHAR(100),
    model_year INT,
    list_price DECIMAL(10,2),
    category_id INT
);

-- Copy data
INSERT INTO Products_New(product_name, model_year, list_price, category_id)
SELECT product_name, model_year, list_price, category_id FROM Products;

-- Drop old table
DROP TABLE Products;

-- Rename
EXEC sp_rename 'Products_New', 'Products';