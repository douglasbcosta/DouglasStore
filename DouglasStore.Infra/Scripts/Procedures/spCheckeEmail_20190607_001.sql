CREATE PROCEDURE spCheckEmail
    @Email VARCHAR(160)
AS
    SELECT CASE WHEN EXISTS(
        SELECT [Id]
        FROM [Customer]
        WHERE [Email] = @Email
    )
    THEN CAST(1 AS BIT)
    ELSE CAST(0 AS BIT) 
END