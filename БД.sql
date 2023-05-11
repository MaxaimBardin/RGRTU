create database Baker
on
(Name = 'Baker',
FileName = 'C:\BD\Baker.mdf',
size = 1,
maxsize = 15,
Filegrowth = 1)
log on
(Name = 'Baker_log',
filename = 'C:\BD\Baker.ldf',
size = 1,
maxsize = 10,
filegrowth = 1)