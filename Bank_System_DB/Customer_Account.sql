USE [Bank_System]
GO

/****** Object:  Table [dbo].[account]    Script Date: 03/09/2016 21:34:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[account](
	[AccountNumber] [varchar](30) NOT NULL,
	[AccountType] [varchar](30) NULL,
	[IntrestRate] [varchar](10) NULL,
	[DateAccountOpen] [varchar](50) NULL,
	[AccountBalance] [float] NULL,
	[BranchID] [varchar](10) NULL,
	[CustomerID] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[account]  WITH CHECK ADD FOREIGN KEY([BranchID])
REFERENCES [dbo].[branch] ([BranchID])
GO

ALTER TABLE [dbo].[account]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[customer] ([CustomerID])
GO


