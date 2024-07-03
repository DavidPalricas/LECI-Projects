CREATE FUNCTION dbo.HashPassword(@password NVARCHAR(128))
RETURNS VARCHAR(128)
AS
BEGIN
    DECLARE @hashedPassword VARCHAR(128);
    SET @hashedPassword = CONVERT(VARCHAR(128), HASHBYTES('SHA2_256', @password), 2); -- SHA-256 hashing algoritmo
    RETURN @hashedPassword;
END;

Go