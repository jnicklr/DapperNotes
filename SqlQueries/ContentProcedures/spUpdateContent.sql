-- Update Procedure:

CREATE PROCEDURE [spUpdateContent](
    @Semester INT,
    @Id INT
)
AS
    UPDATE [Content] SET [Semester]=@Semester WHERE [Id]=@Id;