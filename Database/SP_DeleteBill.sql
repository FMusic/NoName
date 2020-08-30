USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_DeleteBill
@Id INT
AS
BEGIN
	DELETE FROM BillStatus WHERE BillId = @Id;
	DELETE FROM BillContent WHERE BillId = @Id;
	DELETE FROM Bill WHERE Id = @Id;
END
