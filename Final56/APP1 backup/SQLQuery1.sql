UPDATE Users
SET Position = 'goalkeeper'
WHERE Position IS NULL; 
select * from Users 



CREATE TABLE [dbo].[Status] (
    [Status] VARCHAR (50) NOT NULL,
    [Id]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Status] ASC)
);
