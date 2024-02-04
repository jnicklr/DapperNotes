-- Add Procedure:

CREATE PROCEDURE [spAddCourse](
    @Name NVARCHAR(255),
    @MonthlyPrice DECIMAL(10, 2),
    @CourseTime INT
)
AS
    INSERT INTO [Course] VALUES(@Name, @MonthlyPrice, @CourseTime);