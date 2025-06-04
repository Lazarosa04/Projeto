
-- Stored Procedures Bombeiro

-- 1. Adicionar Bombeiro
CREATE PROCEDURE spAdicionarBombeiro
    @Nome NVARCHAR(100),
    @DataNascimento DATE,
    @Morada NVARCHAR(200),
    @Email NVARCHAR(100),
    @NIF NVARCHAR(20),
    @Telemovel NVARCHAR(20)
AS
BEGIN
    INSERT INTO Bombeiro (Nome_Bombeiro, Data_Nascimento, Morada, Email, NIF, Telemóvel)
    VALUES (@Nome, @DataNascimento, @Morada, @Email, @NIF, @Telemovel);
END;
GO

-- 2. Atualizar Bombeiro
CREATE PROCEDURE spAtualizarBombeiro
    @Id INT,
    @Nome NVARCHAR(100),
    @DataNascimento DATE,
    @Morada NVARCHAR(200),
    @Email NVARCHAR(100),
    @NIF NVARCHAR(20),
    @Telemovel NVARCHAR(20)
AS
BEGIN
    UPDATE Bombeiro
    SET Nome_Bombeiro = @Nome,
        Data_Nascimento = @DataNascimento,
        Morada = @Morada,
        Email = @Email,
        NIF = @NIF,
        Telemóvel = @Telemovel
    WHERE ID_Bombeiro = @Id;
END;
GO

-- 3. Remover Bombeiro
CREATE PROCEDURE spRemoverBombeiro
    @Id INT
AS
BEGIN
    DELETE FROM Bombeiro_Formação WHERE ID_Bombeiro = @Id;
    DELETE FROM Bombeiro_Ocorrência WHERE ID_Bombeiro = @Id;
    DELETE FROM Bombeiro_Especialização WHERE ID_Bombeiro = @Id;
    DELETE FROM Baixa WHERE ID_Bombeiro = @Id;
    DELETE FROM Férias WHERE ID_Bombeiro = @Id;
    DELETE FROM Bombeiro WHERE ID_Bombeiro = @Id;
END;
GO

-- 4. Listar Bombeiros
CREATE PROCEDURE spListarBombeiros
AS
BEGIN
    SELECT ID_Bombeiro, Nome_Bombeiro, Data_Nascimento, Morada, Email, NIF, Telemóvel
    FROM Bombeiro
    ORDER BY Nome_Bombeiro;
END;
GO


-- Stored Procedures para CHAMADA

-- 1. Adicionar chamada
CREATE PROCEDURE spAdicionarChamada
    @Nome NVARCHAR(100),
    @Descricao NVARCHAR(MAX),
    @DataHora DATETIME,
    @Numero NVARCHAR(20),
    @Localizacao NVARCHAR(200),
    @Origem INT
AS
BEGIN
    INSERT INTO Chamada (Nome, [Descrição], Data_Hora_Chamada, [Número], [Localização], Origem)
    VALUES (@Nome, @Descricao, @DataHora, @Numero, @Localizacao, @Origem);
END;
GO

-- 2. Remover chamada
CREATE PROCEDURE spRemoverChamada
    @Id INT
AS
BEGIN
    DELETE FROM Chamada WHERE ID_Chamada = @Id;
END;
GO

-- 3. Listar chamadas
CREATE PROCEDURE spListarChamadas
AS
BEGIN
    SELECT * FROM Chamada ORDER BY Data_Hora_Chamada DESC;
END;
GO


-- Stored Procedures para EQUIPAMENTO

-- 1. Adicionar equipamento
CREATE PROCEDURE spAdicionarEquipamentoViatura
    @Nome NVARCHAR(100),
    @Quantidade INT,
    @ID_Viatura INT
AS
BEGIN
    INSERT INTO Equipamento (Nome_Equipamento, Quantidade, ID_Viatura)
    VALUES (@Nome, @Quantidade, @ID_Viatura);
END;
GO

CREATE PROCEDURE spAdicionarEquipamento
    @Nome NVARCHAR(100),
    @Quantidade INT
AS
BEGIN
    INSERT INTO Equipamento (Nome_Equipamento, Quantidade)
    VALUES (@Nome, @Quantidade);
END;
GO

-- 2. Remover equipamento
CREATE PROCEDURE spRemoverEquipamento
    @ID INT
AS
BEGIN
    DELETE FROM Equipamento WHERE ID_Equipamento = @ID;
END;
GO

-- 3. Listar equipamentos (atualizada para incluir equipamentos sem viatura associada)
CREATE OR ALTER PROCEDURE spListarEquipamentos
AS
BEGIN
    SELECT 
        e.ID_Equipamento, 
        e.Nome_Equipamento, 
        e.Quantidade, 
        v.Matricula, 
        v.ID_Viatura
    FROM Equipamento e
    LEFT JOIN Viatura v ON e.ID_Viatura = v.ID_Viatura
    ORDER BY e.Nome_Equipamento;
END;
GO

--4. Editar equipamentos
CREATE OR ALTER PROCEDURE spEditarEquipamento
    @ID_Equipamento INT,
    @Nome NVARCHAR(100),
    @Quantidade INT,
    @ID_Viatura INT = NULL
AS
BEGIN
    UPDATE Equipamento
    SET Nome_Equipamento = @Nome,
        Quantidade = @Quantidade,
        ID_Viatura = @ID_Viatura
    WHERE ID_Equipamento = @ID_Equipamento;
