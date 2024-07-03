-- Drop tables if they exist
IF OBJECT_ID('Projeto_Login', 'U') IS NOT NULL
    DROP TABLE Projeto_Login;

IF OBJECT_ID('Projeto_Doacao', 'U') IS NOT NULL
    DROP TABLE Projeto_Doacao;

IF OBJECT_ID('Projeto_Tem_Tratamento_Tratador_Animal', 'U') IS NOT NULL
    DROP TABLE Projeto_Tem_Tratamento_Tratador_Animal;
    
IF OBJECT_ID('Projeto_Tratamento', 'U') IS NOT NULL
    DROP TABLE Projeto_Tratamento;

IF OBJECT_ID('Projeto_Tratador', 'U') IS NOT NULL
    DROP TABLE Projeto_Tratador;

IF OBJECT_ID('Projeto_Doador', 'U') IS NOT NULL
    DROP TABLE Projeto_Doador;

IF OBJECT_ID('Projeto_Funcionario', 'U') IS NOT NULL
    DROP TABLE Projeto_Funcionario;

IF OBJECT_ID('Projeto_Tem_Vacina', 'U') IS NOT NULL
    DROP TABLE Projeto_Tem_Vacina;

IF OBJECT_ID('Projeto_Vacina', 'U') IS NOT NULL
    DROP TABLE Projeto_Vacina;

IF OBJECT_ID('Projeto_Historial_Clinico', 'U') IS NOT NULL
    DROP TABLE Projeto_Historial_Clinico;

IF OBJECT_ID('Projeto_Desparasitacao_externa', 'U') IS NOT NULL
    DROP TABLE Projeto_Desparasitacao_externa;

IF OBJECT_ID('Projeto_Desparasitacao_interna', 'U') IS NOT NULL
    DROP TABLE Projeto_Desparasitacao_interna;

IF OBJECT_ID('Projeto_Tem_Desparasitacao', 'U') IS NOT NULL
    DROP TABLE Projeto_Tem_Desparasitacao;

IF OBJECT_ID('Projeto_Desparasitacao', 'U') IS NOT NULL
    DROP TABLE Projeto_Desparasitacao;

IF OBJECT_ID('Projeto_Animal', 'U') IS NOT NULL
    DROP TABLE Projeto_Animal;

IF OBJECT_ID('Projeto_Adotante', 'U') IS NOT NULL
    DROP TABLE Projeto_Adotante;

IF OBJECT_ID('Projeto_PESSOA', 'U') IS NOT NULL
    DROP TABLE Projeto_PESSOA;

IF OBJECT_ID('Projeto_Abrigo', 'U') IS NOT NULL
    DROP TABLE Projeto_Abrigo;

---------------------------------------------------
-- DROP DE VIEWES
DROP VIEW IF EXISTS SHOW_TRATAMENTOS_TRATADOR;
DROP VIEW IF EXISTS SHOW_TRATADOR;

DROP VIEW IF EXISTS SHOW_DOADORES;

DROP VIEW IF EXISTS SHOW_DOACOES_DOADOR;

DROP VIEW IF EXISTS SHOW_ADOTANTE;
DROP VIEW IF EXISTS SHOW_ADOCOES_ADOTANTE;

DROP VIEW IF EXISTS SHOW_FUNCIONARIO;

DROP VIEW IF EXISTS SHOW_ANIMALS;
DROP VIEW IF EXISTS SHOW_ANIMAL;

-----------------------------------------------


-- DROP PROCEDURES
DROP PROCEDURE IF EXISTS VerifyPassword;

DROP PROCEDURE IF EXISTS AddFuncionario;

DROP PROCEDURE IF EXISTS RemoveFuncionario;


DROP PROCEDURE IF EXISTS AddTratador;


DROP PROCEDURE IF EXISTS RemoveTratador;


DROP PROCEDURE IF EXISTS AtualizarAdotanteNIF;


DROP PROCEDURE IF EXISTS RemoveAnimal;
-----------------------------------------------
---Drop UDFS
DROP FUNCTION IF EXISTS  HashPassword;

----------------------------------------------
-- DROP INDEXES

-- Drop Clustered indexes
DROP INDEX IF EXISTS CL_IDX_Projeto_Funcionario ON Projeto_Funcionario;
DROP INDEX IF EXISTS CL_IDX_Projeto_Tratador ON Projeto_Tratador;
DROP INDEX IF EXISTS CL_IDX_Projeto_Animal ON Projeto_Animal;
DROP INDEX IF EXISTS CL_IDX_Projeto_Adotante ON Projeto_Adotante;

DROP INDEX IF EXISTS CL_IDX_Projeto_Doador ON Projeto_Doador;


-----------------------------------------------


--DROP TRIGGERS

DROP TRIGGER IF EXISTS DeleteTratadorRelations


DROP TRIGGER IF EXISTS DeleteAnimalRelations

------------------------------------------------



CREATE TABLE Projeto_Abrigo (
    Nome VARCHAR(128) NOT NULL,
    Endereco VARCHAR(512) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    Email VARCHAR(128) NOT NULL,
    PRIMARY KEY (Email)
);

CREATE TABLE Projeto_Adotante (
    Telefone VARCHAR(20) NOT NULL,
    Nome VARCHAR(128) NOT NULL,
    Endereco VARCHAR(512) NOT NULL,
    Email VARCHAR(128) NOT NULL,
    Data_Adocao DATE NOT NULL,
    Num_Adotante INT NOT NULL,
    NIF_Adotante BIGINT NOT NULL CHECK (NIF_Adotante > 100000000),
    AEMAIL VARCHAR(128) FOREIGN KEY REFERENCES Projeto_Abrigo(Email)
    PRIMARY KEY NONCLUSTERED (NIF_Adotante)
);

