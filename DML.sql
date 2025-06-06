
-- TipoViatura
INSERT INTO TipoViatura (ID_TipoViatura, Nome_TipoViatura) VALUES 
(1, 'Ligeiro'), 
(2, 'Pesado');

-- Quartel
INSERT INTO Quartel (ID_Quartel, Nome_Quartel, Endere�o, Telefone) VALUES
(11111, 'Quartel Central', 'Rua dos Bombeiros 123, Cidade', '234567890');

-- Viatura
INSERT INTO Viatura (ID_Quartel, ID_TipoViatura, Matricula, Ano) VALUES
(11111, 1, '12-34-AB', 2020),
(11111, 2, '56-78-CD', 2018),
(11111, 1, '88-99-XP', 2022),
(11111, 2, '77-66-KL', 2019),
(11111, 1, '45-12-MN', 2020);

-- Equipamento
INSERT INTO Equipamento (ID_Quartel, ID_Viatura, Nome_Equipamento, Quantidade) VALUES
(11111, 1, 'Extintor de P� Qu�mico', 2),
(11111, 2, 'Mangueira Alta Press�o', 3),
(11111, 1, 'Lanterna LED', 5),
(11111, 2, 'Gerador El�trico', 1),
(11111, 1, 'Mochila de Primeiros Socorros', 4);

-- Manuten��o
INSERT INTO Manuten��o (ID_Viatura, ID_Equipamento, Data_Manuten��o, Descri��o) VALUES
(1, 1, '2024-01-15', 'Revis�o geral do extintor');

-- Bombeiro
INSERT INTO Bombeiro (ID_Quartel, Nome_Bombeiro, Data_Nascimento, Morada, Email, NIF, Telem�vel) VALUES
(11111, 'Jo�o Silva', '1990-05-21', 'Rua A', 'joao@example.com', '123456789', '912345678'),
(11111, 'Ana Costa', '1985-10-02', 'Rua B', 'ana@example.com', '987654321', '919876543'),
(11111, 'Carlos Mendes', '1980-03-15', 'Rua das �rvores, 10', 'carlos@bombeiros.pt', '111222333', '918000111'),
(11111, 'Sofia Lopes', '1992-07-30', 'Avenida Central, 22', 'sofia@bombeiros.pt', '444555666', '917000222'),
(11111, 'Tiago Reis', '1988-11-09', 'Travessa Azul, 5', 'tiago@bombeiros.pt', '777888999', '916000333');

-- Forma��o
INSERT INTO Forma��o (ID_Quartel, Data_Inicio, Data_Fim) VALUES
(11111, '2023-01-10', '2023-01-20'),
(11111, '2023-03-05', '2023-03-15'),
(11111, '2023-06-01', '2023-06-12'),
(11111, '2023-08-18', '2023-08-28'),
(11111, '2023-11-10', '2023-11-20');

-- Bombeiro_Forma��o
INSERT INTO Bombeiro_Forma��o (ID_Bombeiro, ID_Forma��o) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(5, 5);

-- Especializa��o
INSERT INTO Especializa��o (Nome_Especializa��o) VALUES
('Salvamento em Altura'),
('Combate a Inc�ndios Urbanos'),
('Desencarceramento'),
('Resgate Aqu�tico'),
('Primeiros Socorros Avan�ados');

-- Bombeiro_Especializa��o
INSERT INTO Bombeiro_Especializa��o (ID_Bombeiro, ID_Especializa��o) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

-- F�rias
INSERT INTO F�rias (ID_Bombeiro, Data_Inicio, Data_Fim) VALUES
(1, '2024-07-01', '2024-07-15'),
(2, '2024-08-01', '2024-08-10'),
(3, '2024-09-05', '2024-09-20'),
(4, '2024-07-20', '2024-07-30'),
(5, '2024-10-01', '2024-10-15');

-- Baixa
INSERT INTO Baixa (ID_Bombeiro, Data_Inicio, Data_Fim, Raz�o) VALUES
(1, '2024-01-10', '2024-01-15', 'Les�o muscular'),
(2, '2024-02-05', '2024-02-12', 'Doen�a respirat�ria'),
(3, '2024-03-01', '2024-03-07', 'Problemas lombares'),
(4, '2024-04-15', '2024-04-22', 'Cirurgia dent�ria'),
(5, '2024-05-10', '2024-05-18', 'Doen�a viral');

-- Ocorr�ncia
INSERT INTO Ocorr�ncia (ID_Quartel, Data_Hora) VALUES
(11111, '2024-06-01 08:30:00'),
(11111, '2024-06-02 14:15:00'),
(11111, '2024-06-03 19:45:00'),
(11111, '2024-06-04 11:00:00'),
(11111, '2024-06-05 23:10:00');

-- Bombeiro_Ocorr�ncia
INSERT INTO Bombeiro_Ocorr�ncia (ID_Ocorr�ncia, ID_Bombeiro) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(4, 5);

-- Viatura_Ocorr�ncia
INSERT INTO Viatura_Ocorr�ncia (ID_Ocorr�ncia, ID_Viatura) VALUES
(1, 1),
(1, 2),
(2, 1),
(3, 2),
(4, 1);

-- Chamada
INSERT INTO Chamada (ID_Ocorr�ncia, Origem, Descri��o, Nome, Data_Hora_Chamada, Localiza��o, N�mero) VALUES
(1, 0x00, 'Inc�ndio em resid�ncia', 'Jos� Martins', '2024-06-01 08:15:00', 'Rua Central, 10', '931111111'),
(2, 0x01, 'Acidente de via��o', 'Paula Dias', '2024-06-02 14:00:00', 'Avenida Sul, 200', '932222222'),
(3, 0x00, 'Fogo florestal', 'Rui Costa', '2024-06-03 19:30:00', 'Serra do Norte', '933333333'),
(4, 0x01, 'Desabamento de estrutura', 'Carla Lopes', '2024-06-04 10:50:00', 'Rua da Pedra, 87', '934444444'),
(5, 0x00, 'Resgate aqu�tico', 'Luis Pinho', '2024-06-05 23:00:00', 'Praia Azul', '935555555');



-- Desativa temporariamente restri��es de chave estrangeira
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

-- Apaga os dados das tabelas
DELETE FROM Viatura_Ocorr�ncia;
DELETE FROM Bombeiro_Ocorr�ncia;
DELETE FROM Chamada;
DELETE FROM Ocorr�ncia;
DELETE FROM Baixa;
DELETE FROM F�rias;
DELETE FROM Bombeiro_Especializa��o;
DELETE FROM Bombeiro_Forma��o;
DELETE FROM Forma��o;
DELETE FROM Especializa��o;
DELETE FROM Manuten��o;
DELETE FROM Equipamento;
DELETE FROM Viatura;
DELETE FROM Bombeiro;
DELETE FROM Quartel;
DELETE FROM TipoViatura;

-- Reativa as restri��es de chave estrangeira
EXEC sp_msforeachtable "ALTER TABLE ? CHECK CONSTRAINT ALL";

-- Resetar contadores de IDENTITY (opcional)
DBCC CHECKIDENT ('Viatura', RESEED, 0);
DBCC CHECKIDENT ('Equipamento', RESEED, 0);
DBCC CHECKIDENT ('Manuten��o', RESEED, 0);
DBCC CHECKIDENT ('Bombeiro', RESEED, 0);
DBCC CHECKIDENT ('Forma��o', RESEED, 0);
DBCC CHECKIDENT ('Especializa��o', RESEED, 0);
DBCC CHECKIDENT ('Ocorr�ncia', RESEED, 0);
DBCC CHECKIDENT ('Chamada', RESEED, 0);

