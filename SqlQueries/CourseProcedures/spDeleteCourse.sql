-- Delete Procedure:

CREATE PROCEDURE [spDeleteCourse](
    @Id INT
)
AS
    BEGIN TRANSACTION
        DELETE FROM [Course] WHERE [Id] = @Id
    COMMIT