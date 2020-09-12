USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectBillContents
@BillId INT = -1
AS
BEGIN
	IF (@BillId = -1)
	BEGIN
		SELECT
			bc.Id AS ContentId, bc.ProductPrice, bc.ProductQuantity, bc.BillId,
			p.Id AS ProductId, p.Name, p.AvailableQuantity, p.Price, p.CategoryId
		FROM BillContent bc
		INNER JOIN Product p ON p.Id = bc.ProductId
	END
	ELSE
	BEGIN
		SELECT
			bc.Id AS ContentId, bc.ProductPrice, bc.ProductQuantity, bc.BillId,
			p.Id AS ProductId, p.Name, p.AvailableQuantity, p.Price, p.CategoryId
		FROM BillContent bc
		INNER JOIN Product p ON p.Id = bc.ProductId
		WHERE bc.BillId = @BillId
	END
END
