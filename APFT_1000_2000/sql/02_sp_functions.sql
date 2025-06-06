
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


--4. Editar chamadas
CREATE PROCEDURE spEditarChamada
    @ID_Chamada INT,
    @Nome NVARCHAR(100),
    @Descricao NVARCHAR(MAX),
    @DataHora DATETIME,
    @Numero NVARCHAR(20),
    @Localizacao NVARCHAR(100),
    @Origem BIT
AS
BEGIN
    UPDATE Chamada
    SET Nome = @Nome,
        Descrição = @Descricao,
        Data_Hora_Chamada = @DataHora,
        Número = @Numero,
        Localização = @Localizacao,
        Origem = @Origem
    WHERE ID_Chamada = @ID_Chamada;
END;



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

--4. Editar ocorrência
CREATE PROCEDURE spEditarOcorrenciaCompleta
    @ID_Ocorrencia INT,
    @ID_Quartel INT,
    @DataHora DATETIME,
    @ID_Chamada INT,
    @ListaBombeiros NVARCHAR(MAX),
    @ListaViaturas NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Atualizar dados da ocorrência
        UPDATE Ocorrência
        SET ID_Quartel = @ID_Quartel,
            Data_Hora = @DataHora
        WHERE ID_Ocorrência = @ID_Ocorrencia;

        -- 2. Atualizar ligação à chamada
        UPDATE Chamada
        SET ID_Ocorrência = NULL
        WHERE ID_Ocorrência = @ID_Ocorrencia;

        UPDATE Chamada
        SET ID_Ocorrência = @ID_Ocorrencia
        WHERE ID_Chamada = @ID_Chamada;

        -- 3. Atualizar bombeiros
        DELETE FROM Bombeiro_Ocorrência WHERE ID_Ocorrência = @ID_Ocorrencia;

        DECLARE @xmlB NVARCHAR(MAX) = '<root><id>' + REPLACE(@ListaBombeiros, ',', '</id><id>') + '</id></root>';
        INSERT INTO Bombeiro_Ocorrência (ID_Ocorrência, ID_Bombeiro)
        SELECT @ID_Ocorrencia, T.N.value('.', 'INT')
        FROM (SELECT CAST(@xmlB AS XML) AS xmlData) AS X
        CROSS APPLY xmlData.nodes('/root/id') AS T(N);

        -- 4. Atualizar viaturas
        DELETE FROM Viatura_Ocorrência WHERE ID_Ocorrência = @ID_Ocorrencia;

        DECLARE @xmlV NVARCHAR(MAX) = '<root><id>' + REPLACE(@ListaViaturas, ',', '</id><id>') + '</id></root>';
        INSERT INTO Viatura_Ocorrência (ID_Ocorrência, ID_Viatura)
        SELECT @ID_Ocorrencia, T.N.value('.', 'INT')
        FROM (SELECT CAST(@xmlV AS XML) AS xmlData) AS X
        CROSS APPLY xmlData.nodes('/root/id') AS T(N);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
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

--Adicionar Baixa
CREATE or ALTER PROCEDURE spAdicionarBaixa
    @ID_Bombeiro INT,
    @Data_Inicio DATE,
    @Data_Fim DATE,
    @Razao NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Baixa (ID_Bombeiro, Data_Inicio, Data_Fim, Razão)
    VALUES (@ID_Bombeiro, @Data_Inicio, @Data_Fim, @Razao);
END

--Listar baixas
CREATE or ALTER PROCEDURE spListarBaixasPorBombeiro
    @idBombeiro INT
AS
BEGIN
    SELECT ID_Baixa, Data_Inicio, Data_Fim, Razão
    FROM Baixa
    WHERE ID_Bombeiro = @idBombeiro
    ORDER BY Data_Inicio DESC
END

--remover baixa
CREATE PROCEDURE spRemoverBaixa
    @ID_Baixa INT
AS
BEGIN
    DELETE FROM Baixa
    WHERE ID_Baixa = @ID_Baixa;
END;

--Adicionar Férias
CREATE or alter PROCEDURE AdicionarFerias
    @ID_Bombeiro INT,
    @Data_Inicio DATE,
    @Data_Fim DATE
AS
BEGIN
    IF @Data_Fim < @Data_Inicio
    BEGIN
        RAISERROR('A data de fim não pode ser anterior à data de início.', 16, 1);
        RETURN;
    END

    INSERT INTO Férias (ID_Bombeiro, Data_Inicio, Data_Fim)
    VALUES (@ID_Bombeiro, @Data_Inicio, @Data_Fim);
END;

--Remover Férias
CREATE or alter PROCEDURE RemoverFerias
    @ID_Ferias INT
AS
BEGIN
    DELETE FROM Férias
    WHERE ID_Férias = @ID_Ferias;
END;

--Listar férias
CREATE or alter PROCEDURE spListarFeriasPorBombeiro
    @idBombeiro INT
AS
BEGIN
    SELECT 
        ID_Férias,
        Data_Inicio,
        Data_Fim
    FROM Férias
    WHERE ID_Bombeiro = @idBombeiro
    ORDER BY Data_Inicio DESC;
END;

--lista manutenções da viatura
CREATE PROCEDURE spListarManutencoesPorViatura
    @ID_Viatura INT
AS
BEGIN
    SELECT ID_Manutenção, ID_Viatura, ID_Equipamento, Data_Manutenção, Descrição
    FROM Manutenção
    WHERE ID_Viatura = @ID_Viatura
    ORDER BY Data_Manutenção DESC;
END


--lista manutenções do equipamento
CREATE PROCEDURE spListarManutencoesPorEquipamento
    @ID_Equipamento INT
AS
BEGIN
    SELECT ID_Manutenção, ID_Viatura, ID_Equipamento, Data_Manutenção, Descrição
    FROM Manutenção
    WHERE ID_Equipamento = @ID_Equipamento
    ORDER BY Data_Manutenção DESC;
END

--remover manutenções
CREATE PROCEDURE spRemoverManutencao
    @ID_Manutencao INT
AS
BEGIN
    DELETE FROM Manutenção
    WHERE ID_Manutenção = @ID_Manutencao;
END


--adicionar manutenção
CREATE or alter PROCEDURE spAdicionarManutencao
    @ID_Viatura INT = NULL,
    @ID_Equipamento INT = NULL,
    @Data_Manutencao DATE,
    @Descricao NVARCHAR(255)
AS
BEGIN
    INSERT INTO Manutenção (ID_Viatura, ID_Equipamento, Data_Manutenção, Descrição)
    VALUES (@ID_Viatura, @ID_Equipamento, @Data_Manutencao, @Descricao);
END

--listar especializações
CREATE PROCEDURE spListarEspecializacoesDoBombeiro
    @ID_Bombeiro INT
AS
BEGIN
    SELECT E.ID_Especialização, E.Nome_Especialização
    FROM Especialização E
    INNER JOIN Bombeiro_Especialização BE ON E.ID_Especialização = BE.ID_Especialização
    WHERE BE.ID_Bombeiro = @ID_Bombeiro;
END













DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'DROP PROCEDURE [' + SCHEMA_NAME(schema_id) + '].[' + name + '];' + CHAR(13)
FROM sys.procedures;

EXEC sp_executesql @sql;
