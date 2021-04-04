--DDL

create database People;

use People;

create table Funcionarios (

IdFuncionário  int primary key identity, 
NomeFuncionario  varchar(100) not null,
SobrenomeFuncionario varchar(100) not null

)

--DML

insert into Funcionarios (NomeFuncionario, SobrenomeFuncionario) 
VALUES					 ('Catarina', 'Strada'),
						 ('Tadeu', 'Vitelli')


--DQL

select * from Funcionarios