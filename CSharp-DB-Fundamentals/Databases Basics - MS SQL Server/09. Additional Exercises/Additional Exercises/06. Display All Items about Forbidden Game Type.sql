SELECT i.Name, i.Price, i.MinLevel, gt.Name AS [Forbidden Game Type] 
  FROM Items AS [i]
  FULL JOIN GameTypeForbiddenItems AS [gtf] ON gtf.ItemId = i.Id
  FULL JOIN GameTypes AS [gt] ON gt.Id = gtf.GameTypeId
 ORDER BY gt.Name DESC, i.Name