CREATE DATABASE InlockGames;
GO

USE InlockGames;
GO

--DDL

CREATE TABLE Estudios (
IdEstudio			   INT PRIMARY KEY IDENTITY,
NomeEstudio			   VARCHAR(100) NOT NULL
)

CREATE TABLE Jogos (
IdJogo				INT PRIMARY KEY IDENTITY,
NomeJogo			VARCHAR(100) NOT NULL,
Descricao			VARCHAR(300) NOT NULL,
DataDeLancamento    DATE,
IdEstudio			INT FOREIGN KEY REFERENCES Estudios
)
ALTER TABLE Jogos ADD Valor FLOAT(10) NOT NULL;

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

--DML

INSERT INTO TipoUsuario (Titulo)
VALUES					('Administrador'),
						('Cliente')

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES				 ('admin@admin.com', 'admin', 1),
                     ('cliente@cliente.com', 'cliente', 2)

INSERT INTO Estudios (NomeEstudio)
VALUES				 ('Blizzard'),
				     ('Rockstar Studios'),
					 ('Square Enix')

INSERT INTO Jogos (NomeJogo, Valor, Descricao, DataDeLancamento, IdEstudio)
VALUES			  ('Diablo 3',99, 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '20120315', 1),
                  ('Red Dead Redemption II', 120, 'jogo eletrônico de ação-aventura western', '20181026',2)

--DQL

--Listando cada um:

SELECT * FROM Usuarios;
SELECT * FROM TipoUsuario;
SELECT * FROM Jogos;
SELECT * FROM Estudios;

--Listar todos os jogos e seus respectivos estúdios:

SELECT NomeJogo, NomeEstudio FROM Jogos
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio

--Buscar e trazer na lista todos os estúdios com os respectivos jogos
SELECT NomeEstudio, NomeJogo FROM Estudios
LEFT JOIN Jogos
ON Jogos.IdEstudio = Estudios.IdEstudio

--Buscar um usuário por e-mail e senha (login)
SELECT Email, Senha FROM Usuarios WHERE Email LIKE 'adm%' AND Senha LIKE 'adm%'

--Buscar um jogo por idJogo
SELECT NomeJogo, Valor, Descricao FROM Jogos WHERE IdJogo = 2

--Buscar um estúdio por idEstudio
SELECT NomeEstudio FROM Estudios WHERE IdEstudio = 2

--Extra
--Mostrar a lista de todos os estúdios e incluir na lista a lista de jogos daquele determinado estúdio;
SELECT NomeEstudio, NomeJogo FROM Estudios 
LEFT JOIN Jogos
ON Estudios.IdEstudio = Jogos.IdEstudio