BEGIN TRANSACTION;

BEGIN TRY
    -- Declare the Num_chegada of the animal that died
    DECLARE @Num_chegada BIGINT;

    -- Delete from Projeto_TEM_Desparasitacao
    DELETE FROM Projeto_TEM_Desparasitacao
    WHERE Num_chegada = @Num_chegada;

    -- Delete from Projeto_Historial_Clinico
    DELETE FROM Projeto_Historial_Clinico
    WHERE Num_chegada = @Num_chegada;

    -- Delete from Projeto_Tem_Vacina
    DELETE FROM Projeto_Tem_Vacina
    WHERE Num_chegada = @Num_chegada;

    -- Delete from Projeto_Tem_Tratamento_Tratador_Animal is not performed as we want to keep the treatments.

    -- Finally, delete the animal from Projeto_Animal
    DELETE FROM Projeto_Animal
    WHERE Num_chegada = @Num_chegada;

    -- If all operations succeed, commit the transaction
    COMMIT TRANSACTION;
    PRINT 'Animal removal transaction completed successfully.';
    
END TRY
BEGIN CATCH
    -- If any error occurs, roll back the transaction
    ROLLBACK TRANSACTION;
    PRINT 'Error occurred during the animal removal transaction.';
    PRINT ERROR_MESSAGE();
END CATCH;
