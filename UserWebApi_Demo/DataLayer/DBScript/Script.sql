
Create Database UserAPIDB

Create Table UserMst(
Id int not null identity(1,1) PRIMARY KEY,
Fullname varchar (200) not null,
Address Varchar(200) not null,
Mobilenumber nvarchar(30) not null,
Percentage decimal(18,2) not null,
DOB datetime not null,
CategoryId int not null,
SubcategoryId int not null,
IsActive bit not null,
IsDelete bit not null,
Createddate datetime null,
Updateddate datetime null
)

Create Table CategoryMst(
CategoryId int identity(1,1) Primary key,
Categoryname varchar(50) not null
)

create table SubcategoryMst(
SubcategoryId int identity(1,1) Primary key,
CategoryId int,
Subcategoryname varchar(50) not null
)
