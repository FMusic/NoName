USE NoNameCoffeeBar;
GO

CREATE PROCEDURE SP_SelectUserDataByUserNameAndPassword
@UserName VARCHAR(20),
@Password VARCHAR(20)
AS
BEGIN
	SELECT
		ud.Id AS UserDataId, ud.UserName, ud.Password, ud.FullName,
		ut.Id AS UserTypeId, ut.Name
	FROM UserData ud
	INNER JOIN UserType ut ON ut.Id = ud.UserTypeId
	WHERE ud.UserName = @UserName AND ud.Password = @Password;
END