CREATE TABLE Projeto_Animal (
    Nome_Animal VARCHAR(128) NOT NULL,
    Num_chegada BIGINT NOT NULL,
    Altura DECIMAL(5,2) NOT NULL,
    Idade INT NOT NULL,
    Peso DECIMAL(5,2) NOT NULL,
    Origem_Historia VARCHAR(1024),
    Data_Entrada DATE NOT NULL,
    Numero_Microchip BIGINT NOT NULL,
    AEMAIL VARCHAR(128) FOREIGN KEY REFERENCES Projeto_Abrigo(Email),
    Adotante_NIF BIGINT CHECK (Adotante_NIF > 100000000) FOREIGN KEY REFERENCES Projeto_Adotante(NIF_Adotante),
    PRIMARY KEY NONCLUSTERED (Num_chegada)
);

CREATE TABLE Projeto_Desparasitacao (
    Desparasitacao_data DATE NOT NULL,
    Tipo_Desparasitacao VARCHAR (128) NOT NULL,
    Desparasitante VARCHAR(512) NOT NULL,
    PRIMARY KEY (Desparasitacao_data)
);

CREATE TABLE Projeto_TEM_Desparasitacao(
    Num_chegada BIGINT FOREIGN KEY REFERENCES Projeto_Animal(Num_chegada),
    Ddata DATE FOREIGN KEY REFERENCES Projeto_Desparasitacao([Desparasitacao_data ])
)

CREATE TABLE Projeto_Historial_Clinico (
    Historial_Clinico_data DATE NOT NULL,
    Patologia VARCHAR(255) NOT NULL,
    Medicacao VARCHAR(255) NOT NULL,

    PRIMARY KEY (Historial_Clinico_data),
    Num_chegada BIGINT FOREIGN KEY REFERENCES Projeto_Animal(Num_chegada)
);

CREATE TABLE Projeto_Vacina (
    [Data] DATE NOT NULL,
    Tipo_Vacina VARCHAR(128) NOT NULL,
    Dose INT NOT NULL,

    PRIMARY KEY (Data)
);

CREATE TABLE Projeto_Tem_Vacina (
    Num_chegada BIGINT FOREIGN KEY REFERENCES Projeto_Animal(Num_chegada),
    Vacina_data DATE FOREIGN KEY REFERENCES Projeto_Vacina([DATA])
);

CREATE TABLE Projeto_Funcionario (
    Num_Func INT NOT NULL,
    NIF_Func BIGINT NOT NULL CHECK (NIF_Func> 100000000),
    Abrigo_Email VARCHAR(128) FOREIGN KEY REFERENCES Projeto_Abrigo(Email),
    Telefone VARCHAR(20) NOT NULL,
    Nome VARCHAR(128) NOT NULL,
    Endereco VARCHAR(1024) NOT NULL,
    Email VARCHAR(128) NOT NULL,
    Horario DATETIME NOT NULL,
    PRIMARY KEY NONCLUSTERED  (NIF_Func)


)

CREATE TABLE Projeto_Doador (
    Num_Doador INT NOT NULL,
    NIF_Doador BIGINT UNIQUE NOT NULL CHECK (NIF_Doador > 100000000),
    Abrigo_Email VARCHAR(128) FOREIGN KEY REFERENCES Projeto_Abrigo(Email),
    Telefone VARCHAR(20) NOT NULL,
    Nome VARCHAR(128) NOT NULL,
    Endereco VARCHAR(1024) NOT NULL,
    Email VARCHAR(128) NOT NULL,
    PRIMARY KEY  NONCLUSTERED  (NIF_Doador)
)

CREATE TABLE Projeto_Tratador (
    Num_Tratador INT NOT NULL,
    NIF_Tratador BIGINT NOT NULL CHECK (NIF_Tratador > 100000000),
    Abrigo_Email VARCHAR(128) FOREIGN KEY REFERENCES Projeto_Abrigo(Email),
    Telefone VARCHAR(20) NOT NULL,
    Nome VARCHAR(128) NOT NULL,
    Endereco VARCHAR(1024) NOT NULL,
    Email VARCHAR(128) NOT NULL,
    Horario DATETIME NOT NULL
    PRIMARY KEY  NONCLUSTERED (NIF_Tratador)
);

CREATE TABLE Projeto_Tratamento (
    [Data] DATE NOT NULL,
    Tipo_Tratamento VARCHAR(128) NOT NULL,

	PRIMARY KEY([Data])
);

CREATE TABLE Projeto_Tem_Tratamento_Tratador_Animal (
    Tratador_NIF BIGINT FOREIGN KEY REFERENCES Projeto_Tratador(NIF_Tratador),
    Num_chegada BIGINT FOREIGN KEY REFERENCES Projeto_Animal(Num_chegada),
    Tratamento_Data DATE FOREIGN KEY REFERENCES Projeto_Tratamento([Data])
);

CREATE TABLE Projeto_Doacao (
    ID INT PRIMARY KEY NOT NULL,
    Doador_NIF BIGINT CHECK (Doador_NIF > 100000000) FOREIGN KEY REFERENCES Projeto_Doador(NIF_Doador),
    Quantidade DECIMAL(5,2) NOT NULL,
    Tipo_Doacao VARCHAR(128) NOT NULL,
    [Data] DATE NOT NULL
);

CREATE TABLE Projeto_Login (
    Username VARCHAR(128) NOT NULL,
    Password VARCHAR(128) NOT NULL,
    PRIMARY KEY (Username)
);

