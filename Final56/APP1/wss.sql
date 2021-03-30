select * from UsersFavorites
select * from Users

IF EXISTS (select * from UsersFavorites where email='adi@gmail.com') begin UPDATE UsersFavorites SET UniversitySize=123 ,UniversityLevel='1,2' ,UniversityType='1',PriceMAX=12312,SAT=1111 WHERE  Email='adi@gmail.com' END else begin INSERT INTO [UsersFavorites] (Email,UniversitySize, UniversityLevel ,UniversityType ,PriceMAX, SAT)Values('adi@gmail.com', '13000', '1,2', '2,3', '1000', '1300') end



IF EXISTS(select* from UsersFavorites where email= 'shani@gmail.com') begin UPDATE UsersFavorites SET UniversitySize = 999 ,UniversityLevel ='2' ,UniversityType = '2,3',PriceMAX =1000,SAT = 999 WHERE Email = 'shani@gmail.com' END else begin INSERT INTO [UsersFavorites] (Email,UniversitySize, UniversityLevel ,UniversityType ,PriceMAX, SAT)end Values('shani@gmail.com', '999', '2', '2,3', '1000', '999')