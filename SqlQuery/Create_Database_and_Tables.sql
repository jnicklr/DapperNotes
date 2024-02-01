-- Criando Banco de Dados:

CREATE DATABASE [School];

-- Definindo o Banco de Dados Usado:

USE [School];

-- Criando as Tabelas:

CREATE TABLE [Professor](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(255) NOT NULL,
    [ValuePerHour] DECIMAL(6, 2) NOT NULL,
    [AcademicDegree] TEXT NOT NULL,

    CONSTRAINT [PK_Professor] PRIMARY KEY([Id]),
);

CREATE TABLE [ProfessorSubject](
    [ProfessorId] INT NOT NULL ,
    [SubjectId] INT NOT NULL,

    CONSTRAINT [PK_ProfessorSubject] PRIMARY KEY([ProfessorId], [SubjectId]),
);

CREATE TABLE [Subject](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(255) NOT NULL,
    [Description] TEXT NOT NULL,
    [SubjectTotalHours] INT NOT NULL,

    CONSTRAINT [PK_Subject] PRIMARY KEY([Id]),
);

CREATE TABLE [SubjectContent](
    [SubjectId] INT NOT NULL ,
    [ContentId] INT NOT NULL,

    CONSTRAINT [PK_SubjectContent] PRIMARY KEY([SubjectId], [ContentId]),
);

CREATE TABLE [Content](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Semester] SMALLINT NOT NULL,

    CONSTRAINT [PK_Content] PRIMARY KEY([Id]),
);

CREATE TABLE [CourseContent](
    [CourseId] INT NOT NULL ,
    [ContentId] INT NOT NULL,

    CONSTRAINT [PK_CourseContent] PRIMARY KEY([CourseId], [ContentId]),
);

CREATE TABLE [Course](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(255) NOT NULL,
    [MonthlyPrice] NVARCHAR(11) NOT NULL,
    [CourseTime] INT NOT NULL,

    CONSTRAINT [PK_Course] PRIMARY KEY([Id]),  
);

CREATE TABLE [Student](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(255) NOT NULL,
    [CPF] NVARCHAR(11) NOT NULL,
    [BirthDate] DATE NOT NULL,

    CONSTRAINT [PK_Student] PRIMARY KEY([Id]),
);

CREATE TABLE [Enrollment](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [EnrollmentDate] DATE NOT NULL,
    [EnrollmentValue] DECIMAL(10, 2) NOT NULL,
    [StudentClass] SMALLINT NOT NULL,
    [StudentId] INT NOT NULL,
    [CourseId] INT NOT NULL,

    CONSTRAINT [PK_Enrollment] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Student] FOREIGN KEY([Id])
        REFERENCES [Student]([Id]),
    CONSTRAINT [FK_Course] FOREIGN KEY([Id])
        REFERENCES [Course]([Id]),
);