CREATE FUNCTION udf_GetRadians(@Degrees float)
RETURNS FLOAT
AS
BEGIN
	
	DECLARE @Radians FLOAT;
	SET @Radians = (PI() * @Degrees) / 180;
RETURN @Radians
END