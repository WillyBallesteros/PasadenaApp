USE [PasadenaApp]
GO

/****** Object:  Table [cart].[Marcas]    Script Date: 26/4/2020 17:40:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cart].[Marcas](
	[MarcaId] [int] IDENTITY(1,1) NOT NULL,
	[MarcaNombre] [nvarchar](50) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


