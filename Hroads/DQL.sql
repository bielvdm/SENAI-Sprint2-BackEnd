-- DQL 

use SENAI_HROADS_TARDE

-- Exercício 5
UPDATE Classes
SET NomeClasse = 'Necromancer'
WHERE IdClasse = 5;

-- Exercício 6
select * from Personagem

-- Exercício 7
SELECT * FROM Classes;

-- Exercício 8
select (NomeClasse) from Classes

-- Exercício 9
SELECT * FROM Habilidades;

-- Exercício 10
select count(Nome) from Habilidades;

-- Exercício 11
SELECT IdHabilidade FROM Habilidades;

-- Exercício 12
select * from Habilidades

-- Exercício 13
SELECT Habilidades.Nome , TipoDeHabilidade.NomeTipo FROM Habilidades
LEFT JOIN TipoDeHabilidade
ON Habilidades.IdHabilidade = TipoDeHabilidade.IdTipoDeHabilidade;

-- Exercício 14
select Personagem.NomePersonagem, Classes.NomeClasse from Personagem
left join Classes
on Classes.IdClasse = Personagem.IdPersonagem

-- Exercício 15
SELECT Personagem.NomePersonagem , Classes.NomeClasse ,
Personagem.CapacidadeVida , Personagem.CapacidadeMana 
FROM Personagem
INNER JOIN Classes
ON Personagem.IdPersonagem = Classes.IdClasse;

-- Exercício 16 
select Classes.NomeClasse, Habilidades.Nome from Classes 
full outer join ClassesHabilidades
on Classes.IdClasse= ClassesHabilidades.IdClasse
full outer join Habilidades
on ClassesHabilidades.IdHabilidade= Habilidades.IdHabilidade;

-- Exercício 17
select Classes.NomeClasse, Habilidades.Nome from Habilidades
inner join ClassesHabilidades
on Habilidades.IdHabilidade = ClassesHabilidades.IdHabilidade
inner join Classes
on ClassesHabilidades.IdClasse = Classes.IdClasse

-- Exercício 18 
select Classes.NomeClasse, Habilidades.Nome from Habilidades
left join ClassesHabilidades
on Habilidades.IdHabilidade = ClassesHabilidades.IdHabilidade
full outer join Classes
on ClassesHabilidades.IdClasse = Classes.IdClasse

SELECT * FROM Usuarios;
SELECT * FROM TipoUsuario;