USE [HostingGrafiki]
GO

/****** Object:  Table [dbo].[Pliki]    Script Date: 05/19/2011 16:44:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Pliki](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NazwaPliku] [varchar](max) NOT NULL,
	[GUID] [varchar](36) NOT NULL,
	[Prywatny] [int] NOT NULL,
 CONSTRAINT [PK_Pliki] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

