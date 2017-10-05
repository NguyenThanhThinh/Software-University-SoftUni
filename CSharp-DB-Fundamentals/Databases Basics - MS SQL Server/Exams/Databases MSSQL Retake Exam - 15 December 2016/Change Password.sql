CREATE PROC udp_ChangePassword(@Email varchar(30), @Password varchar(20))
AS
	IF (@Email NOT IN (SELECT Email FROM Credentials))
	BEGIN
		RAISERROR ('The email does''t exist!', 16, 1)
		RETURN
	END

	UPDATE Credentials
	SET Password = @Password
	WHERE Email = @Email