USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_DeleteCategory
@Id INT
AS
BEGIN
	DELETE FROM Category WHERE Id = @Id;
END
