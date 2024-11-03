USE [PasadenaApp]
GO

/****** Object:  Table [loc].[PuntoVenta]    Script Date: 26/4/2020 17:32:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [loc].[PuntosDeVentas](
	[PuntoVentaId] [int] IDENTITY(1,1) NOT NULL,
	[Nit] [decimal](18, 0) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Celular] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Web] [nvarchar](200) NULL,
	[Contacto] [nvarchar](100) NULL,
	[CiudadId] [int] NULL,
	[Logo] [nvarchar](150) NULL,
	[Lat] [nvarchar](50) NULL,
	[Lon] [nvarchar](50) NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_PuntoVenta] PRIMARY KEY CLUSTERED 
(
	[PuntoVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [loc].[PuntosDeVentas]  WITH CHECK ADD  CONSTRAINT [FK_PuntoVenta_Ciudad] FOREIGN KEY([CiudadId])
REFERENCES [loc].[Ciudades] ([CiudadId])
GO

ALTER TABLE [loc].[PuntosDeVentas] CHECK CONSTRAINT [FK_PuntoVenta_Ciudad]
GO


