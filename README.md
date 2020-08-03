# you should run sql script for creating database.

CREATE DATABASE RideShare

GO;

CREATE TABLE dbo.User
(
 Id int NOT NULL PRIMARY KEY, -- primary key column
 Name nvarchar(50) ,
 Email nvarchar(50),
 PhoneNumber NVARCHAR(50)
);

GO;

CREATE TABLE dbo.TravelPlan
(
 Id int NOT NULL PRIMARY KEY, -- primary key column
 UserId int not null,
 FromCityId int not null,
 ToCityId int not null,
 Description NVARCHAR(max),
 TravelDate DATETIME not null,
 AvailableSeatCount int,
 IsPublished BIT,
 constraint fk_travelPlan_user foreign key (UserId) references dbo.[User] (Id)
);

GO;

CREATE Table dbo.TravelPlanDetail
(
 Id int not null PRIMARY key,
 TravelPlanId int not null,
 CustomerId int not null,
 PurchasedSeat int,
 constraint fk_travelPlanDetail_user foreign key (CustomerId) references dbo.[User] (Id),
 constraint fk_travelPlanDetail_travelPlan foreign key (TravelPlanId) references dbo.[TravelPlan] (Id)
)
