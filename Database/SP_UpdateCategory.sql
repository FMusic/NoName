USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_UpdateCategory
@Id INT,
@Name VARCHAR(20)
AS
BEGIN
	UPDATE Category SET Name = @Name WHERE Id = @Id;
END
