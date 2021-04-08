--DDL

create database People;

use People;

create table Funcionarios (

IdFuncionario			int primary key identity, 
NomeFuncionario			varchar(100) not null,
SobrenomeFuncionario	varchar(100) not null,
DatadeNascimento		Date not null
)

--DML

insert into Funcionarios (NomeFuncionario, SobrenomeFuncionario, DatadeNascimento) 
VALUES					 ('Catarina', 'Strada', '20030630'),
						 ('Tadeu', 'Vitelli', '19950116')

UPDATE Funcionarios SET NomeFuncionario = 'Livia' , SobrenomeFuncionario = 'Silva', DatadeNascimento = '20030630' WHERE IdFuncionario = 1

--DQL

select * from Funcionarios