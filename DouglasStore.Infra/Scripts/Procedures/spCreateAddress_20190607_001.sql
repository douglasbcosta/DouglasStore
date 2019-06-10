CREATE PROCEDURE spCreateAddress
    @Id UNIQUEIDENTIFIER,
    @CustomerId UNIQUEIDENTIFIER,
    @Number VARCHAR(40),
    @Complement VARCHAR(40),
    @District VARCHAR(60),
    @City VARCHAR(60),
    @State CHAR(2),
    @ZipCode CHAR(8),
    @Type INT
AS
    INSERT INTO [Address](
        [Id],
        [CustomerId],
        [Number],
        [Complement],
        [District],
        [City],
        [State],
        [ZipCode],
        [Type]
    ) VALUES (
        @Id,
        @CustomerId,
        @Number,
        @Complement,
        @District,
        @City,
        @State,
        @ZipCode,
        @Type
    );
