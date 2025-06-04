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
	Endere�o			varchar(300),
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

--manuten��o
create table Manuten��o(
	ID_Manuten��o		int Identity(1,1) primary key,
	ID_Viatura			int references Viatura(ID_Viatura),
	ID_Equipamento		int references Equipamento(ID_Equipamento),
	Data_Manuten��o		date,
	Descri��o			varchar(300)
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
	Telem�vel			char(12)
);

--forma��o
create table Forma��o(
	ID_Forma��o			int Identity(1,1) primary key,
	ID_Quartel			int references Quartel(ID_Quartel),
	Data_Inicio			date,
	Data_Fim			date
);

--uma forma��o pode ser participada por v�rios bombeiros
--um bombeiro pode participar de v�rias Forma��es
create table Bombeiro_Forma��o(
	ID_Bombeiro			int references Bombeiro(ID_Bombeiro),
	ID_Forma��o			int references Forma��o(ID_Forma��o),
);

--especializa��o
create table Especializa��o(
	ID_Especializa��o	int Identity(1,1) primary key,
	Nome_Especializa��o	varchar(100)
);

--uma especializa��o pode ser tirada por v�rios bombeiros
--cada bombeiro pode ter v�rias especializa��es
create table Bombeiro_Especializa��o(
	ID_Bombeiro			int references Bombeiro(ID_Bombeiro),
	ID_Especializa��o	int references Especializa��o(ID_Especializa��o)
);

--f�rias
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

--ocorr�ncia
create table Ocorrência(
	ID_Ocorrência		int Identity(1,1) primary key,
	ID_Quartel			int references Quartel(ID_Quartel),
	Data_Hora			DateTime
);

--v�rios bombeiros podem acudir a uma ocorr�ncia
--um bombeiro pode acudir a v�rias ocorr�ncias
create table Bombeiro_Ocorrência(
	ID_Ocorrência		int references Ocorrência(ID_Ocorrência),
	ID_Bombeiro			int references Bombeiro(ID_Bombeiro),
);

--v�rias viaturas podem acudir a uma ocorr�ncia
--uma viatura pode acudir a v�rias ocorr�ncias
create table Viatura_Ocorr�ncia(
	ID_Ocorr�ncia		int references Ocorr�ncia(ID_Ocorr�ncia),
	ID_Viatura			int references Viatura(ID_Viatura)
);

--chamada
create table Chamada(
	ID_Chamada			int Identity(1,1) primary key,
	ID_Ocorr�ncia		int references Ocorr�ncia(ID_Ocorr�ncia),
	Origem				binary(1),	--chamada direta ou redirecionada
	Descri��o			varchar(300),
	Nome				varchar(100),
	Data_Hora_Chamada	DateTime,
	Localiza��o			varchar(300),
	N�mero				char(12)
);