UPDATE Users
SET Position = 'goalkeeper'
WHERE Position IS NULL; 
select * from Users 