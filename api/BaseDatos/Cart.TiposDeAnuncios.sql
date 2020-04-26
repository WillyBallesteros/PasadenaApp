USE [PasadenaApp]
GO

/****** Object:  Table [cart].[TiposDeAnuncios]    Script Date: 26/4/2020 17:41:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cart].[TiposDeAnuncios](
	[TipoAnuncioId] [int] IDENTITY(1,1) NOT NULL,
	[TipoAnuncioNombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoAnuncio] PRIMARY KEY CLUSTERED 
(
	[TipoAnuncioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


