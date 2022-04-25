USE [Boom]
GO
/****** Object:  Table [dbo].[Kids]    Script Date: 20/4/2022 17:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kids](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[BirthDate] [datetime] NULL,
 CONSTRAINT [PK_Kids] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Toys]    Script Date: 20/4/2022 17:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KidId] [int] NULL,
	[Name] [varchar](100) NULL,
	[Colour] [varchar](100) NULL,
 CONSTRAINT [PK_Toys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD  CONSTRAINT [FK_Toys_Kids] FOREIGN KEY([KidId])
REFERENCES [dbo].[Kids] ([Id])
GO
ALTER TABLE [dbo].[Toys] CHECK CONSTRAINT [FK_Toys_Kids]
GO
