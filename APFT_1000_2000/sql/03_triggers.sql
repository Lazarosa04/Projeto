
-- Triggers Bombeiros

-- Trigger para verificar NIF único
-- Trigger corrigida
CREATE TRIGGER TRG_Check_NIF_Unico
ON Bombeiro
INSTEAD OF INSERT, UPDATE
AS
BEGIN
    -- Verificar se existe NIF duplicado
    IF EXISTS (
        SELECT 1 FROM Bombeiro b
        JOIN inserted i ON b.NIF = i.NIF AND b.ID_Bombeiro != i.ID_Bombeiro
    )
    BEGIN
        RAISERROR('NIF já existe na base de dados.', 16, 1);
        RETURN;
    END

    -- Inserir ou atualizar os dados corretamente, incluindo o ID_Quartel
    IF EXISTS(SELECT * FROM inserted)
    BEGIN
        MERGE Bombeiro AS target
        USING inserted AS source
        ON target.ID_Bombeiro = source.ID_Bombeiro
        WHEN MATCHED THEN
            UPDATE SET Nome_Bombeiro = source.Nome_Bombeiro,
                       Data_Nascimento = source.Data_Nascimento,
                       Morada = source.Morada,
                       Email = source.Email,
                       NIF = source.NIF,
                       Telemóvel = source.Telemóvel,
                       ID_Quartel = source.ID_Quartel
        WHEN NOT MATCHED THEN
            INSERT (Nome_Bombeiro, Data_Nascimento, Morada, Email, NIF, Telemóvel, ID_Quartel)
            VALUES (source.Nome_Bombeiro, source.Data_Nascimento, source.Morada, source.Email, source.NIF, source.Telemóvel, source.ID_Quartel);
    END
END;
GO


-- Trigger para remoção em cascata
CREATE TRIGGER TRG_Cascade_Delete_Bombeiro
ON Bombeiro
AFTER DELETE
AS
BEGIN
    DELETE FROM Bombeiro_Formação WHERE ID_Bombeiro IN (SELECT ID_Bombeiro FROM deleted);
    DELETE FROM Bombeiro_Ocorrência WHERE ID_Bombeiro IN (SELECT ID_Bombeiro FROM deleted);
    DELETE FROM Bombeiro_Especialização WHERE ID_Bombeiro IN (SELECT ID_Bombeiro FROM deleted);
    DELETE FROM Baixa WHERE ID_Bombeiro IN (SELECT ID_Bombeiro FROM deleted);
    DELETE FROM Férias WHERE ID_Bombeiro IN (SELECT ID_Bombeiro FROM deleted);
END;
GO




-- Triggers para EQUIPAMENTO

-- 1. Impedir quantidade negativa
CREATE TRIGGER TRG_Check_Quantidade_NaoNegativa
ON Equipamento
INSTEAD OF INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE Quantidade < 0)
    BEGIN
        RAISERROR('A quantidade do equipamento não pode ser negativa.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        MERGE Equipamento AS target
        USING inserted AS source
        ON target.ID_Equipamento = source.ID_Equipamento
        WHEN MATCHED THEN
            UPDATE SET Nome_Equipamento = source.Nome_Equipamento,
                       Quantidade = source.Quantidade,
                       ID_Viatura = source.ID_Viatura
        WHEN NOT MATCHED THEN
            INSERT (Nome_Equipamento, Quantidade, ID_Viatura)
            VALUES (source.Nome_Equipamento, source.Quantidade, source.ID_Viatura);
    END
END;
GO


-- Triggers para VIATURA

-- 1. Impedir ano inválido
CREATE TRIGGER TRG_Check_Ano_Valido
ON Viatura
INSTEAD OF INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE Ano < 1980 OR Ano > YEAR(GETDATE()))
    BEGIN
        RAISERROR('Ano da viatura inválido.', 16, 1);
        RETURN;
    END

    -- Inserção ou atualização conforme necessário
    IF EXISTS(SELECT * FROM inserted)
    BEGIN
        MERGE Viatura AS target
        USING inserted AS source
        ON target.ID_Viatura = source.ID_Viatura
        WHEN MATCHED THEN
            UPDATE SET ID_TipoViatura = source.ID_TipoViatura,
                       Matricula = source.Matricula,
                       Ano = source.Ano
        WHEN NOT MATCHED THEN
            INSERT (ID_Quartel, ID_TipoViatura, Matricula, Ano)
            VALUES (source.ID_Quartel, source.ID_TipoViatura, source.Matricula, source.Ano);
    END
END;
GO


CREATE TRIGGER TRG_Check_DataHora_Futura
ON Chamada
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted WHERE Data_Hora_Chamada > GETDATE()
    )
    BEGIN
        RAISERROR('A data/hora da chamada não pode ser futura.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

