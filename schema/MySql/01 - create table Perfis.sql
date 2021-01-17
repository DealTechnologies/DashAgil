USE `db_a114c8_dashagi`;

CREATE TABLE Perfis(
	`Id` int AUTO_INCREMENT PRIMARY KEY  NOT NULL,
	`Descricao` varchar (100) NOT NULL
);

--  SQLINES DEMO *** ---------------------------------------------------	

INSERT INTO Perfis VALUES (1, 'Owner');
INSERT INTO Perfis VALUES (2, 'Administrador');
INSERT INTO Perfis VALUES (3, 'Scrum Master (SM)');
INSERT INTO Perfis VALUES (4, 'Convidado');


