USE
[Spring]
GO
/****** Object:  Table [dbo].[Vacations]    Script Date: 10/24/2012 15:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vacations]
(
    [
    VacationId] [
    decimal]
(
    18,
    0
) IDENTITY
(
    1,
    1
) NOT NULL,
    [FirstName] [varchar]
(
    50
) NULL,
    [LastName] [varchar]
(
    50
) NULL,
    [EmployeeId] [decimal]
(
    18,
    0
) NULL,
    [StartDate] [datetime] NULL,
    [EndDate] [datetime] NULL,
    CONSTRAINT [PK_Vacations] PRIMARY KEY CLUSTERED
(
[
    VacationId]
    ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY]
    GO
    SET ANSI_PADDING OFF
    GO
/****** Object:  Table [dbo].[TestObjects]    Script Date: 10/24/2012 15:44:08 ******/
    SET ANSI_NULLS
  ON
    GO
    SET QUOTED_IDENTIFIER
  ON
    GO
CREATE TABLE [dbo].[TestObjects]
(
    [
    TestObjectNo] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [Age] [int] NOT NULL,
    [Name] [nvarchar]
(
    1024
) NULL,
    CONSTRAINT [TestObjectNo] PRIMARY KEY CLUSTERED
(
[
    TestObjectNo]
    ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Debits]    Script Date: 10/24/2012 15:44:08 ******/
    SET ANSI_NULLS
  ON
    GO
    SET QUOTED_IDENTIFIER
  ON
    GO
CREATE TABLE [dbo].[Debits]
(
    [
    DebitID] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [DebitAmount] [float] NOT NULL,
    CONSTRAINT [PK_DebitID] PRIMARY KEY CLUSTERED
(
[
    DebitID]
    ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Credits]    Script Date: 10/24/2012 15:44:08 ******/
    SET ANSI_NULLS
  ON
    GO
    SET QUOTED_IDENTIFIER
  ON
    GO
CREATE TABLE [dbo].[Credits]
(
    [
    CreditID] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [CreditAmount] [float] NOT NULL,
    CONSTRAINT [PK_CreditID] PRIMARY KEY CLUSTERED
(
[
    CreditID]
    ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY]
    GO

CREATE TABLE [dbo].[Container]
(
    [
    Id] [
    uniqueidentifier]
    NOT
    NULL, [
    Name] [
    nvarchar]
(
    50
) NOT NULL
    ) ON [PRIMARY]
    GO

/****** Object:  StoredProcedure [dbo].[CreateTestObject]    Script Date: 10/24/2012 15:44:09 ******/
    SET ANSI_NULLS
      ON
    GO
    SET QUOTED_IDENTIFIER
      ON
    GO
CREATE PROCEDURE [dbo].[CreateTestObject]
(
  @Name varchar(50),
  @Age  int
)

as
  insert into TestObjects(Name, Age) Values (@Name, @Age)
GO
/****** Object:  StoredProcedure [dbo].[SelectTestObjectAndVacations]    Script Date: 10/24/2012 15:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectTestObjectAndVacations] 
(
  @Name varchar(50)
  
)

as
Begin
select TestObjectNo, Age, Name
from TestObjects
where Name = @Name
select VacationId, FirstName, LastName, EmployeeId, StartDate, EndDate
from Vacations
where FirstName = @Name
End
return
GO
/****** Object:  StoredProcedure [dbo].[SelectByNameWithReturnValue]    Script Date: 10/24/2012 15:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectByNameWithReturnValue]
(
  @Name varchar(50)
  
)

as
select *
from TestObjects
where Name = @Name return 5
GO
/****** Object:  StoredProcedure [dbo].[SelectByNameWithReturnAndOutValue]    Script Date: 10/24/2012 15:44:09 ******/
SET ANSI_NULLS
ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE [dbo].[SelectByNameWithReturnAndOutValue]
(
  @Name varchar(50),
  @Count int output
  
)

as
select *
from TestObjects
where Name = @Name set @Count = 10
return 5
GO
/****** Object:  StoredProcedure [dbo].[SelectByName]    Script Date: 10/24/2012 15:44:09 ******/
SET ANSI_NULLS
ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE [dbo].[SelectByName] 
(
  @Name varchar(50)
  
)

as
select TestObjectNo, Age, Name
from TestObjects
where Name = @Name return
GO
