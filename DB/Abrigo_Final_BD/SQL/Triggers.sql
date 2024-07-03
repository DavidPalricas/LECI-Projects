
CREATE TRIGGER DeleteTratadorRelations
ON Projeto_Tratador
INSTEAD OF DELETE
AS
BEGIN
    DELETE FROM Projeto_Tem_Tratamento_Tratador_Animal WHERE Tratador_NIF IN (SELECT NIF_Tratador FROM deleted);

    DELETE FROM Projeto_Tratador WHERE NIF_Tratador IN (SELECT NIF_Tratador FROM deleted);


END


CREATE TRIGGER DeleteAnimalRelations
ON Projeto_Animal
INSTEAD OF DELETE
AS
BEGIN
    DELETE FROM Projeto_TEM_Desparasitacao WHERE Num_chegada IN (SELECT Num_chegada FROM deleted);
    DELETE FROM Projeto_Historial_Clinico WHERE Num_chegada IN (SELECT Num_chegada FROM deleted);
    DELETE FROM Projeto_Tem_Vacina WHERE Num_chegada IN (SELECT Num_chegada FROM deleted);
    DELETE FROM Projeto_Tem_Tratamento_Tratador_Animal WHERE Num_chegada IN (SELECT Num_chegada FROM deleted);

    DELETE FROM Projeto_Animal WHERE Num_chegada IN (SELECT Num_chegada FROM deleted);
END







