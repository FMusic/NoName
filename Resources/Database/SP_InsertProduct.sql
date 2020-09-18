USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_InsertProduct
@Name VARCHAR(50),
@AvailableQuantity INT,
@Price FLOAT,
@CategoryId INT
AS
BEGIN
	INSERT INTO Product VALUES (@Name, @AvailableQuantity, @Price, @CategoryId);
END
