-- Add Procedure:

CREATE PROCEDURE [spAddStudent](
    @Name NVARCHAR(255),
    @CPF NVARCHAR(11),
    @BirthDate DATE
)
AS
    INSERT INTO [Student] VALUES(@Name, @CPF, @BirthDate);