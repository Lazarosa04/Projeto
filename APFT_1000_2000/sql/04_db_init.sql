USE QuartelBombeiros;

-- TipoViatura (só dois tipos)
INSERT INTO TipoViatura (ID_TipoViatura, Nome_TipoViatura) VALUES
(1, 'Ligeiro'),
(2, 'Pesado');

-- Quartel (apenas um, com ID fixo 11111)
INSERT INTO Quartel (ID_Quartel, Nome_Quartel, Endereço, Telefone) VALUES
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
(11111, 3, 'Serra Elétrica', 2),
(11111, 4, 'Lanterna', 8),
(11111, 5, 'Kit Primeiros Socorros', 4);

-- Manutenção (ligada a viaturas ou equipamentos)
INSERT INTO Manutenção (ID_Viatura, ID_Equipamento, Data_Manutenção, Descrição) VALUES
(1, NULL, '2025-05-01', 'Revisão geral do motor'),
(NULL, 1, '2025-04-15', 'Substituição da mangueira principal'),
(2, NULL, '2025-03-20', 'Troca dos pneus'),
(NULL, 3, '2025-02-10', 'Manutenção da serra elétrica'),
(3, NULL, '2025-01-05', 'Limpeza completa do veículo');

-- Bombeiro (vinculado ao quartel 11111)
INSERT INTO Bombeiro (ID_Quartel, Nome_Bombeiro, Data_Nascimento, Morada, Email, NIF, Telemóvel) VALUES
(11111, 'João Silva', '1985-03-15', 'Rua das Flores, 10', 'joao.silva@email.com', '123456789', '912345678'),
(11111, 'Maria Santos', '1990-07-22', 'Avenida Central, 55', 'maria.santos@email.com', '987654321', '923456789'),
(11111, 'Carlos Pereira', '1982-11-05', 'Rua do Sol, 23', 'carlos.pereira@email.com', '456123789', '934567890'),
(11111, 'Ana Costa', '1995-01-30', 'Travessa Alegre, 12', 'ana.costa@email.com', '789456123', '945678901'),
(11111, 'Pedro Alves', '1988-09-14', 'Rua Nova, 77', 'pedro.alves@email.com', '321654987', '956789012');

-- Férias (para alguns bombeiros)
INSERT INTO Férias (ID_Bombeiro, Data_Inicio, Data_Fim) VALUES
(1, '2025-07-01', '2025-07-15'),
(2, '2025-08-10', '2025-08-20'),
(3, '2025-12-01', '2025-12-10'),
(4, '2025-06-05', '2025-06-15'),
(5, '2025-09-01', '2025-09-10');

-- Baixa (para alguns bombeiros)
INSERT INTO Baixa (ID_Bombeiro, Data_Inicio, Data_Fim, Razão) VALUES
(2, '2025-05-01', '2025-05-10', 'Gripe forte'),
(4, '2025-06-20', '2025-06-30', 'Lesão no braço'),
(1, '2025-03-15', '2025-03-20', 'Consulta médica'),
(3, '2025-04-25', '2025-05-05', 'Cirurgia menor'),
(5, '2025-07-10', '2025-07-20', 'Recuperação');

-- Ocorrência (vinculada ao quartel 11111)
INSERT INTO Ocorrência (ID_Quartel, Data_Hora) VALUES
(11111, '2025-05-10 14:30'),
(11111, '2025-05-15 09:00'),
(11111, '2025-06-01 18:45'),
(11111, '2025-06-05 23:15'),
(11111, '2025-06-10 08:30');

-- Bombeiro_Ocorrência (vários bombeiros em ocorrências)
INSERT INTO Bombeiro_Ocorrência (ID_Ocorrência, ID_Bombeiro) VALUES
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

-- Viatura_Ocorrência (várias viaturas em ocorrências)
INSERT INTO Viatura_Ocorrência (ID_Ocorrência, ID_Viatura) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 1);

-- Chamada (vinculada às ocorrências)
INSERT INTO Chamada (ID_Ocorrência, Origem, Descrição, Nome, Data_Hora_Chamada, Localização, Número) VALUES
(1, 0x00, 'Incêndio numa habitação', 'João', '2025-05-10 14:20', 'Rua das Flores, 10', '912345678'),
(2, 0x01, 'Acidente rodoviário', 'Maria', '2025-05-15 08:50', 'Avenida Central, 100', '923456789'),
(3, 0x00, 'Alarme falso', 'Carlos', '2025-06-01 18:30', 'Rua do Sol, 25', '934567890'),
(4, 0x01, 'Incêndio florestal', 'Ana', '2025-06-05 23:00', 'Zona Rural', '945678901'),
(5, 0x00, 'Pedido de ajuda médica', 'Pedro', '2025-06-06 08:15', 'Rua Nova, 80', '956789012');

-- Especializações
INSERT INTO Especialização (Nome_Especialização) VALUES
('Incêndio Urbanos'),
('Incêndios Florestais'),
('Salvamento e Desencarceramento'),
('Salvamento Aquático'),
('Formação e Treinamento'),
('Comando e Gestão');

-- Bombeiro 1
INSERT INTO Bombeiro_Especialização (ID_Bombeiro, ID_Especialização) VALUES
(1, 1),
(1, 3);

-- Bombeiro 2
INSERT INTO Bombeiro_Especialização (ID_Bombeiro, ID_Especialização) VALUES
(2, 2),
(2, 4);

-- Bombeiro 3
INSERT INTO Bombeiro_Especialização (ID_Bombeiro, ID_Especialização) VALUES
(3, 5),
(3, 6);

-- Bombeiro 4
INSERT INTO Bombeiro_Especialização (ID_Bombeiro, ID_Especialização) VALUES
(4, 1),
(4, 2);

-- Bombeiro 5
INSERT INTO Bombeiro_Especialização (ID_Bombeiro, ID_Especialização) VALUES
(5, 3),
(5, 4);

-- Desativa temporariamente restrições de chave estrangeira
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

-- Apaga os dados das tabelas
DELETE FROM Viatura_Ocorrência;
DELETE FROM Bombeiro_Ocorrência;
DELETE FROM Chamada;
DELETE FROM Ocorrência;
DELETE FROM Baixa;
DELETE FROM Férias;
DELETE FROM Bombeiro_Especialização;
DELETE FROM Bombeiro_Formação;
DELETE FROM Formação;
DELETE FROM Especialização;
DELETE FROM Manutenção;
DELETE FROM Equipamento;
DELETE FROM Viatura;
DELETE FROM Bombeiro;
DELETE FROM Quartel;
DELETE FROM TipoViatura;

-- Reativa as restrições de chave estrangeira
EXEC sp_msforeachtable "ALTER TABLE ? CHECK CONSTRAINT ALL";

-- Resetar contadores de IDENTITY (opcional)
DBCC CHECKIDENT ('Viatura', RESEED, 0);
DBCC CHECKIDENT ('Equipamento', RESEED, 0);
DBCC CHECKIDENT ('Manutenção', RESEED, 0);
DBCC CHECKI
