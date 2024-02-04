-- Add Procedure:

CREATE PROCEDURE [spAddProfessor](
    @Name NVARCHAR(255),
    @ValuePerHour DECIMAL(6, 2),
    @AcademicDegree TEXT
)
AS
    INSERT INTO [Professor] VALUES(@Name, @ValuePerHour, @AcademicDegree);