
select distinct[Restaurants_2021].*  
from [Restaurants_2021] INNER JOIN[Restaurant&Highlight_2021] on Restaurants_2021.ID=[Restaurant&Highlight_2021].[id.Restaurants] INNER JOIN  campaign_2021 ON campaign_2021.restid = Restaurants_2021.ID
where title in (
select title 
from CUSTOMER_2021 inner join  [CUSTOMER&Highlight_2021] on CUSTOMER_2021.email=  [CUSTOMER&Highlight_2021].email WHERE [CUSTOMER&Highlight_2021].email ='adi@gmail.com' and [CUSTOMER&Highlight_2021].status=1 and CUSTOMER_2021.pricerange= Restaurants_2021.PRICE and campaign_2021.STATUS = 1) ORDER BY RATING DESC

select * from [CUSTOMER&Highlight_2021]WHERE email ='adi@gmail.com'

select * from [Restauran

t&Highlight_2021] where [id.Restaurants]='16771079' or [id.Restaurants]='16758999'




select *   from [Restaurants_2021] INNER JOIN[Restaurant&Highlight_2021] on Restaurants_2021.ID=[Restaurant&Highlight_2021].[id.Restaurants] INNER JOIN  campaign_2021 ON campaign_2021.restid = Restaurants_2021.ID where title in (select title from CUSTOMER_2021 inner join[CUSTOMER&Highlight_2021] on CUSTOMER_2021.email =  [CUSTOMER&Highlight_2021].email WHERE[CUSTOMER&Highlight_2021].email = 'adi@gmail.com' and[CUSTOMER&Highlight_2021].status = 1 and CUSTOMER_2021.pricerange = Restaurants_2021.PRICE and campaign_2021.STATUS = 1) ORDER BY campaign_2021.remain asc