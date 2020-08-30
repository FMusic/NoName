USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_UpdateProduct
@Id INT,
@AvailableQuantity INT,
@Price FLOAT,
@CategoryId INT
AS
BEGIN
	UPDATE Product
	SET
		AvailableQuantity = @AvailableQuantity,
		Price = @Price,
		CategoryId = @CategoryId
	WHERE Id = @Id;
END
