USE db_a114c8_dashagi;

DROP TABLE IF EXISTS db_a114c8_dashagi.Integrantes;

CREATE TABLE Integrantes(
	Id bigInt AUTO_INCREMENT PRIMARY KEY NOT NULL,
	Nome varchar (100) NOT NULL,
	Email varchar (100) NOT NULL,
	AtuacaoId int NOT NULL,
	Classificacao int NOT NULL,

	CONSTRAINT FK_Integrantes_AtuacaoId FOREIGN KEY (AtuacaoId)
    REFERENCES db_a114c8_dashagi.Atuacao(Id)
);

--  SQLINES DEMO *** ---------------------------------------------------	
-- Classificacao:
-- 1 - Estagiário
-- 2 - Junior
-- 3 - Pleno
-- 4 - Senior

INSERT INTO Integrantes VALUES (null, 'Luciano Santos Henrique', 'luciano.henrique@deal.com.br', 2, 4);
INSERT INTO Integrantes VALUES (null, 'Sergio Takeda', 'sergio.takeda@deal.com.br', 3, 4);
INSERT INTO Integrantes VALUES (null, 'Hoeliton', 'hoeliton.hoeliton@deal.com.br', 2, 4);
INSERT INTO Integrantes VALUES (null, 'Murilo Carrion', 'murilo.carrion@deal.com.br', 1, 4);
INSERT INTO Integrantes VALUES (null, 'Everson Jean', 'everson.jean@deal.com.br', 1, 4);
INSERT INTO Integrantes VALUES (null, 'Erik Santos', 'erik.santos@deal.com.br', 1, 4);
INSERT INTO Integrantes VALUES (null, 'Madureira', 'madureira@deal.com.br', 3, 4);
INSERT INTO Integrantes VALUES (null, 'Marcos Baião', 'marcos.baiao@deal.com.br', 1, 1);
	