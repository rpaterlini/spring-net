USE
[Credits]
GO
/****** Object:  Table [dbo].[Credits]    Script Date: 10/24/2012 15:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
