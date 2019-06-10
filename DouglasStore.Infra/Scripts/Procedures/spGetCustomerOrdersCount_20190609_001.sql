CREATE PROCEDURE spGetCustomerOrdersCount
    @Document CHAR(11)
AS
    SELECT
        c.[Id],
        CONCAT(c.[FisrtName],' ',c.[LastName]) Name,
        c. [Document],
        COUNT(o.Id) Orders
    FROM
        [Customer] c 
    INNER JOIN 
        [Order] o 
    ON 
        o.[CustomerId] = c.[Id]
    WHERE 
        c.[Document] = @Document;