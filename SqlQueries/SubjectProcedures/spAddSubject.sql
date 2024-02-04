-- Add Procedure:

CREATE PROCEDURE [spAddSubject](
    @Name NVARCHAR(255),
    @Description TEXT,
    @SubjectTotalHours INT
)
AS
    INSERT INTO [Subject] VALUES(@Name, @Description, @SubjectTotalHours);