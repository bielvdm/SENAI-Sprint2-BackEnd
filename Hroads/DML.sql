--DML


USE SENAI_HROADS_TARDE;

-- Exercício 3

INSERT INTO TipoDeHabilidade 
VALUES			('Ataque'),
				('Defesa'),
				('Cura'),
				('Magia');

INSERT INTO Habilidades	(IdTipoDeHabilidade , Nome)
VALUES					(1					, 'Lança Mortal'),
						(2					, 'Escudo Supremo'),
						(3					, 'Recuperar Vida');

INSERT INTO Classes (IdHabilidade , NomeClasse)
VALUES				(1   		  , 'Bárbaro'),
					(2		      , 'Cruzado'),
					(1		      , 'Caçadora de Demônios'),
					(3   		  , 'Monge'),
					(null	      , 'Necromante'),
					(3		      , 'Feiticeiro'),
					(null	      , 'Arcanista')

INSERT INTO ClassesHabilidades(IdClasse, IdHabilidade)
VALUES                        (1       , 1           ),
                              (1       , 2           ),
							  (2       , 2           ),
							  (3       , 1           ),
							  (4       , 3           ),
							  (4       , 2           ),
							  (5       , NULL        ),
							  (6       , 3           ),
							  (7       , NULL        )



INSERT INTO Personagem (IdClasse, NomePersonagem, CapacidadeVida, CapacidadeMana, DataCriacao, DataAtualização)
VALUES				   (1      , 'DeuBug'      , 100           , 80            , '20190118' , '20210302'),
					   (2      , 'BitBug'      , 70            , 100           , '20160317' , '20210302'),
					   (3      , 'Fer8'        , 75            , 60            , '20180318' , '20210302')


INSERT INTO TipoUsuario (Titulo)
VALUES					('Administrador'),
						('Cliente')

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES				 ('admin@admin.com', 'admin', 1),
                     ('cliente@cliente.com', 'cliente', 2)


--Tarefa 4
update Personagem
set NomePersonagem = 'Fer7'
WHERE NomePersonagem = 'Fer8'