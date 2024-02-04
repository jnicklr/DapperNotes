-- Delete Procedure:

CREATE PROCEDURE [spDeleteProfessor](
    @Id INT
)
AS
    BEGIN TRANSACTION
        DELETE FROM [Professor] WHERE [Id] = @Id
    COMMIT