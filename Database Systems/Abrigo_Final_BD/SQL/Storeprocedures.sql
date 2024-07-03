CREATE PROCEDURE AddFuncionario (@Num_func INT, @NIF_Func BIGINT, @Abrigo_Email VARCHAR(128), @Telefone VARCHAR(20), @Nome VARCHAR(128), @Endereco VARCHAR(1024), @Email VARCHAR(128), @Horario DATETIME)
AS
BEGIN
    BEGIN TRY
        -- Check if the funcionario already exists
        IF EXISTS (SELECT 1 FROM Projeto_Funcionario WHERE Num_func = @Num_func)
        BEGIN
            RAISERROR ('O funcionário com este número de funcionário já existe na base de dados! Por favor, escolha outro número.', 16, 1);
            RETURN;
        END

        -- Check if the associated abrigo exists
        IF NOT EXISTS (SELECT 1 FROM Projeto_Abrigo WHERE Email = @Abrigo_Email)
        BEGIN
            RAISERROR ('O abrigo associado ao funcionário não existe na base de dados! Por favor, verifique o email do abrigo.', 16, 1);
            RETURN;
        END

        -- Insert funcionario
        INSERT INTO Projeto_Funcionario (Num_func, NIF_Func, Abrigo_Email, Telefone, Nome, Endereco, Email, Horario) 
        VALUES (@Num_func, @NIF_Func, @Abrigo_Email, @Telefone, @Nome, @Endereco, @Email, @Horario);

        PRINT 'Funcionário adicionado com sucesso!';
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        -- Log the error
        INSERT INTO ErrorLog (ErrorMessage, ErrorSeverity, ErrorState) 
        VALUES (@ErrorMessage, @ErrorSeverity, @ErrorState);

        -- Raise the error
        RAISERROR ('Ocorreu um erro ao adicionar o funcionário. Por favor, contate o administrador.', 16, 1);
    END CATCH
END;
GO

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
    -- Remove o funcionário da tabela Projeto_Funcionario
    DELETE FROM Projeto_Funcionario
    WHERE Num_Func = @Num_Func;
END;
GO




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
