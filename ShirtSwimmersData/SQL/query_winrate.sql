SELECT 
	MAX(H.Name) AS Hero,
	COUNT(P.hero_id) AS GamesPlayed,
	SUM(CASE WHEN P.win = 1 THEN 1 ELSE 0 END) AS Wins,
	SUM(CASE WHEN P.lose = 1 THEN 1 ELSE 0 END) AS Losses,
	CAST(SUM(CASE WHEN P.win = 1 THEN 1 ELSE 0 END) AS FLOAT) / CAST(COUNT(P.hero_id) AS FLOAT) * 100 AS WinPercentage
FROM [Shirtswimmers].[dbo].[Players] P
INNER JOIN [Shirtswimmers].[dbo].[Matches] M ON P.match_id = M.match_id
INNER JOIN [Shirtswimmers].[dbo].[Heroes] H ON P.hero_id = H.Id
WHERE M.game_mode = 23 AND account_id = 2679394 
GROUP BY hero_id HAVING COUNT(*) > 10
ORDER BY CAST(SUM(CASE WHEN P.win = 1 THEN 1 ELSE 0 END) AS FLOAT) / CAST(COUNT(P.hero_id) AS FLOAT) * 100 DESC