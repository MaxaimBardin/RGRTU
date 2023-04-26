create database FitnessApp
on
(Name = 'FitnessApp',
FileName = 'C:\BD\Fitness.mdf',
size = 1,
maxsize = 15,
Filegrowth = 1)
log on
(Name = 'FitnessApp_log',
filename = 'C:\BD\Fitness.ldf',
size = 1,
maxsize = 10,
filegrowth = 1)