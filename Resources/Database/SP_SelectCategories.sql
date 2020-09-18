USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectCategories
AS
BEGIN
	SELECT * FROM Category;
END
