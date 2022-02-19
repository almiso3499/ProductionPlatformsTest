
-- Exercise 1

-- 1). Show the order quantity (OrderQty), the Name of the product (Name) and the price (ListPrice) of the order made by CustomerID 29531

SELECT SalesOrderDetail.OrderQty, Product.Name, Product.ListPrice 
FROM [AdventureWorksLT2019].[SalesLT].[SalesOrderHeader] as SalesOrderHeader
INNER JOIN [AdventureWorksLT2019].[SalesLT].[SalesOrderDetail] as SalesOrderDetail
ON SalesOrderHeader.SalesOrderID = SalesOrderDetail.SalesOrderID
INNER JOIN [AdventureWorksLT2019].[SalesLT].[Product] as Product
ON SalesOrderDetail.ProductID = Product.ProductID
WHERE SalesOrderHeader.CustomerID = 29531;

-- 2). How many products in ProductCategory ‘Mountain Bikes’ have been sold to an address in ‘Toronto’?

SELECT * FROM [AdventureWorksLT2019].[SalesLT].[SalesOrderHeader] as SalesOrderHeader
INNER JOIN [AdventureWorksLT2019].[SalesLT].[SalesOrderDetail] as SalesOrderDetail
ON SalesOrderHeader.SalesOrderID = SalesOrderDetail.SalesOrderID
INNER JOIN [AdventureWorksLT2019].[SalesLT].[Product] as Product
ON SalesOrderDetail.ProductID = Product.ProductID
INNER JOIN [AdventureWorksLT2019].[SalesLT].[ProductCategory] as ProductCategory
ON Product.ProductCategoryID = ProductCategory.ProductCategoryID
INNER JOIN [AdventureWorksLT2019].[SalesLT].[Address] as Address
ON SalesOrderHeader.ShipToAddressID = Address.AddressID
WHERE ProductCategory.Name = 'Mountain Bikes' and Address.City = 'Toronto';


-- 3). Show the number of orders by range (in $), and the total sum:
 
select t.range as 'RANGE', sum(t.NumOrders) as 'Num Orders', sum(t.Total) as 'Total Value'
from (
      SELECT COUNT(*) AS NumOrders, SUM(LineTotal) as Total, 
	  CASE WHEN SUM(LineTotal) >= 0 and SUM(LineTotal) < 99 then '0-99'
	  WHEN SUM(LineTotal) >= 100 and SUM(LineTotal) < 999 then '100-999' 
	  WHEN SUM(LineTotal) >= 1000 and SUM(LineTotal) < 9999 then '1000-9999' 
	  WHEN SUM(LineTotal) >= 10000 THEN '10000 + ' END AS range
	  FROM SalesLT.SalesOrderDetail GROUP BY SalesOrderID) t
group by t.range