
-- Populating the Projeto_Abrigo table with a single email
INSERT INTO Projeto_Abrigo (Nome, Endereco, Telefone, Email) VALUES
('Abrigo de Carinho', 'Rua do Bem-Estar, 1000', '1111-2222', 'abrigo_de_carinho@outlook.com');


-- Populating the Projeto_Adotante table with phone numbers starting with 91, 92, 93, or 96
INSERT INTO Projeto_Adotante (Telefone, Nome, Endereco, Email, Data_Adocao, Num_Adotante, NIF_Adotante, AEMAIL) VALUES
('911876098', 'Roberto Carlos', 'Rua do Amor, 123', 'roberto.carlos@email.com', '2023-01-15', 1, 123456789, 'abrigo_de_carinho@outlook.com'),
('922345678', 'Luciana Silva', 'Av. da Alegria, 456', 'luciana.silva@email.com', '2023-02-20', 2, 987654321, 'abrigo_de_carinho@outlook.com'),
('933456789', 'Marcos Paulo', 'Praça da Paz, 789', 'marcos.paulo@email.com', '2023-03-25', 3, 456789123, 'abrigo_de_carinho@outlook.com'),
('944567890', 'Patricia Gomes', 'Rua do Sol, 101', 'patricia.gomes@email.com', '2023-04-30', 4, 654321987, 'abrigo_de_carinho@outlook.com');


-- Populating the Projeto_Animal table
INSERT INTO Projeto_Animal (Nome_Animal, Num_chegada, Altura, Idade, Peso, Origem_Historia, Data_Entrada, Numero_Microchip, AEMAIL,Adotante_NIF) VALUES
('Bobby', 50, 50.00, 2, 20.50, 'Resgatado na rua', '2023-01-10', 1234567890, 'abrigo_de_carinho@outlook.com',123456789),
('Luna', 45, 45.50, 1, 18.00, 'Encontrada num parque', '2023-02-15', 9876543210, 'abrigo_de_carinho@outlook.com',987654321),
('Max', 60, 60.20, 3, 25.00, 'Abandonado numa estrada', '2023-03-20', 2345678901, 'abrigo_de_carinho@outlook.com',123456789),
('Bella', 40, 40.75, 4, 22.30, 'Entregue por um dono que não podia cuidar mais', '2023-04-25', 3456789012, 'abrigo_de_carinho@outlook.com',456789123),
('Charlie', 55, 55.60, 2, 24.70, 'Resgatado de um abrigo municipal', '2023-05-30', 4567890123, 'abrigo_de_carinho@outlook.com',654321987);

-- Populating the Projeto_Desparasitacao table
INSERT INTO Projeto_Desparasitacao (Desparasitacao_data, Tipo_Desparasitacao,Desparasitante) VALUES
('2023-01-15','Interna', 'Vermífugo'),
('2023-02-20','Externa', 'Vermífugo'),
('2023-03-25','Interna', 'Vermífugo'),
('2023-04-30','Externa', 'Vermífugo'),
('2023-05-10', 'Interna', 'Vermífugo');

-- Populating the Projeto_Tem_Desparasitacao table
INSERT INTO Projeto_Tem_Desparasitacao (Num_chegada, Ddata) VALUES
(50, '2023-01-15'),
(45, '2023-02-20'),
(60, '2023-03-25'),
(40, '2023-04-30'),
(55, '2023-05-10');



-- Populating the Projeto_Historial_Clinico table 
INSERT INTO Projeto_Historial_Clinico (Historial_Clinico_data, patologia, medicacao, Num_chegada) VALUES 
('2023-01-15', 'Doença do Carrapato', 'Vermífugo', 50),
('2023-02-20', 'Doença do Carrapato', 'Vermífugo', 45),
('2023-03-25', 'Doença do Carrapato', 'Vermífugo', 60),
('2023-04-30', 'Doença do Carrapato', 'Vermífugo', 40),
('2023-05-10', 'Doença do Carrapato', 'Vermífugo', 55);

-- Populating the Projeto_Vacina table
INSERT INTO Projeto_Vacina ([Data], Tipo_Vacina, Dose) VALUES
('2023-01-15', 'V8', 1),
('2023-02-20', 'V8', 1),
('2023-03-25', 'V8', 1),
('2023-04-30', 'V8', 1),
('2023-05-10', 'V8', 1);

-- Populating the Projeto_Tem_Vacina table
INSERT INTO Projeto_Tem_Vacina (Num_chegada, Vacina_data) VALUES
(50, '2023-01-15'),
(45, '2023-02-20'),
(60, '2023-03-25'),
(40, '2023-04-30'),
(55, '2023-05-10');

