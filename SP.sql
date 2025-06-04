use Teste;
go

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
CREATE PROCEDURE spAdicionarEquipamento
    @Nome NVARCHAR(100),
    @Quantidade INT,
    @ID_Viatura INT
AS
BEGIN
    INSERT INTO Equipamento (Nome_Equipamento, Quantidade, ID_Viatura)
    VALUES (@Nome, @Quantidade, @ID_Viatura);
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

-- 3. Listar equipamentos
CREATE PROCEDURE spListarEquipamentos
AS
BEGIN
    SELECT e.ID_Equipamento, e.Nome_Equipamento, e.Quantidade, v.Matricula, v.ID_Viatura
    FROM Equipamento e
    INNER JOIN Viatura v ON e.ID_Viatura = v.ID_Viatura
    ORDER BY e.Nome_Equipamento;
END;
GO



-- Stored Procedures para OCORRÊNCIA

-- 1. Inserir ocorrência
CREATE PROCEDURE spAdicionarOcorrencia
    @ID_Quartel INT,
    @DataHora DATETIME,
    @ID_Chamada INT
AS
BEGIN
    DECLARE @ID_Ocorrencia INT;

    INSERT INTO Ocorrência (ID_Quartel, Data_Hora)
    VALUES (@ID_Quartel, @DataHora);

    SET @ID_Ocorrencia = SCOPE_IDENTITY();

    UPDATE Chamada SET ID_Ocorrência = @ID_Ocorrencia WHERE ID_Chamada = @ID_Chamada;

    SELECT @ID_Ocorrencia AS NovaOcorrenciaID;
END;
GO

-- 2. Remover ocorrência (sem apagar chamadas)
CREATE PROCEDURE spRemoverOcorrencia
    @ID INT
AS
BEGIN
    DELETE FROM Bombeiro_Ocorrência WHERE ID_Ocorrência = @ID;
    DELETE FROM Viatura_Ocorrência WHERE ID_Ocorrência = @ID;
    UPDATE Chamada SET ID_Ocorrência = NULL WHERE ID_Ocorrência = @ID;
    DELETE FROM Ocorrência WHERE ID_Ocorrência = @ID;
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
