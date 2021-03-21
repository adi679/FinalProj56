update[campaign_2021] SET[campaign_2021].CLICKS = ([campaign_2021].CLICKS) + 1 ,[campaign_2021].remain = ([campaign_2021].remain) - 50 WHERE( [campaign_2021].restid = '16758761' and[campaign_2021].status = 1) 
update campaign_2021 set status=0 where campaign_2021.remain<50 

select * from 