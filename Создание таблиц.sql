Create table Client
(
    ClientId int not null identity(1,1),
    NameClient varchar(20) not null,
    Login varchar(18) not null unique,
    Password varchar(30) not null,
    MentorId int not null
)
go
alter table Client
    add constraint PK_Clients primary key(ClientId)
go
create table Mentor
(
    MentorId int not null identity(1,1),
    NameMentor varchar(20) not null,
    SurnameMentor varchar(20) not null,
    Post varchar(20) not null
)
go
alter table Mentor
    add constraint PK_Mentors primary key(MentorId)
go
alter table Client
    add constraint FK_Clients_Mentors foreign key(MentorId) references Mentor(MentorId)
create table Subscription
(
    SubscriptionId int not null identity(1,1),
    NameSubscription varchar(20) not null,
    Cost int not null,
    ClientId int not null
)
go
alter table Subscription
    add constraint PK_Subscription primary key(SubscriptionId)
go

alter table Subscription
    add constraint FK_Client_Subscription foreign key(ClientId) references Client(ClientId)
create table Schedule
(
    ScheduleId int not null identity(1,1),
    CountPower int not null,
    CountCardio int not null,
    ClientId int not null
)
alter table Schedule
    add constraint PK_Schedule primary key(ScheduleId)
go

alter table Schedule
    add constraint FK_Client_Schedule foreign key(ClientId) references Client(ClientId)
go
create table Target
(
    TargetId int not null identity(1,1),
    StartWeight int not null,
    EndWeight int not null,
    SumProtein int not null,
    SumFat int not null,
    SumUgl int not null,
    ClientId int not null
)
alter table Target
    add constraint PK_Target primary key(TargetId)
go

alter table Target
    add constraint FK_Client_Target foreign key(ClientId) references Client(ClientId)
go

create table Product
(
    ProductId int not null identity(1,1),
    Name varchar(20) not null,
    CountProtein int not null,
    CountFat int not null,
    CountUgl int not null
)
go
alter table Product
    add constraint PK_Product primary key(ProductId)
go
create table AllergyProduct
(
    CardId int not null identity(1,1),
    ProductId int not null,
    ClientId int not null
)
go
alter table AllergyProduct
    add constraint PK_AllergyCard primary key(CardId)
go
alter table AllergyProduct
    add constraint FK_AllergyCard_Client foreign key(ClientId) references Client(ClientId)
go
alter table AllergyProduct
    add constraint FK_AllergyCard_Product foreign key(ProductId) references Product(ProductId)
go
create table AllowProduct
(
    AllowProductId int not null identity(1,1),
    TargetId int not null,
    ProductId int not null
)
alter table AllowProduct
    add constraint PK_AllowProduct primary key(AllowProductId)
go
alter table AllowProduct
    add constraint FK_AllowProduct_Product foreign key(ProductId) references Product(ProductId)
go
alter table AllowProduct
    add constraint FK_AllowProduct_Target foreign key(TargetId) references Target(TargetId)