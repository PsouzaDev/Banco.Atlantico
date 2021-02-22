CREATE TABLE Cliente (
    ID            INT IDENTITY(1,1) PRIMARY KEY,
    Nome          varchar(255) NOT NULL,
    Saldo         decimal
);

CREATE TABLE Caixa (
    ID            INT IDENTITY(1,1) PRIMARY KEY,
    Saldo         BIGINT,
    StatusCaixa   BIT,
    NotaDois      INT,
    NotaCinco     INT,
    NotaDez       INT,
    NotaVinte     INT,
    NotaCinquenta INT
);