select distinct [Restaurants_2021].ID, [Restaurants_2021].ADDRESS ,[Restaurants_2021].[FEATURED IMAGE],[Restaurants_2021].NAME,[Restaurants_2021].PHONE,[Restaurants_2021].PRICE,[Restaurants_2021].RATING,[Restaurants_2021].url from  [Restaurants_2021]
INNER JOIN [Restaurant&Highlight_2021] on Restaurants_2021.ID=[Restaurant&Highlight_2021].[id.Restaurants] 
where title in(select title from[CUSTOMER&Highlight_2021] WHERE email='nanathe@queen.com' and status = 1)
GROUP BY ID
select * from campaign_2021 where STATUS=1

		select distinct[Restaurants_2021].ID, [Restaurants_2021].ADDRESS ,[Restaurants_2021].[FEATURED IMAGE],[Restaurants_2021].NAME,[Restaurants_2021].PHONE,[Restaurants_2021].PRICE,[Restaurants_2021].RATING,[Restaurants_2021].url from[Restaurants_2021] INNER JOIN[Restaurant&Highlight_2021] on Restaurants_2021.ID=[Restaurant&Highlight_2021].[id.Restaurants] where title in (select title from[CUSTOMER&Highlight_2021] WHERE email = 'nanathe@queen.com' and status = 1)
		select * from Highlights_2021
		SELECT distinct(title) FROM [Restaurant&Highlight_2021] 
		SELECT * FROM Restaurants_2021 order by RATING desc