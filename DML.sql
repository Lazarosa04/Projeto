USE QuartelBombeiros;

-- TipoViatura (s� dois tipos)
INSERT INTO TipoViatura (ID_TipoViatura, Nome_TipoViatura) VALUES
(1, 'Ligeiro'),
(2, 'Pesado');

-- Quartel (apenas um, com ID fixo 11111)
INSERT INTO Quartel (ID_Quartel, Nome_Quartel, Endere�o, Telefone) VALUES
(11111, 'Quartel Central', 'Rua Principal, 123', '12345678901');

-- Viatura (ligado ao quartel 11111 e aos dois tipos)
INSERT INTO Viatura (ID_Quartel, ID_TipoViatura, Matricula, Ano) VALUES
(11111, 1, 'AA-12-BB', 2018),
(11111, 2, 'CC-34-DD', 2020),
(11111, 1, 'EE-56-FF', 2019),
(11111, 2, 'GG-78-HH', 2017),
(11111, 1, 'II-90-JJ', 2021);

-- Equipamento (tudo ligado ao quartel 11111 e viaturas inseridas)
INSERT INTO Equipamento (ID_Quartel, ID_Viatura, Nome_Equipamento, Quantidade) VALUES
(11111, 1, 'Mangueira', 10),
(11111, 2, 'Extintor', 5),
(11111, 3, 'Serra El�trica', 2),
(11111, 4, 'Lanterna', 8),
(11111, 5, 'Kit Primeiros Socorros', 4);

-- Manuten��o (ligada a viaturas ou equipamentos)
INSERT INTO Manuten��o (ID_Viatura, ID_Equipamento, Data_Manuten��o, Descri��o) VALUES
(1, NULL, '2025-05-01', 'Revis�o geral do motor'),
(NULL, 1, '2025-04-15', 'Substitui��o da mangueira principal'),
(2, NULL, '2025-03-20', 'Troca dos pneus'),
(NULL, 3, '2025-02-10', 'Manuten��o da serra el�trica'),
(3, NULL, '2025-01-05', 'Limpeza completa do ve�culo');


-- Bombeiro (vinculado ao quartel 11111)
INSERT INTO Bombeiro (ID_Quartel, Nome_Bombeiro, Data_Nascimento, Morada, Email, NIF, Telem�vel) VALUES
(11111, 'Jo�o Silva', '1985-03-15', 'Rua das Flores, 10', 'joao.silva@email.com', '123456789', '912345678'),
(11111, 'Maria Santos', '1990-07-22', 'Avenida Central, 55', 'maria.santos@email.com', '987654321', '923456789'),
(11111, 'Carlos Pereira', '1982-11-05', 'Rua do Sol, 23', 'carlos.pereira@email.com', '456123789', '934567890'),
(11111, 'Ana Costa', '1995-01-30', 'Travessa Alegre, 12', 'ana.costa@email.com', '789456123', '945678901'),
(11111, 'Pedro Alves', '1988-09-14', 'Rua Nova, 77', 'pedro.alves@email.com', '321654987', '956789012');


-- F�rias (para alguns bombeiros)
INSERT INTO F�rias (ID_Bombeiro, Data_Inicio, Data_Fim) VALUES
(1, '2025-07-01', '2025-07-15'),
(2, '2025-08-10', '2025-08-20'),
(3, '2025-12-01', '2025-12-10'),
(4, '2025-06-05', '2025-06-15'),
(5, '2025-09-01', '2025-09-10');

-- Baixa (para alguns bombeiros)
INSERT INTO Baixa (ID_Bombeiro, Data_Inicio, Data_Fim, Raz�o) VALUES
(2, '2025-05-01', '2025-05-10', 'Gripe forte'),
(4, '2025-06-20', '2025-06-30', 'Les�o no bra�o'),
(1, '2025-03-15', '2025-03-20', 'Consulta m�dica'),
(3, '2025-04-25', '2025-05-05', 'Cirurgia menor'),
(5, '2025-07-10', '2025-07-20', 'Recupera��o');

-- Ocorr�ncia (vinculada ao quartel 11111)
INSERT INTO Ocorr�ncia (ID_Quartel, Data_Hora) VALUES
(11111, '2025-05-10 14:30'),
(11111, '2025-05-15 09:00'),
(11111, '2025-06-01 18:45'),
(11111, '2025-06-05 23:15'),
(11111, '2025-06-10 08:30');

-- Bombeiro_Ocorr�ncia (v�rios bombeiros em ocorr�ncias)
INSERT INTO Bombeiro_Ocorr�ncia (ID_Ocorr�ncia, ID_Bombeiro) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 1),
(3, 5),
(4, 2),
(4, 3),
(5, 4),
(5, 5);

-- Viatura_Ocorr�ncia (v�rias viaturas em ocorr�ncias)
INSERT INTO Viatura_Ocorr�ncia (ID_Ocorr�ncia, ID_Viatura) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 1);

-- Chamada (vinculada �s ocorr�ncias)
INSERT INTO Chamada (ID_Ocorr�ncia, Origem, Descri��o, Nome, Data_Hora_Chamada, Localiza��o, N�mero) VALUES
(1, 0x00, 'Inc�ndio numa habita��o', 'Jo�o', '2025-05-10 14:20', 'Rua das Flores, 10', '912345678'),
(2, 0x01, 'Acidente rodovi�rio', 'Maria', '2025-05-15 08:50', 'Avenida Central, 100', '923456789'),
(3, 0x00, 'Alarme falso', 'Carlos', '2025-06-01 18:30', 'Rua do Sol, 25', '934567890'),
(4, 0x01, 'Inc�ndio florestal', 'Ana', '2025-06-05 23:00', 'Zona Rural', '945678901'),
(5, 0x00, 'Pedido de ajuda m�dica', 'Pedro', '2025-06-6 08:15', 'Rua Nova, 80', '956789012');

INSERT INTO Especializa��o (Nome_Especializa��o) VALUES
('Inc�ndio Urbanos'),
('Inc�ndios Florestais'),
('Salvamento e Desencarceramento'),
('Salvamento Aqu�tico'),
('Forma��o e Treinamento'),
('Comando e Gest�o');

-- Bombeiro 1
INSERT INTO Bombeiro_Especializa��o (ID_Bombeiro, ID_Especializa��o) VALUES
(1, 1), -- Inc�ndio Urbanos
(1, 3); -- Salvamento e Desencarceramento

-- Bombeiro 2
INSERT INTO Bombeiro_Especializa��o (ID_Bombeiro, ID_Especializa��o) VALUES
(2, 2), -- Inc�ndios Florestais
(2, 4); -- Salvamento Aqu�tico

-- Bombeiro 3
INSERT INTO Bombeiro_Especializa��o (ID_Bombeiro, ID_Especializa��o) VALUES
(3, 5), -- Forma��o e Treinamento
(3, 6); -- Comando e Gest�o

-- Bombeiro 4
INSERT INTO Bombeiro_Especializa��o (ID_Bombeiro, ID_Especializa��o) VALUES
(4, 1), -- Inc�ndio Urbanos
(4, 2); -- Inc�ndios Florestais

-- Bombeiro 5
INSERT INTO Bombeiro_Especializa��o (ID_Bombeiro, ID_Especializa��o) VALUES
(5, 3), -- Salvamento e Desencarceramento
(5, 4); -- Salvamento Aqu�tico





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

