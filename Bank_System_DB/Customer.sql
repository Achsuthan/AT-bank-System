USE [Bank_System]
GO

/****** Object:  Table [dbo].[customer]    Script Date: 03/09/2016 21:38:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[customer](
	[CustomerID] [varchar](20) NOT NULL,
	[CustomerName] [varchar](40) NULL,
	[NIC] [varchar](14) NULL,
	[Gender] [varchar](8) NULL,
	[Age] [int] NULL,
	[Address] [varchar](80) NULL,
	[Income] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


