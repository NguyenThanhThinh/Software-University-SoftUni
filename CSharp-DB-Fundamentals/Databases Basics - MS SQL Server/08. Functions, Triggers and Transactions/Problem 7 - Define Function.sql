CREATE FUNCTION ufn_IsWordComprised(@setOfLetters nvarchar(max), @word nvarchar(max))
RETURNS bit
AS
BEGIN

DECLARE @result bit = 1;
DECLARE @currentChar varchar(5);
DECLARE @wordLenght int = LEN(@word);

	WHILE (@wordLenght >= 0)
	BEGIN
		SET @currentChar = SUBSTRING(@word, @wordLenght, 1)

		IF(@setOfLetters NOT LIKE '%'+@currentChar+'%')
		BEGIN
			SET @result = 0;
		END

		SET @wordLenght -= 1;
	END

RETURN @result

END