USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectBillContents
AS
BEGIN
	SELECT
		bc.Id AS ContentId, bc.ProductPrice, bc.ProductQuantity, bc.BillId,
		p.Id AS ProductId, p.Name, p.AvailableQuantity, p.Price, p.CategoryId
	FROM BillContent bc
	INNER JOIN Product p ON p.Id = bc.ProductId
END
