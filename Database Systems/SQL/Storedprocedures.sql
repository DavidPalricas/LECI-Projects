CREATE PROCEDURE AddFuncionario
    @Num_Func INT,
    @NIF_Func BIGINT,
    @Abrigo_Email VARCHAR(128),
    @Telefone VARCHAR(20),
    @Nome VARCHAR(128),
    @Endereco VARCHAR(1024),
    @Email VARCHAR(128),
    @Horario DATETIME,
    @Success BIT OUTPUT
AS
BEGIN
  
    SET @Success = 1

    -- Verifica se o NIF_Func já existe
    IF EXISTS (SELECT 1 FROM Projeto_Funcionario WHERE NIF_Func = @NIF_Func)
    BEGIN
         SET @Success = 0
    END
    ELSE
    BEGIN
        -- Insere um novo registro na tabela Projeto_Funcionario
        INSERT INTO Projeto_Funcionario (Num_Func, NIF_Func, Abrigo_Email, Telefone, Nome, Endereco, Email, Horario)
        VALUES (@Num_Func, @NIF_Func, @Abrigo_Email, @Telefone, @Nome, @Endereco, @Email, @Horario)
        
    END
END;

CREATE PROCEDURE RemoveFuncionario
    @Num_Func INT
AS
BEGIN
   
    BEGIN TRANSACTION;
    BEGIN TRY
        
        DELETE FROM Projeto_Funcionario
        WHERE Num_Func = @Num_Func;

       
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
       
        ROLLBACK TRANSACTION;
    END CATCH;
END;




CREATE PROCEDURE AddTratador
    @Num_Tratador INT,
    @NIF_Tratador BIGINT,
    @Abrigo_Email VARCHAR(128),
    @Telefone VARCHAR(20),
    @Nome VARCHAR(128),
    @Endereco VARCHAR(1024),
    @Email VARCHAR(128),
    @Horario DATETIME,
    @Success BIT OUTPUT
AS
BEGIN
    SET @Success = 1

    -- Verifica se o NIF_Tratador já existe
    IF EXISTS (SELECT 1 FROM Projeto_Tratador WHERE NIF_Tratador = @NIF_Tratador)
    BEGIN
         SET @Success = 0
    END
    ELSE
    BEGIN
        -- Insere um novo registro na tabela Projeto_Tratador
        INSERT INTO Projeto_Tratador (Num_Tratador, NIF_Tratador, Abrigo_Email, Telefone, Nome, Endereco, Email, Horario)
        VALUES (@Num_Tratador, @NIF_Tratador, @Abrigo_Email, @Telefone, @Nome, @Endereco, @Email, @Horario)
    END
END;


CREATE PROCEDURE RemoveTratador
    @NIF_Tratador BIGINT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        DELETE FROM Projeto_Tratador
        WHERE NIF_Tratador = @NIF_Tratador;

        COMMIT TRANSACTION;
        PRINT 'Tratador  removido com sucesso .';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Erro na remoçáo com o tratador.';
        PRINT ERROR_MESSAGE();
    END CATCH;
END;



CREATE PROCEDURE VerifyPassword
    @username NVARCHAR(50),
    @password NVARCHAR(128),
    @isValid BIT OUTPUT
AS
BEGIN
    DECLARE @storedHash VARCHAR(64);
    DECLARE @inputHash VARCHAR(64);

    -- Recupera o hash armazenado do banco de dados
    SELECT @storedHash = Password
    FROM Projeto_Login
    WHERE Username = @username;

    -- Gera o hash da senha fornecida
    SET @inputHash = dbo.HashPassword(@password);

    -- Compara os hashes
    IF @storedHash = @inputHash
        SET @isValid = 1;
    ELSE
        SET @isValid = 0;
END;
GO


CREATE PROCEDURE RemoveTratador
    @NIF_Tratador BIGINT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        DELETE FROM Projeto_Tratador
        WHERE NIF_Tratador = @NIF_Tratador;

        COMMIT TRANSACTION;
        PRINT 'Tratador removido com sucesso.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Erro na remoção do tratador.';
        PRINT ERROR_MESSAGE();
    END CATCH;
END;



CREATE PROCEDURE AtualizarAdotanteNIF @NIF_Adotante BIGINT, @Num_chegada BIGINT
AS
BEGIN
    UPDATE Projeto_Animal
    SET Adotante_NIF = @NIF_Adotante
    WHERE Num_chegada = @Num_chegada;
END;



CREATE PROCEDURE RemoveAnimal
 @Num_chegada BIGINT
AS
BEGIN
   
    BEGIN TRANSACTION;
    BEGIN TRY
        
        DELETE FROM Projeto_Animal
        WHERE Num_chegada = @Num_chegada;

       
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
       
        ROLLBACK TRANSACTION;
    END CATCH;
END;






