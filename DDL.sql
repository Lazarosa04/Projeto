create database QuartelBombeiros
use QuartelBombeiros

--tipo viatura
create table TipoViatura(
	ID_TipoViatura		int primary key,
	Nome_TipoViatura	varchar(100)
);

--quartel
create table Quartel(
	ID_Quartel			int primary key,
	Nome_Quartel		varchar(100),
	Endereço			varchar(300),
	Telefone			char(12)
);

--viatura
create table Viatura(
	ID_Viatura			int Identity(1,1) primary key,
	ID_Quartel			int references Quartel(ID_Quartel),
	ID_TipoViatura		int references TipoViatura(ID_TipoViatura),
	Matricula			varchar(12),	
	Ano					int
);


--equipamento
create table Equipamento(
	ID_Equipamento		int Identity(1,1) primary key,
	ID_Quartel			int references Quartel(ID_Quartel),
	ID_Viatura			int references Viatura(ID_Viatura),
	Nome_Equipamento	varchar(100),
	Quantidade			int
);

--manutenção
create table Manutenção(
	ID_Manutenção		int Identity(1,1) primary key,
	ID_Viatura			int references Viatura(ID_Viatura),
	ID_Equipamento		int references Equipamento(ID_Equipamento),
	Data_Manutenção		date,
	Descrição			varchar(300)
);

--bombeiro
create table Bombeiro(
	ID_Bombeiro			int Identity(1,1) primary key,
	ID_Quartel			int references Quartel(ID_Quartel),
	Nome_Bombeiro		varchar(100),
	Data_Nascimento		date,
	Morada				varchar(300),
	Email				varchar(100),
	NIF					char(9),
	Telemóvel			char(12)
);

--formação
create table Formação(
	ID_Formação			int Identity(1,1) primary key,
	ID_Quartel			int references Quartel(ID_Quartel),
	Data_Inicio			date,
	Data_Fim			date
);

--uma formação pode ser participada por vários bombeiros
--um bombeiro pode participar de várias Formações
create table Bombeiro_Formação(
	ID_Bombeiro			int references Bombeiro(ID_Bombeiro),
	ID_Formação			int references Formação(ID_Formação),
);

--especialização
create table Especialização(
	ID_Especialização	int Identity(1,1) primary key,
	Nome_Especialização	varchar(100)
);

--uma especializaçã pode ser tirada por vários bombeiros
--cada bombeiro pode ter várias especializações
create table Bombeiro_Especialização(
	ID_Bombeiro			int references Bombeiro(ID_Bombeiro),
	ID_Especialização	int references Especialização(ID_Especialização)
);

--férias
create table Férias(
	ID_Férias			int Identity(1,1) primary key,
	ID_Bombeiro			int references Bombeiro(ID_Bombeiro),
	Data_Inicio			date primary key,
	Data_Fim			date
);

--baixa
create table Baixa(
	ID_Baixa			int Identity(1,1) primary key,
	ID_Bombeiro			int references Bombeiro(ID_Bombeiro),
	Data_Inicio			date primary key,
	Data_Fim			date,
	Razão				varchar(300)
);

--ocorrência
create table Ocorrência(
	ID_Ocorrência		int Identity(1,1) primary key,
	ID_Quartel			int references Quartel(ID_Quartel),
	Data_Hora			DateTime
);

--vários bombeiros podem acudir a uma ocorrência
--um bombeiro pode acudir a várias ocorrências
create table Bombeiro_Ocorrência(
	ID_Ocorrência		int references Ocorrência(ID_Ocorrência),
	ID_Bombeiro			int references Bombeiro(ID_Bombeiro),
);

--várias viaturas podem acudir a uma ocorrência
--uma viatura pode acudir a várias ocorrências
create table Viatura_Ocorrência(
	ID_Ocorrência		int references Ocorrência(ID_Ocorrência),
	ID_Viatura			int references Viatura(ID_Viatura)
);

--chamada
create table Chamada(
	ID_Chamada			int Identity(1,1) primary key,
	ID_Ocorrência		int references Ocorrência(ID_Ocorrência),
	Origem				binary(1),	--chamada direta ou redirecionada
	Descrição			varchar(300),
	Nome				varchar(100),
	Data_Hora_Chamada	DateTime,
	Localização			varchar(300),
	Número				char(12)
);
