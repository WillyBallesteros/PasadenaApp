USE [PasadenaApp]
GO

/****** Object:  Table [cart].[Anuncio]    Script Date: 26/4/2020 17:38:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cart].[Anuncios](
	[AnuncioId] [int] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [nvarchar](10) NULL,
	[TipoAnuncioId] [int] NULL,
	[Titulo] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](1000) NULL,
	[ProductoId] [int] NULL,
	[PuntoVentaId] [int] NULL,
	[FechaInicio] [nvarchar](10) NULL,
	[FechaFin] [nvarchar](10) NULL,
	[ValorAnterior] [int] NULL,
	[ValorActual] [int] NULL,
	[PorcentajeDcto] [int] NULL,
	[ImagenNombre] [nvarchar](50) NULL,
	[ImagenData] [varbinary](max) NULL,
	[Destacado] [int] NULL,
	[DestacadoId] [int] NULL,
	[Activo] [bit] NULL,
	[Orden] [int] NULL,
 CONSTRAINT [PK_Anuncio] PRIMARY KEY CLUSTERED 
(
	[AnuncioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [cart].[Anuncios]  WITH CHECK ADD  CONSTRAINT [FK_Anuncio_Producto] FOREIGN KEY([ProductoId])
REFERENCES [cart].[Productos] ([ProductoId])
GO

ALTER TABLE [cart].[Anuncios] CHECK CONSTRAINT [FK_Anuncio_Producto]
GO

ALTER TABLE [cart].[Anuncios]  WITH CHECK ADD  CONSTRAINT [FK_Anuncio_PuntoVenta] FOREIGN KEY([PuntoVentaId])
REFERENCES [loc].[PuntosDeVentas] ([PuntoVentaId])
GO

ALTER TABLE [cart].[Anuncios] CHECK CONSTRAINT [FK_Anuncio_PuntoVenta]
GO

ALTER TABLE [cart].[Anuncios]  WITH CHECK ADD  CONSTRAINT [FK_Anuncio_TipoAnuncio] FOREIGN KEY([TipoAnuncioId])
REFERENCES [cart].[TiposDeAnuncios] ([TipoAnuncioId])
GO

ALTER TABLE [cart].[Anuncios] CHECK CONSTRAINT [FK_Anuncio_TipoAnuncio]
GO


