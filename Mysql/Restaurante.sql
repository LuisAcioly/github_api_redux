CREATE DATABASE Restaurante;

USE Restaurante;

 -- DROP TABLE Cozinha;
 -- DROP TABLE Ingrediente;
 -- DROP TABLE Funcionario;

CREATE TABLE Cozinha (
	ID_Cozinha integer PRIMARY KEY AUTO_INCREMENT,
    tipo varchar(20),
    horaAbertura int,
    horaFechamento int,
    pratoPrincipal varchar(20)
);

CREATE TABLE Ingrediente (
	ID_Ingrediente integer PRIMARY KEY AUTO_INCREMENT,
    nome varchar(20), 
    validade date
);

CREATE TABLE Funcionario (
	ID_Funcionario integer PRIMARY KEY AUTO_INCREMENT,
    nome varchar(20),
    atividade varchar(20)
);

INSERT INTO Cozinha (tipo, horaAbertura, horaFechamento, pratoPrincipal) VALUES ('Chinesa', 9, 21, 'Yakisoba');
INSERT INTO Cozinha (tipo, horaAbertura, horaFechamento, pratoPrincipal) VALUES ('Italina', 11, 19, 'Pizza');
INSERT INTO Cozinha (tipo, horaAbertura, horaFechamento, pratoPrincipal) VALUES ('Japonesa', 15, 22, 'Sushi');
INSERT INTO Cozinha (tipo, horaAbertura, horaFechamento, pratoPrincipal) VALUES ('Mineira', 10, 20, 'Feijoada');
INSERT INTO Cozinha (tipo, horaAbertura, horaFechamento, pratoPrincipal) VALUES ('Arabe', 9, 20, 'Esfirra');

SELECT * FROM Cozinha;

INSERT INTO Ingrediente (nome, validade) VALUES ("Macarrão", '2021-04-25');
INSERT INTO Ingrediente (nome, validade) VALUES ("Tomate", '2021-05-17');
INSERT INTO Ingrediente (nome, validade) VALUES ("Parmesão", '2021-12-25');
INSERT INTO Ingrediente (nome, validade) VALUES ("Carne", '2021-02-02');
INSERT INTO Ingrediente (nome, validade) VALUES ("Feijão", '2021-07-10');
INSERT INTO Ingrediente (nome, validade) VALUES ("Peixe", '2021-10-08');
INSERT INTO Ingrediente (nome, validade) VALUES ("Calabresa", '2021-07-02');
INSERT INTO Ingrediente (nome, validade) VALUES ("Shoyu", '2021-11-11');

SELECT * FROM Ingrediente;

INSERT INTO Funcionario (nome, atividade) VALUES ("João", 'Garçom');
INSERT INTO Funcionario (nome, atividade) VALUES ("Maria", 'Caixa');
INSERT INTO Funcionario (nome, atividade) VALUES ("José", 'Cozinheiro');
INSERT INTO Funcionario (nome, atividade) VALUES ("Marcos", 'Faxineiro');
INSERT INTO Funcionario (nome, atividade) VALUES ("Luis", 'Gerente');
INSERT INTO Funcionario (nome, atividade) VALUES ("Gabriel", 'Garçom');
INSERT INTO Funcionario (nome, atividade) VALUES ("Carlos", 'Cozinheiro');
INSERT INTO Funcionario (nome, atividade) VALUES ("Diogo", 'Cozinheiro');
INSERT INTO Funcionario (nome, atividade) VALUES ("Andre", 'Faxineiro');
INSERT INTO Funcionario (nome, atividade) VALUES ("Pedro", 'Caixa');

SELECT * FROM Funcionario;

SELECT COUNT(*) FROM Cozinha;
SELECT COUNT(*) FROM Cozinha WHERE horaFechamento = 22;
SELECT nome FROM Ingrediente WHERE validade < CURRENT_DATE;

ALTER TABLE Ingrediente ADD fk_cozinha integer;
ALTER TABLE Ingrediente ADD CONSTRAINT id_cozinha_ing 
FOREIGN KEY(fk_cozinha) REFERENCES Cozinha(ID_Cozinha);

ALTER TABLE Funcionario ADD fk_cozinha integer;
ALTER TABLE Funcionario ADD CONSTRAINT id_cozinha_func 
FOREIGN KEY(fk_cozinha) REFERENCES Cozinha(ID_Cozinha);

SELECT tipo FROM Cozinha LEFT JOIN Ingrediente ON Cozinha.ID_Cozinha = Ingrediente.fk_cozinha WHERE Ingrediente.fk_cozinha IS NULL;

SELECT tipo FROM Cozinha INNER JOIN Funcionario ON Cozinha.ID_Cozinha = Funcionario.fk_cozinha GROUP BY fk_cozinha having COUNT(*) > 4;