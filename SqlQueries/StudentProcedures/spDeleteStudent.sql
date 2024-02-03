-- Delete Procedure:

CREATE PROCEDURE [spDeleteStudent](
    @Id INT
)
AS
    BEGIN TRANSACTION
        DELETE FROM [Student] WHERE [Id] = @Id
    COMMIT