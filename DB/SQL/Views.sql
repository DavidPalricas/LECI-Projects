
-- View para ver todos os tratadores
CREATE VIEW SHOW_TRATADOR AS 
    SELECT 
        Num_tratador,Nome,Horario,Telefone,Email,Endereco 
    FROM 
        Projeto_Tratador
GO

-- View para ver os tratamentos por tratador
CREATE VIEW SHOW_TRATAMENTOS_TRATADOR AS 
    SELECT 
        pt.Num_tratador, 
        pt.Nome,
        tratamento.Tipo_Tratamento,
        pttta.Tratamento_Data, 
        pa.Nome_Animal, 
        pa.Num_chegada
    FROM 
        Projeto_Tratador pt
    INNER JOIN 
        Projeto_Tem_Tratamento_Tratador_Animal pttta 
        ON pt.NIF_Tratador = pttta.Tratador_NIF
    INNER JOIN 
        Projeto_Tratamento tratamento 
        ON tratamento.data = pttta.Tratamento_Data
    INNER JOIN 
        Projeto_Animal pa 
        ON pa.Num_chegada = pttta.Num_chegada
GO

-- View para ver todos os Doadores
CREATE VIEW SHOW_DOADORES AS 
    SELECT 
        Num_Doador,Nome,NIF_Doador,Telefone,Email,Endereco   
    FROM 
        Projeto_Doador 
GO

--View para mostrar as doações de um doador
CREATE VIEW SHOW_DOACOES_DOADOR AS 
    SELECT 
        pd.Num_Doador ,doacao.Tipo_Doacao, doacao.Quantidade, doacao.Data
    FROM 
        Projeto_Doador pd
    INNER JOIN 
        Projeto_Doacao doacao 
        ON 
        pd.NIF_Doador = doacao.Doador_NIF
GO

-- View para ver todos os adotantes
CREATE VIEW SHOW_ADOTANTE AS 
    SELECT 
        Num_Adotante,Nome,Data_Adocao,Telefone,Email,Endereco 
    FROM 
        Projeto_Adotante
GO

--View para ver as adoções de um adotante
CREATE VIEW SHOW_ADOCOES_ADOTANTE AS 
    SELECT 
        pa.Num_Adotante, animal.Num_chegada,animal.Nome_Animal, pa.Data_Adocao
    FROM 
        Projeto_Adotante pa 
    INNER JOIN Projeto_Animal animal 
        ON 
        pa.NIF_Adotante = animal.Adotante_NIF
GO

-- View para ver todos os funcionários
CREATE VIEW SHOW_FUNCIONARIO AS     
    SELECT 
        Num_func, Nome,Horario,Telefone,Email,Endereco 
    FROM 
        Projeto_Funcionario
GO

-- View para ver todos os animais
CREATE VIEW SHOW_ANIMALS AS 
    SELECT 
        Num_chegada, Nome_Animal, Altura, Idade, Peso, Origem_Historia, Data_Entrada, Numero_Microchip, Adotante_NIF
    FROM 
        Projeto_Animal
GO

CREATE VIEW SHOW_ANIMAL AS 
    SELECT 
        pa.Num_Chegada, pt.Tipo_Tratamento, pttta.Tratamento_Data ,Tratador.Num_Tratador, ptv.Vacina_Data, pv.Dose, pv.Tipo_Vacina, phc.Patologia, phc.Medicacao, phc.Historial_Clinico_data,pd.Tipo_Desparasitacao,pd.Desparasitante, pd.Desparasitacao_Data
    FROM 
        Projeto_Animal pa
    LEFT JOIN Projeto_Tem_Tratamento_Tratador_Animal pttta 
        ON 
        pa.Num_chegada = pttta.Num_chegada 
    LEFT JOIN Projeto_Tratamento pt 
        ON 
        pt.data = pttta.Tratamento_Data
    LEFT JOIN  Projeto_Tratador Tratador 
        ON 
        Tratador.NIF_Tratador = pttta.Tratador_NIF
    LEFT JOIN Projeto_Tem_Vacina ptv 
        ON 
        ptv.Num_chegada = pa.Num_chegada 
    LEFT JOIN Projeto_Vacina pv
        ON 
        pv.Data = ptv.Vacina_Data
    LEFT JOIN Projeto_Historial_Clinico phc 
        ON 
        phc.Num_chegada  = pa.Num_chegada
    LEFT JOIN Projeto_TEM_Desparasitacao ptd 
        ON 
        ptd.Num_chegada = pa.Num_chegada
    LEFT JOIN Projeto_Desparasitacao pd 
        ON 
        pd.Desparasitacao_data = ptd.Ddata
GO
