-- Update Procedure:

CREATE PROCEDURE [spUpdateProfessor](
    @Name NVARCHAR(255),
    @ValuePerHour DECIMAL(6, 2),
    @AcademicDegree TEXT,
    @Id INT
)
AS
    UPDATE [Professor] SET [Name]=@Name, [ValuePerHour]=@ValuePerHour, [AcademicDegree]=@AcademicDegree WHERE [Id]=@Id;