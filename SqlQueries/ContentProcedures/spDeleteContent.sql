-- Delete Procedure:

CREATE PROCEDURE [spDeleteContent](
    @Id INT
)
AS
    BEGIN TRANSACTION
        DELETE FROM [Content] WHERE [Id] = @Id
    COMMIT