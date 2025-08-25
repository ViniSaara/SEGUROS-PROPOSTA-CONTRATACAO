CREATE TABLE IF NOT EXISTS Proposta (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Status VARCHAR(20) NOT NULL
);

CREATE TABLE IF NOT EXISTS Contratacao (
    Id INT AUTO_INCREMENT PRIMARY KEY,
	Nome VARCHAR(100) NOT NULL,
    IdProposta INT NOT NULL,
    DataContratacao DATETIME NOT NULL,
    CONSTRAINT FK_Contratacao_Proposta FOREIGN KEY (IdProposta) REFERENCES Proposta(Id)
);

INSERT INTO Proposta (Nome, Status) VALUES
('Proposta 1', 'Em Analise'),
('Proposta 2', 'Aprovada'),
('Proposta 3', 'Rejeitada'),
('Proposta 4', 'Em Analise'),
('Proposta 5', 'Aprovada');

INSERT INTO Contratacao (Nome, IdProposta, DataContratacao) VALUES
('Contratacao 2', 2, '2025-08-22');