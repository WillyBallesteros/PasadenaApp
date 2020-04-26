USE [PasadenaApp]
GO

/****** Object:  Table [cart].[Productos]    Script Date: 26/4/2020 17:40:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [cart].[Productos](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Plu] [nvarchar](20) NULL,
	[ProductoNombre] [nvarchar](100) NULL,
	[MarcaId] [int] NULL,
	[GrupoId] [int] NULL,
	[PuntoVentaId] [int] NULL,
	[ImagenNombre] [nvarchar](50) NULL,
	[ImagenData] [varbinary](max) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [cart].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Grupo] FOREIGN KEY([GrupoId])
REFERENCES [cart].[Grupos] ([GrupoId])
GO

ALTER TABLE [cart].[Productos] CHECK CONSTRAINT [FK_Producto_Grupo]
GO

ALTER TABLE [cart].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([MarcaId])
REFERENCES [cart].[Marcas] ([MarcaId])
GO

ALTER TABLE [cart].[Productos] CHECK CONSTRAINT [FK_Producto_Marca]
GO

ALTER TABLE [cart].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Producto_PuntoVenta] FOREIGN KEY([PuntoVentaId])
REFERENCES [loc].[PuntosDeVentas] ([PuntoVentaId])
GO

ALTER TABLE [cart].[Productos] CHECK CONSTRAINT [FK_Producto_PuntoVenta]
GO