-- Populating the Projeto_Funcionario table
INSERT INTO Projeto_Funcionario (Num_Func, NIF_Func, Abrigo_Email, Telefone, Nome, Endereco, Email, Horario)
VALUES
    (1, 125652432, 'abrigo_de_carinho@outlook.com', '912345678', 'João Silva', 'Rua Principal, Lisboa, Portugal', 'joao_silva@example.com', '10:00'),
    (2, 982371546, 'abrigo_de_carinho@outlook.com', '936789012', 'Maria Santos', 'Avenida Central, Porto, Portugal', 'maria_santos@example.com', '10:00'),
    (3, 749102836, 'abrigo_de_carinho@outlook.com', '913456789', 'Ana Costa', 'Rua das Flores, Coimbra, Portugal', 'ana_costa@example.com', '10:00'),
    (4, 365874219, 'abrigo_de_carinho@outlook.com', '926789012', 'Carlos Fernandes', 'Avenida da Liberdade, Braga, Portugal', 'carlos_fernandes@example.com', '10:00'),
    (5, 825913647, 'abrigo_de_carinho@outlook.com', '917654321', 'Miguel Oliveira', 'Rua dos Girassóis, Faro, Portugal', 'miguel_oliveira@example.com', '10:00'),
    (6, 473829156, 'abrigo_de_carinho@outlook.com', '938765432', 'Sofia Pereira', 'Avenida das Palmeiras, Aveiro, Portugal', 'sofia_pereira@example.com', '10:00'),
    (7, 215789634, 'abrigo_de_carinho@outlook.com', '919876543', 'Rui Carvalho', 'Rua dos Lírios, Leiria, Portugal', 'rui_carvalho@example.com', '10:00'),
    (8, 598761234, 'abrigo_de_carinho@outlook.com', '926543219', 'Ana Martins', 'Avenida das Rosas, Coimbra, Portugal', 'ana_martins@example.com', '10:00');

INSERT INTO Projeto_Doador (Num_Doador, NIF_Doador, Abrigo_Email, Telefone, Nome, Endereco, Email)
VALUES
    (1, 123456789, 'abrigo_de_carinho@outlook.com', '912345678', 'António Pereira', 'Rua das Amendoeiras, Lisboa, Portugal', 'antonio_pereira@example.com'),
    (2, 987654321, 'abrigo_de_carinho@outlook.com', '936789012', 'Marta Fonseca', 'Avenida dos Girassóis, Porto, Portugal', 'marta_fonseca@example.com')
    
  
    
-- Insert sample data into Projeto_Tratador
INSERT INTO Projeto_Tratador (Num_Tratador, NIF_Tratador, Abrigo_Email, Telefone, Nome, Endereco, Email, Horario)
VALUES
    (1, 125652432, 'abrigo_de_carinho@outlook.com', '912345678', 'Pedro Almeida', 'Rua dos Pinheiros, Lisboa, Portugal', 'pedro_almeida@example.com', '09:00'),
    (2, 982371546, 'abrigo_de_carinho@outlook.com', '936789012', 'Rita Ferreira', 'Avenida das Acácias, Porto, Portugal', 'rita_ferreira@example.com', '09:00'),
    (3, 749102836, 'abrigo_de_carinho@outlook.com', '913456789', 'Luís Oliveira', 'Rua das Violetas, Coimbra, Portugal', 'luis_oliveira@example.com', '08:00'),
    (4, 365874219, 'abrigo_de_carinho@outlook.com', '926789012', 'Sara Costa', 'Avenida dos Cravos, Braga, Portugal', 'sara_costa@example.com', '10:00'),
    (5, 825913647, 'abrigo_de_carinho@outlook.com', '917654321', 'Diogo Rodrigues', 'Rua das Rosas, Faro, Portugal', 'diogo_rodrigues@example.com', '10:00'),
    (6, 473829156, 'abrigo_de_carinho@outlook.com', '938765432', 'Inês Sousa', 'Avenida dos Lírios, Aveiro, Portugal', 'ines_sousa@example.com', '10:00'),
    (7, 215789634, 'abrigo_de_carinho@outlook.com', '919876543', 'Tiago Silva', 'Rua das Camélias, Leiria, Portugal', 'tiago_silva@example.com', '10:00'),
    (8, 598761234, 'abrigo_de_carinho@outlook.com', '926543219', 'Mariana Santos', 'Avenida das Orquídeas, Coimbra, Portugal', 'mariana_santos@example.com', '10:00');

-- Insert sample data into Projeto_Tratamento
INSERT INTO Projeto_Tratamento (Data, Tipo_Tratamento)
VALUES
    ('2024-05-01', 'Exame médico'),
    ('2024-05-05', 'Vacinação'),
    ('2024-05-10', 'Desparasitação'),
    ('2024-05-15', 'Cirurgia'),
    ('2024-05-20', 'Tratamento contra pulgas e carrapatos');

-- Insert sample data into Projeto_Tem_Tratamento_Tratador_Animal
INSERT INTO Projeto_Tem_Tratamento_Tratador_Animal (Tratador_NIF, Num_chegada, Tratamento_Data)
VALUES
    (125652432, 50, '2024-05-01'),
    (982371546, 45, '2024-05-05'),
    (749102836, 40, '2024-05-10'),
    (365874219, 60, '2024-05-15'),
    (825913647, 55, '2024-05-20');

-- Insert sample data into Projeto_Doacao table     

INSERT INTO Projeto_Doacao (ID,Doador_NIF, Quantidade, Tipo_Doacao, Data)
VALUES
    (1,123456789, 100.50, 'Alimentar(Kg)', '2024-05-10'),
    (2,123456789,250.00, 'Medicinal(Unidade)', '2024-05-15'),
    (3,123456789, 50.00, 'Acessórios(Unidade)', '2024-05-20'),
    (4,987654321, 150.25, ' Monetária(€)', '2024-05-25');


-- Insert sample data
INSERT INTO Projeto_Login (Username, Password)
VALUES ('user1', dbo.HashPassword('Password1')),
       ('user2', dbo.HashPassword('Password2'));