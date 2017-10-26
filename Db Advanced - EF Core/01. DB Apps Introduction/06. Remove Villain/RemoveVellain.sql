BEGIN TRANSACTION

	DECLARE @RowEffected int;

	IF(EXISTS(SELECT * FROM Villains WHERE Id = @GivenId))
	BEGIN
		DELETE FROM MinnionsVillains
		WHERE VillainId = @GivenId;

		SET @RowEffected = @@ROWCOUNT;
	
		SELECT v.Name, @RowEffected AS [RowEffected] FROM Villains AS [v]
		WHERE v.Id = @GivenId

		DELETE FROM Villains
		WHERE Id = @GivenId	
	END

COMMIT