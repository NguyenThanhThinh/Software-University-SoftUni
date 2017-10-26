WITH cte_Id_Rate (Id, Rate)
  AS 
(SELECT p.Id, AVG(f.Rate) AS [Rate] FROM Products AS [p]
  INNER JOIN Feedbacks AS [f] ON f.ProductId = p.Id
  GROUP BY p.Name, p.Id
 HAVING AVG(f.Rate) BETWEEN 5 AND 8)

SELECT d.Name, i.Name, p.Name, cte_Id_Rate.Rate FROM cte_Id_Rate, Ingredients AS [i]
 INNER JOIN ProductsIngredients AS [pi] ON pi.IngredientId = i.Id
 INNER JOIN Products AS [p] ON p.Id = pi.ProductId
 INNER JOIn Distributors AS [d] ON d.Id = i.DistributorId
 WHERE pi.ProductId IN (SELECT Id FROM cte_Id_Rate) 
   AND cte_Id_Rate.Id = pi.ProductId
 ORDER BY d.Name, i.Name, p.Name