SELECT Products.ProductName, Categories.Name as CategoryName
FROM MainOffice.dbo.Products as Products, MainOffice.dbo.Categories as Categories
WHERE Products.CategoryID = Categories.CategoryID AND Products.Quantity > 9
UNION ALL
SELECT Products.ProductName, Categories.Name
FROM [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Products] as Products, [DESKTOP-B4L9B2O].[TypicalBranch].[dbo].[Categories] as Categories
WHERE Products.CategoryID = Categories.CategoryID AND Products.Quantity > 3
ORDER BY ProductName 