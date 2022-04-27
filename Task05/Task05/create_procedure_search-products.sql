CREATE PROCEDURE SearchProducts
(
    @Price MONEY,
    @OrderedUnits SMALLINT
)
AS
    SELECT *
    FROM Products
    WHERE UnitPrice < @Price AND UnitsOnOrder > @OrderedUnits;
