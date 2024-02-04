-- Update Procedure:

CREATE PROCEDURE [spUpdateSubject](
    @Name NVARCHAR(255),
    @Description TEXT,
    @SubjectTotalHours INT,
    @Id INT
)
AS
    UPDATE [Subject] SET [Name] = @Name, [Description] = @Description, [SubjectTotalHours] = @SubjectTotalHours WHERE [Id] = @Id;