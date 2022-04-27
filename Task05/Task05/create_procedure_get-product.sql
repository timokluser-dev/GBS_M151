CREATE PROCEDURE GetProduct
(
    @Id INT,
    @Article VARCHAR(40) OUTPUT,
    @Price MONEY OUTPUT
)
AS
    SELECT @Article=ProductName, @Price=UnitPrice
    FROM Products
    WHERE ProductID=@Id
RETURN @@ROWCOUNT;
