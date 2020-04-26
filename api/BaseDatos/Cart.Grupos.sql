USE [PasadenaApp]
GO

/****** Object:  Table [cart].[Grupos]    Script Date: 26/4/2020 17:39:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cart].[Grupos](
	[GrupoId] [int] IDENTITY(1,1) NOT NULL,
	[GrupoNombre] [nvarchar](50) NULL,
	[Activo] [bit] NULL,
	[Orden] [int] NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[GrupoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


