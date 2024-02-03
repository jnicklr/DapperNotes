-- Update Procedure:

CREATE PROCEDURE [spUpdateStudent](
    @Name NVARCHAR(255),
    @CPF NVARCHAR(11),
    @BirthDate DATE,
    @Id INT
)
AS
    UPDATE [Student] SET [Name] = @Name, [CPF] = @CPF, [BirthDate] = @BirthDate WHERE [Id] = @Id;