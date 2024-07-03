


--Cursor que conta o número de doações de um doador
DECLARE @Num_Doador INT;
 DECLARE @n_doacoes INT;


 SET @Num_Doador = 1 ; --Valor teste este valor no forms é obtido através do input do utilizador

  DECLARE countCursor CURSOR FOR
      SELECT COUNT(*) AS N_DOACOES
      FROM SHOW_DOACOES_DOADOR WHERE Num_Doador = @Num_Doador;

              
  OPEN countCursor;


  FETCH NEXT FROM countCursor INTO @n_doacoes;

            
  CLOSE countCursor;
  DEALLOCATE countCursor;


  -- Usar o valor contado
  PRINT 'Número de Doacoes: ' + CAST(@n_doacoes AS VARCHAR);



  -- Cursor que conta o número de tratamentos por tratador
  

DECLARE @Num_Tratador INT;
 DECLARE @n_tratamentos INT;


 SET @Num_Tratador = 1 ; --Valor teste este valor no forms é obtido através do input do utilizador

  DECLARE countCursor CURSOR FOR
      SELECT COUNT(*) AS N_TRATAMENTOS
      FROM SHOW_TRATAMENTOS_TRATADOR WHERE Num_tratador = @Num_Tratador;

              
  OPEN countCursor;


  FETCH NEXT FROM countCursor INTO @n_tratamentos;

            
  CLOSE countCursor;
  DEALLOCATE countCursor;



  PRINT 'Número de Tratamentos: ' + CAST(@n_tratamentos AS VARCHAR);




  -- Cursor que conta o número de adoções por adotante
  DECLARE @Num_Adotante INT;
 DECLARE @n_adocoes INT;


 SET @Num_Adotante = 1 ; --Valor teste este valor no forms é obtido através do input do utilizador

  DECLARE countCursor CURSOR FOR
      SELECT COUNT(*) AS N_Adocoes
      FROM SHOW_ADOCOES_ADOTANTE WHERE Num_adotante = @Num_Adotante;

              
  OPEN countCursor;


  FETCH NEXT FROM countCursor INTO @n_adocoes;

            
  CLOSE countCursor;
  DEALLOCATE countCursor;


  -- Usar o valor contado
  PRINT 'Número de Adoções: ' + CAST(@n_adocoes AS VARCHAR);