END;
GO





-- Stored Procedures para OCORRÊNCIA

CREATE OR ALTER PROCEDURE spAdicionarOcorrenciaCompleta
    @ID_Quartel INT,
    @DataHora DATETIME,
    @ID_Chamada INT,
    @Bombeiros VARCHAR(MAX), -- IDs separados por vírgula
    @Viaturas VARCHAR(MAX)   -- IDs separados por vírgula
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ID_Ocorrencia INT;

        -- 1. Inserir ocorrência
        INSERT INTO Ocorrência (ID_Quartel, Data_Hora)
        VALUES (@ID_Quartel, @DataHora);

        SET @ID_Ocorrencia = SCOPE_IDENTITY();

        -- 2. Atualizar chamada
        UPDATE Chamada SET ID_Ocorrência = @ID_Ocorrencia WHERE ID_Chamada = @ID_Chamada;

        -- 3. Limpar associações existentes (se necessário)
        DELETE FROM Bombeiro_Ocorrência WHERE ID_Ocorrência = @ID_Ocorrencia;
        DELETE FROM Viatura_Ocorrência WHERE ID_Ocorrência = @ID_Ocorrencia;

        -- 4. Inserir associações de bombeiros
        IF (LEN(@Bombeiros) > 0)
        BEGIN
            DECLARE @xmlBombeiros XML = CAST('<i>' + REPLACE(@Bombeiros, ',', '</i><i>') + '</i>' AS XML);

            INSERT INTO Bombeiro_Ocorrência (ID_Ocorrência, ID_Bombeiro)
            SELECT @ID_Ocorrencia, x.i.value('.', 'INT')
            FROM @xmlBombeiros.nodes('i') AS x(i);
        END

        -- 5. Inserir associações de viaturas
        IF (LEN(@Viaturas) > 0)
        BEGIN
            DECLARE @xmlViaturas XML = CAST('<i>' + REPLACE(@Viaturas, ',', '</i><i>') + '</i>' AS XML);

            INSERT INTO Viatura_Ocorrência (ID_Ocorrência, ID_Viatura)
            SELECT @ID_Ocorrencia, x.i.value('.', 'INT')
            FROM @xmlViaturas.nodes('i') AS x(i);
        END

        COMMIT TRANSACTION;

        -- Retorna o ID da nova ocorrência
        SELECT @ID_Ocorrencia AS NovaOcorrenciaID;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO


-- 2. Remover ocorrência (sem apagar chamadas)
CREATE PROCEDURE spRemoverOcorrenciaCompleta
    @ID_Ocorrencia INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Remover ligações de bombeiros
        DELETE FROM Bombeiro_Ocorrência WHERE ID_Ocorrência = @ID_Ocorrencia;

        -- 2. Remover ligações de viaturas
        DELETE FROM Viatura_Ocorrência WHERE ID_Ocorrência = @ID_Ocorrencia;

        -- 3. Desvincular chamadas
        UPDATE Chamada SET ID_Ocorrência = NULL WHERE ID_Ocorrência = @ID_Ocorrencia;

        -- 4. Apagar ocorrência
        DELETE FROM Ocorrência WHERE ID_Ocorrência = @ID_Ocorrencia;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO


-- 3. Listar ocorrências
CREATE PROCEDURE spListarOcorrencias
AS
BEGIN
    SELECT o.ID_Ocorrência, d.Descrição, d.Localização, d.Nome, d.Número, o.Data_Hora
    FROM Ocorrência o
    INNER JOIN Chamada d ON o.ID_Ocorrência = d.ID_Ocorrência
    ORDER BY o.Data_Hora DESC;
END;
GO



-- Stored Procedures para VIATURA

-- 1. Adicionar viatura
CREATE PROCEDURE spAdicionarViatura
    @ID_Quartel INT,
    @ID_TipoViatura INT,
    @Matricula NVARCHAR(20),
    @Ano INT
AS
BEGIN
    INSERT INTO Viatura (ID_Quartel, ID_TipoViatura, Matricula, Ano)
    VALUES (@ID_Quartel, @ID_TipoViatura, @Matricula, @Ano);
END;
GO

-- 2. Editar viatura
CREATE PROCEDURE spEditarViatura
    @ID INT,
    @ID_TipoViatura INT,
    @Matricula NVARCHAR(20),
    @Ano INT
AS
BEGIN
    UPDATE Viatura
    SET ID_TipoViatura = @ID_TipoViatura,
        Matricula = @Matricula,
        Ano = @Ano
    WHERE ID_Viatura = @ID;
END;
GO

-- 3. Remover viatura
CREATE PROCEDURE spRemoverViatura
    @ID INT
AS
BEGIN
    DELETE FROM Viatura_Ocorrência WHERE ID_Viatura = @ID;
    DELETE FROM Manutenção WHERE ID_Viatura = @ID;
    UPDATE Equipamento SET ID_Viatura = NULL WHERE ID_Viatura = @ID;
    DELETE FROM Viatura WHERE ID_Viatura = @ID;
END;
GO


DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'DROP PROCEDURE [' + SCHEMA_NAME(schema_id) + '].[' + name + '];' + CHAR(13)
FROM sys.procedures;

EXEC sp_executesql @sql;
