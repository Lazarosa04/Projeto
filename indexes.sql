
-- Índices Bombeiro

-- Índice único para NIF
CREATE UNIQUE INDEX idx_Bombeiro_NIF ON Bombeiro (NIF);
GO

-- Índice para nome
CREATE INDEX idx_Bombeiro_Nome ON Bombeiro (Nome_Bombeiro);
GO

-- Índice para email
CREATE INDEX idx_Bombeiro_Email ON Bombeiro (Email);
GO

-- Índices para CHAMADA

-- Índice por data/hora
CREATE INDEX idx_Chamada_DataHora ON Chamada (Data_Hora_Chamada);
GO

-- Índice por nome
CREATE INDEX idx_Chamada_Nome ON Chamada (Nome);
GO

-- Índice por número
CREATE INDEX idx_Chamada_Numero ON Chamada ([Número]);
GO

-- Índices para EQUIPAMENTO

-- Índice por nome do equipamento
CREATE INDEX idx_Equipamento_Nome ON Equipamento (Nome_Equipamento);
GO

-- Índice por ID da viatura
CREATE INDEX idx_Equipamento_Viatura ON Equipamento (ID_Viatura);
GO

-- Índices para OCORRÊNCIA

CREATE INDEX idx_Ocorrencia_Data ON Ocorrência (Data_Hora);
GO

CREATE INDEX idx_Ocorrencia_Quartel ON Ocorrência (ID_Quartel);
GO

-- Índices para VIATURA

CREATE UNIQUE INDEX idx_Viatura_Matricula ON Viatura (Matricula);
GO

CREATE INDEX idx_Viatura_Tipo ON Viatura (ID_TipoViatura);
GO