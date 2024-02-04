-- Add Procedure:

CREATE PROCEDURE [spAddContent](
    @Semester INT
)
AS
    INSERT INTO [Content] VALUES(@Semester);