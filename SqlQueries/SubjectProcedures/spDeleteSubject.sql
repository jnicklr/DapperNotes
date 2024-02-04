-- Delete Procedure:

CREATE PROCEDURE [spDeleteSubject](
    @Id INT
)
AS
    BEGIN TRANSACTION
        DELETE FROM [Subject] WHERE [Id] = @Id
    COMMIT