USE Task_Evento
CREATE TABLE Evento(
eventiID INT PRIMARY KEY IDENTITY (1,1),
nome VARCHAR (250) NOT NULL,
descrizione TEXT NOT NULL,
data DATE NOT NULL,
luogo VARCHAR (250) NOT NULL,
capacita_Massima FLOAT NOT NULL
);


CREATE TABLE Partecipante (
partecipanteId INT PRIMARY KEY IDENTITY (1,1),
nome VARCHAR (250) NOT NULL,
contatto VARCHAR(250) UNIQUE NOT NULL
);



CREATE TABLE Contiene(
 contieneId INT PRIMARY KEY IDENTITY (1,1),
 partecipanteRif INT NOT NULL,
 eventiRIf INT NOT NULL,
 FOREIGN KEY (partecipanteRif) REFERENCES Partecipante(partecipanteId) ON DELETE CASCADE,
  FOREIGN KEY (eventiRIf) REFERENCES Evento(eventiID) ON DELETE CASCADE,
);


CREATE TABLE Risorsa(
risorsaId INT PRIMARY KEY IDENTITY (1,1),
Tipo VARCHAR(50) NOT NULL CHECK (tipo IN ('attrezzatura', 'cibo', 'bevanda')),
costo FLOAT NOT NULL,
fornitore VARCHAR (250) NOT NULL,
Quantita INT NOT NULL,
eventoRif INT NOT NULL,
FOREIGN KEY (eventoRif) REFERENCES Evento(eventiID) ON DELETE CASCADE
);

select *from Partecipante