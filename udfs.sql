use Teste;
go

-- User-Defined Functions bombeiro

-- Valida NIF
CREATE FUNCTION fn_ValidaNIF (@NIF NVARCHAR(20))
RETURNS BIT
AS
BEGIN
    IF LEN(@NIF) = 9 AND ISNUMERIC(@NIF) = 1 AND LEFT(@NIF, 1) IN ('1', '2', '5', '6', '8', '9')
        RETURN 1;
    RETURN 0;
END;
GO

-- Formatar Telemóvel
CREATE FUNCTION fn_FormatarTelemovel (@Telemovel NVARCHAR(20))
RETURNS NVARCHAR(25)
AS
BEGIN
    RETURN STUFF(STUFF(@Telemovel, 4, 0, ' '), 8, 0, ' ');
END;
GO

-- Calcular Idade
CREATE FUNCTION fn_CalcularIdade (@DataNascimento DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(YEAR, @DataNascimento, GETDATE()) -
           CASE 
               WHEN MONTH(GETDATE()) < MONTH(@DataNascimento) OR 
                    (MONTH(GETDATE()) = MONTH(@DataNascimento) AND DAY(GETDATE()) < DAY(@DataNascimento)) 
               THEN 1 ELSE 0 
           END;
END;
GO

-- User-Defined Functions para CHAMADA

-- 1. Formatar número de telefone
CREATE FUNCTION fn_FormatarNumeroTelefone (@Numero NVARCHAR(20))
RETURNS NVARCHAR(25)
AS
BEGIN
    RETURN STUFF(STUFF(@Numero, 4, 0, ' '), 8, 0, ' ');
END;
GO

-- 2. Obter texto da origem
CREATE FUNCTION fn_ObterOrigemTexto (@Origem INT)
RETURNS NVARCHAR(20)
AS
BEGIN
    RETURN CASE WHEN @Origem = 1 THEN 'Redirecionada' ELSE 'Direta' END;
END;
GO

-- 3. Gerar resumo da chamada
CREATE FUNCTION fn_ResumoChamada (
    @Nome NVARCHAR(100),
    @DataHora DATETIME,
    @Localizacao NVARCHAR(200)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN @Nome + ' - ' + CONVERT(NVARCHAR, @DataHora, 120) + ' @ ' + @Localizacao;
END;
GO

-- User-Defined Functions para EQUIPAMENTO

-- 1. Validar quantidade (ex: impedir negativos)
CREATE FUNCTION fn_ValidaQuantidade (@Qtd INT)
RETURNS BIT
AS
BEGIN
    RETURN CASE WHEN @Qtd >= 0 THEN 1 ELSE 0 END;
END;
GO

-- 2. Gerar descrição resumida do equipamento
CREATE FUNCTION fn_ResumoEquipamento (
    @Nome NVARCHAR(100),
    @Qtd INT,
    @Matricula NVARCHAR(20)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN @Nome + ' (' + CAST(@Qtd AS NVARCHAR) + ') em viatura ' + @Matricula;
END;
GO

-- User-Defined Functions para OCORRÊNCIA

-- 1. Texto resumo da ocorrência
CREATE FUNCTION fn_ResumoOcorrencia (
    @Descricao NVARCHAR(MAX),
    @Data DATETIME,
    @Local NVARCHAR(200)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN @Descricao + ' @ ' + @Local + ' [' + CONVERT(NVARCHAR, @Data, 120) + ']';
END;
GO

-- User-Defined Functions para VIATURA

-- 1. Valida ano da viatura
CREATE FUNCTION fn_ValidaAno (@Ano INT)
RETURNS BIT
AS
BEGIN
    IF @Ano >= 1980 AND @Ano <= YEAR(GETDATE())
        RETURN 1;
    RETURN 0;
END;
GO
