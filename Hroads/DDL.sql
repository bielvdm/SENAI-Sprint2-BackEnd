--DDL

--Exercício 1
CREATE DATABASE SENAI_HROADS_TARDE;

USE SENAI_HROADS_TARDE;

--Exercício 2
CREATE TABLE TipoDeHabilidade(

	IdTipoDeHabilidade	INT PRIMARY KEY IDENTITY,
	NomeTipo			VARCHAR(100) NOT NULL,

);

CREATE TABLE Habilidades(

	IdHabilidade		INT PRIMARY KEY IDENTITY,
	IdTipoDeHabilidade	INT FOREIGN KEY REFERENCES TipoDeHabilidade(IdTipoDeHabilidade),

	Nome				VARCHAR(100) NOT NULL,

);
CREATE TABLE Classes(
	
	IdClasse			INT PRIMARY KEY IDENTITY,
	IdHabilidade		INT FOREIGN KEY REFERENCES Habilidades(IdHabilidade),

	NomeClasse			VARCHAR(100) NOT NULL,

);

CREATE TABLE ClassesHabilidades(
	IdClasse		  INT FOREIGN KEY REFERENCES Classes(IdClasse),
	IdHabilidade      INT FOREIGN KEY REFERENCES Habilidades(IdHabilidade)
);

CREATE TABLE Personagem(
	
	IdPersonagem		INT PRIMARY KEY IDENTITY,
	IdClasse			INT FOREIGN KEY REFERENCES Classes(IdClasse),

	NomePersonagem		VARCHAR(100) NOT NULL,
	CapacidadeVida		INT NOT NULL,
	CapacidadeMana		INT NOT NULL,
	DataCriacao			DATE NOT NULL,
	DataAtualização		DATE NOT NULL,

);

CREATE TABLE TipoUsuario (
IdTipoUsuario             INT PRIMARY KEY IDENTITY,
Titulo					  VARCHAR (50)
)

CREATE TABLE Usuarios (
IdUsuario			   INT PRIMARY KEY IDENTITY,
Email				   VARCHAR(100) NOT NULL,
Senha				   VARCHAR(100) NOT NULL,
IdTipoUsuario		   INT FOREIGN KEY REFERENCES TipoUsuario
)