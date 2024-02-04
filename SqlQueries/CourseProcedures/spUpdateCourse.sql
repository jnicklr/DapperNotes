-- Update Procedure:

CREATE PROCEDURE [spUpdateCourse](
    @Name NVARCHAR(255),
    @MonthlyPrice DECIMAL(10, 2),
    @CourseTime INT,
    @Id INT
)
AS
    UPDATE [Course] SET [Name]=@Name, [MonthlyPrice]=@MonthlyPrice, [CourseTime]=@CourseTime WHERE [Id]=@Id;