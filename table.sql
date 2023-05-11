create table Post(
    PostId int not null identity(1,1),
    Description varchar(50) not null,
)
go 
alter table Post
    add constraint PK_Post primary key(PostId)
go 
create table Worker(
    WorkerId int not null identity(1,1),
    PostId int not null,
    Name varchar(20) not null
)
go 
alter table Worker
    add constraint PK_Worker primary key(WorkerId)
go
create table Action (
    ActionId int not null identity(1,1),
    Description varchar(50) not null
)
alter table Action
    add constraint PK_Action primary key(ActionId)

go
create table Maesure(
    MaesureId int not null identity(1,1),
    Name varchar(20) not null
)
alter table Maesure
    add constraint PK_Measure primary key(MaesureId)
go
create table Baker(
    BakerId int not null identity(1,1),
    Name varchar(20) not null,
    Street varchar(30) not null,
    NumberHouse varchar(10) not null
)
alter table Baker
    add constraint PK_Baker primary key(BakerId)
go
create table Work(
    WorkId int not null identity(1,1),
    WorkerId int not null,
    ActionId int not null,
    BakerId int not null
)
alter table Work
    add constraint PK_Work primary key(WorkId)
go
create table Opens(
    OpenId int not null identity(1,1),
    MaesureId int not null,
    BakerId int not null
)
alter table Opens
    add constraint PK_Open primary key(OpenId)
go
alter table Worker
    add constraint FK_Worker_Post foreign key(PostId) references Post(PostId)
go
alter table Opens
    add constraint FK_Open_Maesure foreign key(MaesureId) references Maesure(MaesureId)
go
alter table Opens
    add constraint FK_Open_Baker foreign key(BakerId) references Baker(BakerId)
go
alter table Work
    add constraint FK_Work_Worker foreign key(WorkerId) references Worker(WorkerId)
alter table Work
    add constraint FK_Work_Action foreign key(ActionId) references Action(ActionId)
alter table Work
    add constraint FK_Work_Baker foreign key(BakerId) references Baker(BakerId)
